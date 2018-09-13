using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeTimeDepApp.Services;
using Microsoft.AspNetCore.Http;

namespace LifeTimeDepApp
{
    public class CounterMiddleware
    {
        private readonly RequestDelegate _next;
        private int i = 0;

        public CounterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext,
                                 ICounter counter,
                                 CounterService counterService)
        {
            i++;
            httpContext.Response.ContentType = "text/html;charset=utf-8";
            await httpContext.Response.WriteAsync($"Запрос {i}; Counter: { counter.Value}; Service: { counterService.Counter.Value}");
        }
    }
}
