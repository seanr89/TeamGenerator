using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIGenerator.Business;
using APIGenerator.DataLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using APIGenerator.Business.Interfaces;
using APIGenerator.Repository.Interfaces;
using APIGenerator.Repository;
using Swashbuckle.AspNetCore.Swagger;

namespace APIGenerator
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "Test HTTP API",
                    Version = "v1",
                    Description = "The Tests Service HTTP API",
                    TermsOfService = "Terms Of Service"
                });
            });

            //Location for class DI Injection
            services.AddScoped<JSONFileReader>();
            services.AddScoped<ITeamGenerator, TeamGenerator>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IDayRepository, DayRepository>();

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if(env.IsDevelopment())
            {

            }
            else
            {

            }

            app.UseMvcWithDefaultRoute();

            app.UseSwagger()
               .UseSwaggerUI(c =>
               {
                   c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
               }); 
        }
    }
}
