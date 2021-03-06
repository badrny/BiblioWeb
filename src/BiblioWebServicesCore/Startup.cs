﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using BiblioWebServicesCore.Model;
using BiblioWebServicesCore.Data;


namespace BiblioWebServicesCore
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            /* Add framework services. */
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddCors();

            // requires using Microsoft.EntityFrameworkCore;
            services.AddDbContext<BookContext>(options =>options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc();
            services.AddSingleton<IRepository, BookRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, BookContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors(builder => builder.WithOrigins("http://localhost:5050")
                .AllowAnyHeader()
                .AllowCredentials()
                .AllowAnyMethod());
            //app.UseApplicationInsightsRequestTelemetry();
            //app.UseApplicationInsightsExceptionTelemetry();
            app.UseMvc();
            DBInitializer.Initialize(context);
        }
    }
}
