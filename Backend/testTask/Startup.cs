using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using Swashbuckle.AspNetCore.Swagger;
using testTask.Configure;
using testTask.Contexts;
using testTask.Interfaces;
using testTask.Services;

namespace testTask
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
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new Info { Title = "rcproj", Description = "Swagger RCprofessional Api" });
                //var xmlPath = System.AppDomain.CurrentDomain.BaseDirectory + @"rcproj.xml";
                //c.IncludeXmlComments(xmlPath);
            }
            );
            services.AddCors();
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();
            services.Configure<AppOptions>(Configuration.GetSection("AppOptions"));
            services.Configure<TwitterOptions>(Configuration.GetSection("TwitterOptions"));
            services.AddScoped<IVacancyService, VacancyService>();
            services.AddScoped<IEventService, EventService>();
            services.AddSingleton<IFileStorageService, LocalFileStorage>();
            services.AddScoped<ISocialWebService, TwitterAPIService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(builder => builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowCredentials()
            .AllowAnyMethod());
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/V1/swagger.json", "rcproj");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
