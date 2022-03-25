using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using STVMatrimony.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STVMatrimonyAPI.Interfaces;
using STVMatrimonyAPI.Repository;
using Microsoft.OpenApi.Models;
using AutoWrapper;

namespace STVMatrimonyAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // DB Context
            string cnnStr = Configuration.GetConnectionString("STVDatawarehouseConstr");
            services.AddDbContext<DatawarehouseContext>(item => item.UseSqlServer(cnnStr));

            // Get the API Configuration
            services.AddOptions<Model.APIConfiguration>().Bind(Configuration.GetSection("APIConfiguration"));
            services.AddOptions<Model.EMailConfiguration>().Bind(Configuration.GetSection("EMailConfiguration"));
            services.AddTransient<IMailService, Services.MailService>();
            // Register Repository
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IAuthenticateRepository, AuthenticateRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<ICustomerInfoRepository, CustomerInfoRepository>();
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "STVMatrimony API", Version = "v1" });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "STVMatrimony API V1");
                c.RoutePrefix = string.Empty;
            });
            // Added AutoWrapper configuration 
            app.UseApiResponseAndExceptionWrapper(new AutoWrapperOptions { ShowApiVersion = true,ShowStatusCode=true, ApiVersion = "2.0" });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
