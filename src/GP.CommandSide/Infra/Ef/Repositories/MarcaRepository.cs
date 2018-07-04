using GP.CommandSide.Domain.Entities;
using GP.CommandSide.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GP.CommandSide.Infra.Ef.Repositories
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly AppDbContext _dbContext;

        public MarcaRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task ExcluirAsync(Marca aggregateRoot)
        {
            _dbContext.Marcas.Remove(aggregateRoot);

            return Task.CompletedTask;
        }

        public async Task IncluirAsync(Marca aggregateRoot)
        {
            await _dbContext.Marcas.AddAsync(aggregateRoot);
        }

        public async Task<Marca> ObterPorIdAsync(long id)
        {
            return await _dbContext.Marcas
                                    .Include(r => r.Modelos)
                                    .FirstOrDefaultAsync(q => q.MarcaId == id);
        }

        public async Task<Marca> ObterPorNomeAsync(string nome)
        {
            var marca = await _dbContext.Marcas
                                    .Include(d => d.Modelos)
                                    .FirstOrDefaultAsync(d => d.Nome == nome);

            return marca;
        }
    }
}
