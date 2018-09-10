using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ConstructorDepApp
{
    public class Startup
    {
         public void ConfigureServices(IServiceCollection services)
         {
             services.AddTransient<IMessageSender, EmailMessageSender>();
             services.AddTransient<MessageService>();
         }

       public void Configure(IApplicationBuilder app, MessageService messageService)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(messageService.Send());
            });
        }
    }
}
