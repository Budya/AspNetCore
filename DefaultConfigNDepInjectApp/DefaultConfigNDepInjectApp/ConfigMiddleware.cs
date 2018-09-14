using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace DefaultConfigNDepInjectApp
{
    public class ConfigMiddleware
    {
        private readonly RequestDelegate _next;

        public ConfigMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            AppConfiguration = config;
        }
        public IConfiguration AppConfiguration { get; set; }

        public async Task Invoke(HttpContext context)
        {
            var color = AppConfiguration["color"];
            var text = AppConfiguration["text"];
            await context.Response.WriteAsync($"<p style='color:{color};'>{text}</p>");
        }
    }
}
