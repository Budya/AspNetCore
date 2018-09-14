using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigurationApp
{
    public class Startup
    {
        public Startup()
        {
            // config builder
            var builder = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
            {
                { "firstname", "Tom"}, 
                { "age", "31"}
            });
            // made configuration
            AppConfiguration = builder.Build();
        }
        // property, for conf storing
        public IConfiguration AppConfiguration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
            AppConfiguration["firstname"] = "alice";
            AppConfiguration["lastname"] = "simpson";
            app.Run(async (context) => 
            {
                await context.Response.WriteAsync(
                    AppConfiguration["firstname"]+" "+ AppConfiguration["lastname"]);
            });
            
        }
    }
}
