using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace _02DefiningRoutesApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            var routeBuilder = new RouteBuilder(app);
            routeBuilder.MapRoute("{controller}/{action}",
                async context =>
                {
                    context.Response.ContentType = "text/html;charset=utf-8";
                    await context.Response.WriteAsync("двухсегментный запрос");
                });

            routeBuilder.MapRoute("{controller}/{action}/{id}",
                async context =>
                {
                    context.Response.ContentType = "text/html;charset=utf-8";
                    await context.Response.WriteAsync("трехсегментный запрос");
                });


            app.UseRouter(routeBuilder.Build());

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
