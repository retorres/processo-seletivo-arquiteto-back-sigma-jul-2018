using GP.CommandSide.Domain.Abstractions;

namespace GP.CommandSide.Domain.Repositories
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
    {
    }
}
