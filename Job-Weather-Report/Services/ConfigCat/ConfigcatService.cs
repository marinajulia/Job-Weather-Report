using Job_Weather_Report.Interfaces.Configcat;
using Job_Weather_Report_Infra.Infra.Interfaces.IConfigcatRepository;

namespace Job_Weather_Report.Services.ConfigCat
{
    public class ConfigcatService : IConfigcatService
    {
        private readonly IConfigcatRepository _configcatRepository;
        public ConfigcatService(IConfigcatRepository configcatRepository)
        {
            _configcatRepository = configcatRepository;
        }
        public bool AuthorizeExecution()
        {
            return _configcatRepository.AuthorizeExecution();
        }
    }
}
