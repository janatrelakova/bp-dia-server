using AutoMapper;
using BAL.Services.Diagram;
using BAL.Services.User;
using BAL.Services.UserDiagram;
using Infrastructure.UoW;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Facades.UsersFacade
{
    public class UsersPageFacade : FacadeBase, IUsersPageFacade
    {
        private readonly IUserService _userService;

        public UsersPageFacade(
            IUnitOfWorkProvider uowProvider,
            IMapper mapper,
            IUserService userService) : base(uowProvider, mapper)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<IEnumerable<UserBasicInfoDTO>> GetAllUsers()
        {
            return await _userService.GetUsers();
        }
    }
}
