using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.DTOs;
using System;
using System.Collections.Generic;
using BAL.Facades.DiagramsPageFacade;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiagramsPageController : ControllerBase
    {

        private readonly ILogger<DiagramsPageController> _logger;
        private readonly IDiagramsPageFacade _diagramsPageFacade;

        public DiagramsPageController(ILogger<DiagramsPageController> logger, IDiagramsPageFacade diagramsPageFacade)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _diagramsPageFacade = diagramsPageFacade ?? throw new ArgumentNullException(nameof(diagramsPageFacade));
        }

        [HttpGet, Route("diagrams")]
        public async Task<IEnumerable<DiagramBasicInfoDTO>> Get(Guid userId)
        {
            return await _diagramsPageFacade.GetDiagramsByUserId(userId);
        }

        [HttpPost, Route("new")]
        public async Task<bool> CreateDiagram([FromBody] ConnectionDTO diagramDTO)
        {
            return await _diagramsPageFacade.CreateDiagram(diagramDTO);
        }

        [HttpPost, Route("connect")]
        public async Task<bool> ConnectDiagram([FromBody] ConnectionDTO diagramDTO)
        {
            return await _diagramsPageFacade.ConnectDiagram(diagramDTO);
        }

        [HttpGet, Route("all")]
        public async Task<IEnumerable<DiagramBasicInfoDTO>> GetAllDiagrams()
        {
            return await _diagramsPageFacade.GetAllDiagrams();
        }

    }
}
