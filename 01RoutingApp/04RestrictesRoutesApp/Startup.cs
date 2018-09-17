using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace _04RestrictesRoutesApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            var myRouteHandler = new RouteHandler(Handle);
            var routeBuilder = new RouteBuilder(app, myRouteHandler);
            routeBuilder.MapRoute("default",
                "{controller}/{action}/{id?}",
                new {action = "Index"}, // defaulg parameter
                new {controller = "^H", id = @"\d{2}"} // restricton
                );
            app.UseRouter(routeBuilder.Build());

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
        // https://metanit.com/sharp/aspnet5/11.3.php

        private async Task Handle(HttpContext context)
        {
            var routeValues = context.GetRouteData().Values;
            var action = routeValues["action"].ToString();
            var name = routeValues["name"].ToString();
            var year = routeValues["year"].ToString();
            await context.Response.WriteAsync($"action: {action} | name: {name} | year:{year}");
        }
    }
}
