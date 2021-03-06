using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Facades.DiagramsPageFacade
{
    public interface IDiagramsPageFacade
    {
        Task<IEnumerable<DiagramBasicInfoDTO>> GetDiagramsByUserId(Guid userId);

        Task<IEnumerable<DiagramBasicInfoDTO>> GetAllDiagrams();

        Task<bool> CreateDiagram(ConnectionDTO diagramDTO);

        Task<bool> ConnectDiagram(ConnectionDTO diagramDTO);
    }
}
