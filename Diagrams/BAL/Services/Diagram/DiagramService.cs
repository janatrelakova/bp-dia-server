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
    public class DiagramService : Service<Models.Entities.Diagram, DiagramBasicInfoDTO>, IDiagramService
    {
        public DiagramService(
            IMapper mapper,
            IRepository<Models.Entities.Diagram> repository,
            IQuery<Models.Entities.Diagram> query,
            ILogger<Models.Entities.Diagram> logger)
            : base(mapper, repository, query, logger)
        {

        }

        public async Task<DiagramBasicInfoDTO> GetDiagramByIdAsync(Guid diagramId)
        {
            if (diagramId.Equals(Guid.Empty))
            {
                throw new ArgumentException("Provided Guid was null.", nameof(diagramId));
            }
            var allDiagrams = await _query.GetSetAsync();
            var result = allDiagrams.Find(d => d.Id == diagramId);
            if (result == null)
            {
                _logger.LogWarning($"No diagram with provided ID {diagramId} was found.");
                return null;
            }
            return _mapper.Map<DiagramBasicInfoDTO>(result);

        }

        public async Task<ICollection<DiagramBasicInfoDTO>> GetAllDiagrams()
        {

            var allDiagrams = await _query.GetSetAsync();
            return _mapper.Map<List<DiagramBasicInfoDTO>>(allDiagrams);

        }

    }
}
