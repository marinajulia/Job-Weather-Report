using Job_Weather_Report.Interfaces.User;
using Job_Weather_Report.Interfaces.WeatherREport;
using Job_Weather_Report_Infra.Infra.Entities;
using System.Threading.Tasks;
using System;
using ConfigCat.Client;
using Job_Weather_Report.Interfaces.Configcat;

namespace Job_Weather_Report
{
    public class Job
    {
        private readonly IUserService _userService;
        private readonly IWeatherReportService _weatherReportService;
        private readonly IConfigcatService _configcatService;
        public Job(IUserService userService, IWeatherReportService weatherReportService, IConfigcatService configcatService)
        {
            _userService = userService;
            _weatherReportService = weatherReportService;
            _configcatService = configcatService;
        }
        public Task Execute()
        {
            if (!_configcatService.AuthorizeExecution())
            {
                //colocar log que esta desativado
                return Task.CompletedTask;
            }

            var userEntities = _userService.Get();
            foreach (var user in userEntities)
            {
                ProcessForecasts(user);
            }
            return Task.CompletedTask;
        }

        private async void ProcessForecasts(UserEntity user)
        {
            var weatherReport = await _weatherReportService.GetWeatherReport(user.IdCity.ToString());

            UserWeatherEntity userWeather = new UserWeatherEntity()
            {
                Name = user.Name,
                Email = user.Email,
                WeatherReport = new WeatherReportEntity()
                {
                    Cidade = weatherReport.Cidade,
                    estado = weatherReport.estado,
                    atualizado_em = weatherReport.atualizado_em,
                    clima = weatherReport.clima
                }
            };
            _weatherReportService.PostWeather(userWeather);

            Console.WriteLine(userWeather);
        }
    }
}
