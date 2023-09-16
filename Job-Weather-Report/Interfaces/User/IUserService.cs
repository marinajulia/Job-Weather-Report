using Job_Weather_Report_Infra.Infra.Entities;
using System.Collections.Generic;

namespace Job_Weather_Report.Interfaces.User
{
    public interface IUserService
    {
        IEnumerable<UserEntity> Get();
    }
}
