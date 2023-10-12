using Hangfire;
using Hangfire.MemoryStorage;
using Job_Weather_Report.Interfaces.Configcat;
using Job_Weather_Report.Interfaces.User;
using Job_Weather_Report.Interfaces.WeatherREport;
using Job_Weather_Report.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Job_Weather_Report
{
    public class Startup
    {
        private static IUserService _userService;
        private static IWeatherReportService _weatherReportService;
        private static IConfigcatService _configcatService;
        private readonly Job jobscheduler = new Job(_userService, _weatherReportService, _configcatService);
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Resolve();

            services.AddHangfire(op =>
            {
                op.UseMemoryStorage();
            });
            services.AddHangfireServer();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHangfireDashboard();
            RecurringJob.AddOrUpdate(() => jobscheduler.Execute(), Cron.Daily);
        }
    }
}
