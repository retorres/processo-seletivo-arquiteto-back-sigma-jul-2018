using GP.CommandSide.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GP.CommandSide.Domain.Repositories
{
    public interface IMarcaRepository : IRepository<Marca>
    {
        Task<Marca> ObterPorIdAsync(long id);
        Task IncluirAsync(Marca aggregateRoot);
        Task ExcluirAsync(Marca aggregateRoot);
        Task<Marca> ObterPorNomeAsync(string nome);
    }
}
