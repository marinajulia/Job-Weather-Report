using Job_Weather_Report_Infra.Infra.Entities;
using Job_Weather_Report_Infra.Infra.Interfaces.WeatherReport;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Job_Weather_Report_Infra.Infra.Repositories.WeatherReport
{
    public class WeatherReportRepository : IWeatherReportRepository
    {
        public async Task<WeatherReportEntity> GetWeatherReport(string cityId)
        {
            using (HttpClient client = new HttpClient())
            {
                //colocar para receber o Id
                //tratar caso dê erro 400
                HttpResponseMessage response = await client.GetAsync($"https://brasilapi.com.br/api/cptec/v1/clima/previsao/4750/1");
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                WeatherReportEntity? weatherReport = JsonConvert.DeserializeObject<WeatherReportEntity>(responseBody);

                return weatherReport;
            }
        }

        public void PostWeather(UserWeatherEntity weatherReport)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "WeatherReport",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = JsonConvert.SerializeObject(weatherReport);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "WeatherReport",
                                     basicProperties: null,
                                     body: body);

                Console.WriteLine($"[x] Enviada: {message}");
            }
        }
    }
}
