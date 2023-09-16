using Job_Weather_Report_Infra.Infra.Data;
using Job_Weather_Report_Infra.Infra.Entities;
using Job_Weather_Report_Infra.Infra.Interfaces.User;
using System.Collections.Generic;
using System.Linq;

namespace Job_Weather_Report_Infra.Infra.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<UserEntity> Get()
        {
            var user = _context.User;
            return user.ToList();
        }
    }
}
