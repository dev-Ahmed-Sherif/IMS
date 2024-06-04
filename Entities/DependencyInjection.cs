using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectEntitiesDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DependencyInjection));
            return services;
        }

    }
}
