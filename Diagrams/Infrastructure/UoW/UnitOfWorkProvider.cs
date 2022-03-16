using System.Threading;

namespace Infrastructure.UoW
{
    public abstract class UnitOfWorkProvider : IUnitOfWorkProvider
    {
        protected readonly AsyncLocal<IUnitOfWork> uowInstance = new();
        public abstract IUnitOfWork Create();

        public void Dispose()
        {
            uowInstance.Value?.Dispose();
            uowInstance.Value = null;
        }

        public IUnitOfWork GetUOWInstance()
        {
            if (uowInstance.Value == null)
            {
                uowInstance.Value = Create();
            }
            return uowInstance.Value;
        }
    }
}
