using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DepIApp.Services
{
    public static class ServiceProviderExtensions
    {
        public static void AddTimeService(this IServiceCollection service)
        {
            service.AddTransient<TimeService>();
        }
    }
}
