using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructorDepApp;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MiddlewareDependApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMessageSender, EmailMessageSender>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<MessageMiddleware>();
        }
    }
}
