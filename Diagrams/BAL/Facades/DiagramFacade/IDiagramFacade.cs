using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Facades.DiagramFacade
{
    public interface IDiagramFacade
    {
        Task<Guid> GetByRoomNameAsync(string roomName);
        Task UpdateAsync(DiagramUpdateDTO diagram);
        Task<string> GetDataByRoom(string roomName);
    }
}
