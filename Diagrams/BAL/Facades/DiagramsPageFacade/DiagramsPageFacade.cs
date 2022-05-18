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

namespace BAL.Facades.DiagramsPageFacade
{
    public class DiagramsPageFacade : FacadeBase, IDiagramsPageFacade
    {

        private readonly IUserDiagramService _userDiagramService;
        private readonly IDiagramService _diagramService;
        private readonly INewDiagramService _newDiagramService;
        private readonly IUpdateDiagramService _updateService;
        private readonly IConnectDiagramService _connectService;

        public DiagramsPageFacade(
            IUnitOfWorkProvider uowProvider,
            IMapper mapper,
            IUserDiagramService userDiagramService,
            IDiagramService diagramService,
            INewDiagramService newDiagramService,
            IUpdateDiagramService updateService,
            IConnectDiagramService connectService) : base(uowProvider, mapper)
        {
            _userDiagramService = userDiagramService ?? throw new ArgumentNullException(nameof(userDiagramService));
            _diagramService = diagramService ?? throw new ArgumentNullException(nameof(diagramService));
            _connectService = connectService ?? throw new ArgumentNullException(nameof(connectService));
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _newDiagramService = newDiagramService ?? throw new ArgumentNullException(nameof(newDiagramService));
        }


        public async Task<IEnumerable<DiagramBasicInfoDTO>> GetDiagramsByUserId(Guid userId)
        {
            var userDiagrams = await _userDiagramService.GetAllDiagramsByUserIdAsync(userId);
            var result = new List<DiagramBasicInfoDTO>();
            foreach (var userDiagram in userDiagrams)
            {
                result.Add(await _diagramService.GetDiagramByIdAsync(userDiagram.Id));
            }
            return result;
        }


        public async Task<IEnumerable<DiagramBasicInfoDTO>> GetAllDiagrams()
        {
            var userDiagrams = await _diagramService.GetAllDiagrams();
            var result = new List<DiagramBasicInfoDTO>();
            foreach (var userDiagram in userDiagrams)
            {
                result.Add(userDiagram);
            }
            return result;
        }

        public async Task<bool> CreateDiagram(ConnectionDTO diagramDTO) 
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var newDiagram = await _newDiagramService.CreateAsync(
                new DiagramCreateDTO
                {
                    Room = diagramDTO.Room,
                    Data = "",
                });

                await _connectService.CreateAsync(new NewDiagramDTO
                {
                    UserId = diagramDTO.UserId,
                    DiagramId = newDiagram,
                });

                await uow.CommitAsync();
                return true;
            }
        }

        public async Task<bool> ConnectDiagram(ConnectionDTO diagramDTO)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var diagramId = await _updateService.GetByRoomNameAsync(diagramDTO.Room);

                await _connectService.CreateAsync(new NewDiagramDTO
                {
                    UserId = diagramDTO.UserId,
                    DiagramId = diagramId,
                });

                await uow.CommitAsync();
                return true;
            }
        }
    }
}
