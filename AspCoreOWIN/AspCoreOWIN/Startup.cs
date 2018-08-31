using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AspCoreOWIN
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseOwin(pipeline =>
            {
                pipeline(next => SendResponseAsync);
            });
        }

        public Task SendResponseAsync(IDictionary<string, object> environment)
        {
            // define response
            string responseText = "Hello ASP.NET CORE";
            // codding it
            byte[] responseBytes = Encoding.UTF8.GetBytes(responseText);

            // get stream of answer
            var responseStream = (Stream) environment["owin.ResponseBody"];
            // send answer
            return responseStream.WriteAsync(responseBytes, 0, responseBytes.Length);
        }

    }
}
