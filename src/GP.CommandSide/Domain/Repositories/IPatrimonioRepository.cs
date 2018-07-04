using GP.CommandSide.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GP.CommandSide.Domain.Repositories
{
    public interface IPatrimonioRepository : IRepository<Patrimonio>
    {
        Task<Patrimonio> ObterPorIdAsync(long id);
        Task IncluirAsync(Patrimonio aggregateRoot);
        Task ExcluirAsync(Patrimonio aggregateRoot);
    }
}
