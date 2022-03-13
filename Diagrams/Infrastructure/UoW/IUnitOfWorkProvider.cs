using System;

namespace Infrastructure.UoW
{
    public interface IUnitOfWorkProvider : IDisposable
    {
        IUnitOfWork Create();
        IUnitOfWork GetUOWInstance();
    }
}
