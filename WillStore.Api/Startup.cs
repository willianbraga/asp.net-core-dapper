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
using WillStore.Infra.StoreContext.DataContexts;
using WillStore.Infra.StoreContext.Repositories;
using WillStore.Infra.StoreContext.Services;

namespace WillStore.Api
{
    public class Startup
    {
        private const string SWAGGERFILE_PATH = "./swagger/v1/swagger.json";
        private const string API_VERSION = "v1";
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


            services.AddScoped<WillDataContext, WillDataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandler, CustomerHandler>();


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
                   c.SwaggerEndpoint(SWAGGERFILE_PATH, PROJECT_NAME + API_VERSION);
               });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(API_VERSION, new OpenApiInfo { Title = PROJECT_NAME, Version = API_VERSION });
                var xmlFile = Assembly.GetExecutingAssembly().GetName().Name + XML_EXTENSION;
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}
