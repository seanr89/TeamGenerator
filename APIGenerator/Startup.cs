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
using APIGenerator.Filters;
using APIGenerator.Factories;
using APIGenerator.Factories.Interfaces;

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
            //Configure Swagger documentation handling
            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "Team Generation API",
                    Version = "v1",
                    Description = "The Team Generation Service HTTP API",
                    TermsOfService = "Terms Of Service"
                });
            });

            //Location for class DI Injection
            services.AddScoped<ITeamGenerator, TeamGenerator>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IDayRepository, DayRepository>();

            //Run through App Settings to search for what repository could be used in the future!
            if (Configuration.GetValue<bool>("DatabaseConnectionOptions:SQLAzure"))
            {
                services.AddScoped<IDataRepositoryFactory, SQLDataRepositoryFactory>();
            }
            else
            {
                services.AddScoped<JSONFileReader>();
                services.AddScoped<IDataRepositoryFactory, JSONDataRepositoryFactory>();
            }

            // Add framework services.
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));         
            });
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
