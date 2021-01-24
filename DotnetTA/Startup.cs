using DotnetTA.Repositories;
using DotnetTA.Repositories.Interfaces;
using DotnetTA.Services;
using DotnetTA.Services.Interfaces;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Reflection;

namespace DotnetTA
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
            var connectionString = Environment.GetEnvironmentVariable("CONNECTIONSTRING");
            //services.AddControllers();
            services.AddScoped<ITickerInfoRepository>(_ => new TickerInfoRepository(connectionString));
            services.AddScoped<ITechnicalAnalysisRepository>(_ => new TechnicalAnalysisRepository(connectionString));
            services.AddScoped<ITickerInfoService, TickerInfoService>();
            services.AddScoped<ITechnicalAnalysisService, TechnicalAnalysisService>();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            app.UseRouting();
            app.UseStaticFiles();
            app.UseSerilogRequestLogging();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
