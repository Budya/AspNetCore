using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructorDepApp;
using Microsoft.AspNetCore.Http;

namespace MiddlewareDependApp
{
    public class MessageMiddleware
    {
        private readonly RequestDelegate _next;

        public MessageMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context, IMessageSender messageSender)
        {
            context.Response.ContentType = "text/html;charset=utf-8";
            await context.Response.WriteAsync(messageSender.Send());
        }
    }
}
