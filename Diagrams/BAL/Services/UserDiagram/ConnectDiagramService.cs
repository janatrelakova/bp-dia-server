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
    public class ConnectDiagramService : Service<Models.Entities.UserDiagram, NewDiagramDTO>, IConnectDiagramService
    {
        public ConnectDiagramService(
            IMapper mapper,
            IRepository<Models.Entities.UserDiagram> repository,
            IQuery<Models.Entities.UserDiagram> query,
            ILogger<Models.Entities.UserDiagram> logger)
            : base(mapper, repository, query, logger)
        {

        }


    }
}
