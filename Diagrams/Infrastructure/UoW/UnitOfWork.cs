using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UoW
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        private readonly IList<Action> afterCommitActions = new List<Action>();

        public async Task CommitAsync()
        {
            await CommitCoreAsync();
            foreach (var action in afterCommitActions)
            {
                action();
            }
            afterCommitActions.Clear();
        }

        public void RegisterAction(Action action)
        {
            afterCommitActions.Add(action);
        }

        public abstract void Dispose();

        public abstract Task CommitCoreAsync();
    }
}
