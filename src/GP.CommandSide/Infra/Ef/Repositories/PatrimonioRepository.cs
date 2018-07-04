using GP.CommandSide.Domain.Entities;
using GP.CommandSide.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GP.CommandSide.Infra.Ef.Repositories
{
    public class PatrimonioRepository : IPatrimonioRepository
    {
        private readonly AppDbContext _dbContext;

        public PatrimonioRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task ExcluirAsync(Patrimonio aggregateRoot)
        {
            _dbContext.Patrimonios.Remove(aggregateRoot);

            return Task.CompletedTask;
        }

        public async Task IncluirAsync(Patrimonio aggregateRoot)
        {
            await _dbContext.Patrimonios.AddAsync(aggregateRoot);
        }

        public async Task<Patrimonio> ObterPorIdAsync(long id)
        {
            return await _dbContext.Patrimonios
                                   .Include(r => r.Modelo)
                                   .ThenInclude(r => r.Marca)
                                   .FirstOrDefaultAsync(q => q.TomboNumero == id);
        }
    }
}
