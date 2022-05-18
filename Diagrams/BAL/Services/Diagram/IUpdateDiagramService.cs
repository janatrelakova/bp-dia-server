using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services.Diagram
{
    public interface IUpdateDiagramService
    {
        Task UpdateAsync(DiagramUpdateDTO diagram);

        Task<Guid> GetByRoomNameAsync(string roomName);

        Task<string> GetRoomData(string roomName);

    }
}
