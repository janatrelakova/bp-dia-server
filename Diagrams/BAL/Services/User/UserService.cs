using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Repositories;
using Infrastructure.Query;
using Models.DTOs;
using Microsoft.Extensions.Logging;

namespace BAL.Services.User
{
    public class UserService : Service<Models.Entities.User, UserBasicInfoDTO>, IUserService
    {
        public UserService(
            IMapper mapper,
            IRepository<Models.Entities.User> repository,
            IQuery<Models.Entities.User> query,
            ILogger<Models.Entities.User> logger)
            : base(mapper, repository, query, logger)
        {

        }

        public async Task<ICollection<UserBasicInfoDTO>> GetUsers()
        {
            var users = await _query.GetSetAsync();
            return _mapper.Map<List<UserBasicInfoDTO>>(users);
        }

    }
}
