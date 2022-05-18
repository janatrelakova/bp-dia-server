using AutoMapper;
using Infrastructure.Repositories;
using Infrastructure.Query;
using Models.DTOs;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace BAL.Services.Diagram
{
    public class UpdateDiagramService : Service<Models.Entities.Diagram, DiagramUpdateDTO>, IUpdateDiagramService
    {
        public UpdateDiagramService(
            IMapper mapper,
            IRepository<Models.Entities.Diagram> repository,
            IQuery<Models.Entities.Diagram> query,
            ILogger<Models.Entities.Diagram> logger)
            : base(mapper, repository, query, logger)
        {

        }

        public async Task UpdateAsync(DiagramUpdateDTO diagram)
        {
            await base.UpdateAsync(diagram);
        }

        public async Task<Guid> GetByRoomNameAsync(string roomName)
        {
            var diagrams = await _query.GetSetAsync();
            return diagrams.Where(d => d.Room == roomName).Select(d => d.Id).First();
        }

        public async Task<string> GetRoomData(string roomName)
        {
            var diagrams = await _query.GetSetAsync();
            return diagrams.Where(d => d.Room == roomName).First().Data;
        }
    }
}
