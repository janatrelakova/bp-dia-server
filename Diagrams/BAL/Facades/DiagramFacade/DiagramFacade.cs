using AutoMapper;
using BAL.Services.Diagram;
using BAL.Services.UserDiagram;
using Infrastructure.UoW;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BAL.Facades.DiagramFacade
{
    public class DiagramFacade : FacadeBase, IDiagramFacade
    {

        private readonly IUpdateDiagramService _updateService;

        public DiagramFacade(
            IUnitOfWorkProvider uowProvider,
            IMapper mapper,
            IUpdateDiagramService updateService) : base(uowProvider, mapper)
        {
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
        }

        public async Task<Guid> GetByRoomNameAsync(string roomName)
        {
            return await _updateService.GetByRoomNameAsync(roomName);
        }

        public async Task<string> GetDataByRoom(string roomName)
        {
            return await _updateService.GetRoomData(roomName);
        }

        public async Task UpdateAsync(DiagramUpdateDTO diagram)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                await _updateService.UpdateAsync(diagram);

                await uow.CommitAsync();
            }

        }
    }
}
