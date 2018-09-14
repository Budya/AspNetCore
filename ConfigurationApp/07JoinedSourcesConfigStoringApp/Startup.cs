using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _07JoinedSourcesConfigStoringApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath);
            builder.AddJsonFile("conf.json");
            builder.AddEnvironmentVariables();
            builder.AddInMemoryCollection(new Dictionary<string, string>
            {
                {"firstname", "Tom"},
                {"age", "31"}
            });
            AppConfiguration = builder.Build();
        }

        public IConfiguration AppConfiguration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            var color = AppConfiguration["color"];  // определен в файле conf.json
            string text = AppConfiguration["firstname"]; // определен в памяти
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"<p style='color:{color};'>{text}</p>");
            });
        }
    }
}
