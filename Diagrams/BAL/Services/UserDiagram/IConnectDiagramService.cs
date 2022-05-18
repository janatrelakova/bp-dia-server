using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services.UserDiagram
{
    public interface IConnectDiagramService
    {

        Task<Guid> CreateAsync(NewDiagramDTO diagramDTO);
    }
}
