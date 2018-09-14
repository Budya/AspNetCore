using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _06EnvVariablesConfStoring
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            AppConfiguration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();
        }
        public IConfiguration AppConfiguration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {

        }

        public void Configure(IApplicationBuilder app)
        {
            string java_dir = AppConfiguration["JAVA_HOME"] ?? "not set";
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(java_dir);
            });
        }
    }
}
