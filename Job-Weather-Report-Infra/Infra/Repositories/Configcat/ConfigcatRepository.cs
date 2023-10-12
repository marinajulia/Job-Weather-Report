using ConfigCat.Client;
using Job_Weather_Report_Infra.Infra.Interfaces.IConfigcatRepository;
using Microsoft.Extensions.Configuration;

namespace Job_Weather_Report_Infra.Infra.Repositories.Configcat
{
    public class ConfigcatRepository : IConfigcatRepository
    {
        private readonly IConfiguration _configuration;

        public ConfigcatRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool AuthorizeExecution()
        {
            var key = _configuration.GetConnectionString("configcat");
            var client = ConfigCatClient.Get(key);
            return client.GetValue("JOBWEATHERREPORT", false);
        }
    }
}
