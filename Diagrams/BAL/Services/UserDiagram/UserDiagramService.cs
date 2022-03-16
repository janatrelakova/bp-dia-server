using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Repositories;
using Infrastructure.Query;
using Models.DTOs;
using Microsoft.Extensions.Logging;

namespace BAL.Services.UserDiagram
{
    public class UserDiagramService : Service<Models.Entities.UserDiagram, UserDiagramsPageDTO>, IUserDiagramService
    {
        public UserDiagramService(
            IMapper mapper,
            IRepository<Models.Entities.UserDiagram> repository,
            IQuery<Models.Entities.UserDiagram> query,
            ILogger<Models.Entities.UserDiagram> logger) 
            : base(mapper, repository, query, logger)
        {
        
        }

        public async Task<ICollection<UserDiagramsPageDTO>> GetAllDiagramsByUserIdAsync(Guid userId)
        {
            if (userId.Equals(Guid.Empty))
            {
                throw new ArgumentException("Provided Guid was empty.", nameof(userId));
            }    
            var diagrams = await _query.GetSetAsync();
            var result = diagrams.FindAll(x => x.UserId == userId);
            return _mapper.Map<List<UserDiagramsPageDTO>>(result);
        }

    }
}
