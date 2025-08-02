using BaseArchitecture.Infrastructure.Shared.BaseRepository;
using BaseArchitecture.Infrastructure.Shared.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseArchitecture.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection Services)
        {
            // Register service dependencies here
            // Example: services.AddScoped<IMyService, MyService>();
            Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            return Services;
        }
    }
}
