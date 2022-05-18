using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.DTOs;
using System;
using System.Collections.Generic;
using BAL.Facades.DiagramsPageFacade;
using System.Linq;
using System.Threading.Tasks;
using BAL.Facades.UsersFacade;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersPageController : ControllerBase
    {

        private readonly ILogger<UsersPageController> _logger;
        private readonly IUsersPageFacade _usersPageFacade;

        public UsersPageController(ILogger<UsersPageController> logger, IUsersPageFacade usersPageFacade)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _usersPageFacade = usersPageFacade ?? throw new ArgumentNullException(nameof(usersPageFacade));
        }

        [HttpGet, Route("users")]
        public async Task<IEnumerable<UserBasicInfoDTO>> Get()
        {
            var result = await _usersPageFacade.GetAllUsers();
            return result;
        }
    }
}
