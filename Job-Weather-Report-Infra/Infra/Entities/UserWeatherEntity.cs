namespace Job_Weather_Report_Infra.Infra.Entities
{
    public class UserWeatherEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public WeatherReportEntity? WeatherReport { get; set; }
    }
}
