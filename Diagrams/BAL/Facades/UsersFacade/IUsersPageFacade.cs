using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Facades.UsersFacade
{
    public interface IUsersPageFacade
    {
        Task<IEnumerable<UserBasicInfoDTO>> GetAllUsers();
    }
}
