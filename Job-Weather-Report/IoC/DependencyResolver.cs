using Job_Weather_Report.Interfaces.Configcat;
using Job_Weather_Report.Interfaces.User;
using Job_Weather_Report.Interfaces.WeatherREport;
using Job_Weather_Report.Services.ConfigCat;
using Job_Weather_Report.Services.User;
using Job_Weather_Report.Services.WeatherReport;
using Job_Weather_Report_Infra.Infra.Data;
using Job_Weather_Report_Infra.Infra.Interfaces.IConfigcatRepository;
using Job_Weather_Report_Infra.Infra.Interfaces.User;
using Job_Weather_Report_Infra.Infra.Interfaces.WeatherReport;
using Job_Weather_Report_Infra.Infra.Repositories.Configcat;
using Job_Weather_Report_Infra.Infra.Repositories.User;
using Job_Weather_Report_Infra.Infra.Repositories.WeatherReport;
using Microsoft.Extensions.DependencyInjection;

namespace Job_Weather_Report.IoC
{
    public static class DependencyResolver
    {
        public static void Resolve(this IServiceCollection services)
        {
            //var mappingConfig = new MapperConfiguration(m =>
            //{
            //    m.AddProfile(new AutoMapperProfile());
            //});

            //var mapper = mappingConfig.CreateMapper();
            //services.AddSingleton(mapper);

            services.AddDbContext<ApplicationContext>();

            Context(services);
            Repositories(services);
            Services(services);
        }
        public static void Context(IServiceCollection services)
        {
            services.AddScoped<ApplicationContext, ApplicationContext>();
        }
        public static void Repositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IConfigcatRepository, ConfigcatRepository>();
            services.AddScoped<IWeatherReportRepository, WeatherReportRepository>();
        }
        public static void Services(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IConfigcatService, ConfigcatService>();
            services.AddScoped<IWeatherReportService, WeatherReportService>();
        }
    }
}
