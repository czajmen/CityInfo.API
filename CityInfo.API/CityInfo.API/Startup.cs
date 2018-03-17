using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace CityInfo.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                //.AddJsonOptions(x =>
                //{
                //    if (x.SerializerSettings.ContractResolver != null)
                //    {
                //        var customContractResolver = x.SerializerSettings.ContractResolver as DefaultContractResolver;

                //        customContractResolver.NamingStrategy = null; // Będzie wysylal w responsie dokładnie takie nazwy pól w json jak nazwy prop w klasach (nie zaczyanac od małej litery!)
                //    }
                //})
                .AddJsonFormatters()  // Domyslny formater to pierwszy w kolekcji 
                .AddXmlDataContractSerializerFormatters();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseStatusCodePages(); // Przesyła w text error a nie tylko status z headerze 
            app.UseMvc();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
