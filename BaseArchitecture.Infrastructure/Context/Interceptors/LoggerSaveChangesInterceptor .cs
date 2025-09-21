using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using PhysiotherapistProject.Domain.Entities.Logger;
using System.Security.Claims;

namespace LMS.Infrastructure.Context.Interceptors
{
    public class LoggerSaveChangesInterceptor : SaveChangesInterceptor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoggerSaveChangesInterceptor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            var context = eventData.Context;

            if (context == null) return base.SavingChangesAsync(eventData, result, cancellationToken);

            var auditEntries = new List<Logger>();

            var contextEntries = context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .Where(e => e.Entity.GetType().Name != nameof(Logger));

            foreach (var entry in contextEntries)
            {
                var audit = new Logger
                {
                    TableName = entry.Entity.GetType().Name,
                    Action = entry.State.ToString(),
                    KeyValues = JsonConvert.SerializeObject(entry.Properties
                                   .Where(p => p.Metadata.IsPrimaryKey())
                                   .ToDictionary(p => p.Metadata.Name, p => p.CurrentValue)),
                    OldValues = entry.State == EntityState.Modified || entry.State == EntityState.Deleted
                                ? JsonConvert.SerializeObject(entry.Properties
                                   .ToDictionary(p => p.Metadata.Name, p => p.OriginalValue))
                                : null,
                    NewValues = entry.State == EntityState.Added || entry.State == EntityState.Modified
                                ? JsonConvert.SerializeObject(entry.Properties
                                   .ToDictionary(p => p.Metadata.Name, p => p.CurrentValue))
                                : null,
                    UserId = GetUserId(),
                    DateTime = DateTime.UtcNow
                };

                auditEntries.Add(audit);
            }

            if (auditEntries.Any())
            {
                context.Set<Logger>().AddRange(auditEntries);
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private int? GetUserId()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                return null;
            }
            var userIdClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            return userIdClaim != null ? int.Parse(userIdClaim.Value) : null;
        }
    }
}
