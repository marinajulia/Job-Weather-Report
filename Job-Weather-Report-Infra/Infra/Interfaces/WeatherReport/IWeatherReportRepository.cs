using Job_Weather_Report_Infra.Infra.Entities;
using System.Threading.Tasks;

namespace Job_Weather_Report_Infra.Infra.Interfaces.WeatherReport
{
    public interface IWeatherReportRepository
    {
        Task<WeatherReportEntity> GetWeatherReport(string cityId);
        void PostWeather(UserWeatherEntity weatherReport);
    }
}
