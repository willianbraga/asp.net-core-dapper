using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using WillStore.Domain.StoreContext.Handlers;
using WillStore.Domain.StoreContext.Repositories;
using WillStore.Domain.StoreContext.Services;
using WillStore.Infra.Services;
using WillStore.Infra.StoreContext.DataContexts;
using WillStore.Infra.StoreContext.Repositories;
using WillStore.Infra.StoreContext.Services;

namespace WillStore.Api
{
    public class Startup
    {
        private const string SWAGGERFILE_PATH_V1 = "./swagger/v1/swagger.json";
        private const string SWAGGERFILE_PATH_V2 = "./swagger/v2/swagger.json";

        private const string API_VERSION_1 = "v1";
        private const string API_VERSION_2 = "v2";

        private const string PROJECT_NAME = "Store API";
        private const string XML_EXTENSION = ".xml";

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddResponseCompression();

            services.AddScoped<WillDataContext, WillDataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandler, CustomerHandler>();

            services.AddApiVersioning(x =>
               {
                   x.AssumeDefaultVersionWhenUnspecified = true;
                   x.DefaultApiVersion = new ApiVersion(1, 0);
               });

            AddSwagger(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger()
              .UseSwaggerUI(c =>
               {
                   c.RoutePrefix = string.Empty;
                   c.SwaggerEndpoint(SWAGGERFILE_PATH_V1, $"{PROJECT_NAME} {API_VERSION_1}");
                   c.SwaggerEndpoint(SWAGGERFILE_PATH_V2, $"{PROJECT_NAME} {API_VERSION_2}");
               });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseResponseCompression();
        }
        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(API_VERSION_1, new OpenApiInfo
                {
                    Version = API_VERSION_1,
                    Title = $"{PROJECT_NAME} {API_VERSION_1}",
                    Description = "For tests API Version 1 Description"
                });

                c.SwaggerDoc(API_VERSION_2, new OpenApiInfo
                {
                    Version = API_VERSION_2,
                    Title = $"{PROJECT_NAME} {API_VERSION_2}",
                    Description = "For tests API Version 2 Description"
                });

                c.ResolveConflictingActions(x => x.First());
                c.OperationFilter<RemoveVersionFromParameter>();
                c.DocumentFilter<ReplaceVersionWithExactValueInPath>();


                var xmlFile = Assembly.GetExecutingAssembly().GetName().Name + XML_EXTENSION;
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}
