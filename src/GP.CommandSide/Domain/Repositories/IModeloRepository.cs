using GP.CommandSide.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GP.CommandSide.Domain.Repositories
{
    public interface IModeloRepository : IRepository<Modelo>
    {
        Task<Modelo> ObterPorIdAsync(long id);
        Task IncluirAsync(Modelo aggregateRoot);
        Task ExcluirAsync(Modelo aggregateRoot);
        Task<Modelo> ObterPorNomeAsync(string nome);

        Task<bool> ModeloPossuiPatrimonio(long modeloId);
    }
}
