using System;
using System.Threading;
using System.Threading.Tasks;

namespace GP.CommandSide.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
