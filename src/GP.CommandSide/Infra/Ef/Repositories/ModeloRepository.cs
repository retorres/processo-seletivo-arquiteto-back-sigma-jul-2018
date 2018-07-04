using GP.CommandSide.Domain.Entities;
using GP.CommandSide.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GP.CommandSide.Infra.Ef.Repositories
{
    public class ModeloRepository : IModeloRepository
    {
        private readonly AppDbContext _dbContext;

        public ModeloRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task ExcluirAsync(Modelo aggregateRoot)
        {
            _dbContext.Modelos.Remove(aggregateRoot);

            return Task.CompletedTask;
        }

        public async Task IncluirAsync(Modelo aggregateRoot)
        {
            await _dbContext.Modelos.AddAsync(aggregateRoot);
        }

        public async Task<bool> ModeloPossuiPatrimonio(long modeloId)
        {
            return await _dbContext.Patrimonios.AnyAsync(d => d.ModeloId == modeloId);
        }

        public async Task<Modelo> ObterPorIdAsync(long id)
        {
            return await _dbContext
                            .Modelos
                            .Include(q => q.Marca)
                            .ThenInclude(q => q.Modelos)
                            .FirstOrDefaultAsync(q => q.ModeloId == id);
        }

        public async Task<Modelo> ObterPorNomeAsync(string nome)
        {
            var modelo = await _dbContext.Modelos
                                   .FirstOrDefaultAsync(d => d.Nome == nome);

            return modelo;
        }
    }
}
