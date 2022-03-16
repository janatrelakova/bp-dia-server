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
            // "5461aa1b-7238-4cc7-bc20-eb5314f490b6"
            return await _diagramsPageFacade.GetDiagramsByUserId(userId);
        }
    }
}
