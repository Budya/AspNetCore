using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WorkingWithConfigApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("project.json");
            AppConfiguration = builder.Build();
        }
        public IConfiguration AppConfiguration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {

        }

        public void Configure(IApplicationBuilder app)
        {
            string projectJsonContent = GetSectionContent(AppConfiguration);
            app.Run(async (context) => { await context.Response.WriteAsync("{\n" + projectJsonContent + "}"); });
        }

        private string GetSectionContent(IConfiguration configSection)
        {
            string sectionContent = "";
            foreach (var section in configSection.GetChildren())
            {
                sectionContent +="\"" + section.Key + "\":";
                if (section.Value == null)
                {
                    string subSectionContent = GetSectionContent(section);
                    sectionContent += "{\n" + subSectionContent + "}, \n";
                }
                else
                {
                    sectionContent += "\"" + section.Value + "\", \n";
                }
            }

            return sectionContent;
        }
    }
}
