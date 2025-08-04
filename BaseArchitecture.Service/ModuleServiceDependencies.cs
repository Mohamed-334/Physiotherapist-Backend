using BaseArchitecture.Service.Service;
using BaseArchitecture.Service.ServiceInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BaseArchitecture.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            // Register service dependencies here
            // Example: services.AddScoped<IMyService, MyService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
