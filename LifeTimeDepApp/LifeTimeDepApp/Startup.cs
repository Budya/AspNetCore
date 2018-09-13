using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeTimeDepApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace LifeTimeDepApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICounter, RandomCounter>();
            services.AddTransient<CounterService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<CounterMiddleware>();
        }
    }
}
