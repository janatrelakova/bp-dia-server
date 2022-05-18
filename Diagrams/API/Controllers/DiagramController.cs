using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.DTOs;
using System;
using System.Collections.Generic;
using BAL.Facades.DiagramsPageFacade;
using System.Linq;
using System.Threading.Tasks;
using BAL.Facades.DiagramFacade;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiagramController : ControllerBase
    {

        private readonly ILogger<DiagramsPageController> _logger;
        private readonly IDiagramFacade _diagramFacade;

        public DiagramController(ILogger<DiagramsPageController> logger, IDiagramFacade diagramFacade)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _diagramFacade = diagramFacade ?? throw new ArgumentNullException(nameof(diagramFacade));
        }

        [HttpPost, Route("diagram")]
        public async Task Update([FromBody] DiagramUpdateDTO diagram)
        {
            var d = await _diagramFacade.GetByRoomNameAsync(diagram.Room);
            diagram.Id = d;
            await _diagramFacade.UpdateAsync(diagram);
        }

        [HttpGet, Route("diagram")]
        public async Task<string> Get(string room)
        {
            return await _diagramFacade.GetDataByRoom(room);
        }

    }
}
