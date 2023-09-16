using Job_Weather_Report.Interfaces.User;
using Job_Weather_Report_Infra.Infra.Entities;
using Job_Weather_Report_Infra.Infra.Interfaces.User;
using System.Collections.Generic;

namespace Job_Weather_Report.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UserEntity> Get()
        {
            return _userRepository.Get();
        }
    }
}
