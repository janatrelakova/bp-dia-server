using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        Task Commit();

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        Task CommitCore();

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="action"></param>
        void RegisterAction(Action action);
    }
}
