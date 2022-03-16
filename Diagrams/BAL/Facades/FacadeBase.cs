using AutoMapper;
using Infrastructure.UoW;
using System;

namespace BAL.Facades
{
    public abstract class FacadeBase
    {
        protected readonly IUnitOfWorkProvider UnitOfWorkProvider;

        protected readonly IMapper Mapper;

        protected FacadeBase(IUnitOfWorkProvider unitOfWorkProvider, IMapper mapper)
        {
            this.UnitOfWorkProvider = unitOfWorkProvider ?? throw new ArgumentNullException(nameof(unitOfWorkProvider));
            this.Mapper = mapper;
        }
    }
}
