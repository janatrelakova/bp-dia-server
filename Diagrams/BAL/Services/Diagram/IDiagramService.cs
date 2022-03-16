using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services.Diagram
{
    public interface IDiagramService
    {
        Task<DiagramBasicInfoDTO> GetDiagramByIdAsync(Guid diagramId);
    }
}
