using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace _01RoutingApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            // define route handler
            var myRouteHandler = new RouteHandler(Handle);
            // creation route, use Handler
            var routeBuilder = new RouteBuilder(app, myRouteHandler);
            // определение маршрута - он должен соответствовать запросу конроллер/действие
            routeBuilder.MapRoute("default", "{controller}/{action}");
            // build the route
            app.UseRouter(routeBuilder.Build());

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }

        private async Task Handle(HttpContext context)
        {
            await context.Response.WriteAsync("Hello ASP.NET Core!");
        }
    }
}
