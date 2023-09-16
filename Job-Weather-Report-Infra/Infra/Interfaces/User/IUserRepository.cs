using Job_Weather_Report_Infra.Infra.Entities;
using System.Collections.Generic;

namespace Job_Weather_Report_Infra.Infra.Interfaces.User
{
    public interface IUserRepository
    {
        IEnumerable<UserEntity> Get();
    }
}
