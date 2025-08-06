using BaseArchitecture.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace BaseArchitecture.Infrastructure
{
    public static class InfrastructureRegistrationServices
    {
        public static IServiceCollection AddInfrastructureRegistrationServices(this IServiceCollection Services, IConfiguration config)
        {
            #region Context Registration

            // Register the DbContext with the connection string from configuration
            Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("school"));
            });

            #endregion

            return Services;
        }
    }
}
