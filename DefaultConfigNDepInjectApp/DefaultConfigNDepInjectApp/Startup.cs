using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DefaultConfigNDepInjectApp
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            AppConfiguration = config;
        }
        public IConfiguration AppConfiguration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
            var color = AppConfiguration["color"];
            var text = AppConfiguration["text"];
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"<p style='color:{color};'>{text}</p>");
            });
        }
    }
}
