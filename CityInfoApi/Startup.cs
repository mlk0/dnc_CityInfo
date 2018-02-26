using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CityInfoApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(); //this one is adding the ASP.NET Core MVC as middleware
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //env.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }



            app.UseMvc(

                //sample for convention based routing that is not recommended
                config => {
                config.MapRoute(
                    name : "Default",
                    template : "{controller}/{action}/{id?}",
                    defaults : new {controller="City", action="GetCities"}
                    );
                }
            );

            //app.UseMvc(); //this one is using the ASP.NET Core MVC Middleware in the request pipelinee




            //app.Run((context) =>
            //{
            //    throw new Exception("Something bad happened ...");
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
