using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Repositories;
using Infrastructure.Query;
using Models.DTOs;

namespace BAL.Services.UserDiagram
{
    public interface IUserDiagramService 
    {
        Task<ICollection<UserDiagramsPageDTO>> GetAllDiagramsByUserIdAsync(Guid userId);
    }
}
