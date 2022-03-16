using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public interface IService<TDto>
    {
        Task<TDto> GetAsync(Guid entityId);

        Task<Guid> CreateAsync(TDto entityDto);

        Task UpdateAsync(DTO entityDto);

        Task DeleteAsync(Guid entityID);
    }
}
