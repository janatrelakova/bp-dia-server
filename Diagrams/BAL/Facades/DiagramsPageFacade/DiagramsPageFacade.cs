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

        public DiagramsPageFacade(
            IUnitOfWorkProvider uowProvider,
            IMapper mapper,
            IUserDiagramService userDiagramService,
            IDiagramService diagramService) : base(uowProvider, mapper) 
        {
            _userDiagramService = userDiagramService ?? throw new ArgumentNullException(nameof(userDiagramService));
            _diagramService = diagramService ?? throw new ArgumentNullException(nameof(diagramService));
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

    }
}
