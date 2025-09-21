using BaseArchitecture.Infrastructure.Shared.BaseRepository;
using BaseArchitecture.Infrastructure.Shared.Interfaces;
using LMS.Infrastructure.Context.Interceptors;
using Microsoft.Extensions.DependencyInjection;
using PhysiotherapistProject.Infrastructure.Repository;
using PhysiotherapistProject.Infrastructure.RepositoryInterfaces;

namespace BaseArchitecture.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection Services)
        {
            // Register service dependencies here
            // Example: services.AddScoped<IMyService, MyService>();
            Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            Services.AddScoped(typeof(ICourseRepository), typeof(CourseRepository));
            Services.AddScoped(typeof(ISessionRepository), typeof(SessionRepository));
            Services.AddScoped(typeof(IClinicRepository), typeof(ClinicRepository));
            Services.AddScoped(typeof(IReportRepository), typeof(ReportRepository));
            Services.AddScoped<LoggerSaveChangesInterceptor>();
            return Services;
        }
    }
}
