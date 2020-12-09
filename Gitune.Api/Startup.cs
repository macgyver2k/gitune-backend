using Gitune.Api.GraphQL;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Gitune.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors( options => options.AddDefaultPolicy( builder => builder.WithOrigins( "http://localhost:4200" ).AllowAnyHeader()) );

            services.AddSingleton<EventHub>();
            services.AddSingleton<IEventSink>(provider => provider.GetService<EventHub>());
            services.AddSingleton<IEventSource>(provider => provider.GetService<EventHub>());

            services.AddMediatR(Assembly.Load("Gitune.Api"));

            services.AddCustomGraphQL();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors();
            
            app.UseCustomGraphQL();

            
        }
    }
}
