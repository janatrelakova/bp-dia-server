using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Repositories;
using Infrastructure.Query;
using Models.DTOs;
using Microsoft.Extensions.Logging;

namespace BAL.Services.Diagram
{
    public class NewDiagramService : Service<Models.Entities.Diagram, DiagramCreateDTO>, INewDiagramService
    {
        public NewDiagramService(
            IMapper mapper,
            IRepository<Models.Entities.Diagram> repository,
            IQuery<Models.Entities.Diagram> query,
            ILogger<Models.Entities.Diagram> logger)
            : base(mapper, repository, query, logger)
        {

        }

    }
}
