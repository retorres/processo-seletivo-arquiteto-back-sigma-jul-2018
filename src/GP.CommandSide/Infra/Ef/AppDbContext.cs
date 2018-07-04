using GP.CommandSide.Domain;
using GP.CommandSide.Domain.Entities;
using GP.CommandSide.Infra.Ef.Maps;
using GP.CommandSide.Infra.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace GP.CommandSide.Infra.Ef
{
    public class AppDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;

        static AppDbContext()
        {
        }

        public AppDbContext(
             DbContextOptions<AppDbContext> options,
             IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<Marca> Marcas { get; private set; }
        public DbSet<Modelo> Modelos { get; private set; }
        public DbSet<Patrimonio> Patrimonios { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new MarcaMap().Configure(modelBuilder.Entity<Marca>());
            new ModeloMap().Configure(modelBuilder.Entity<Modelo>());
            new PatrimonioMap().Configure(modelBuilder.Entity<Patrimonio>());

            base.OnModelCreating(modelBuilder);
        }


        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await _mediator.DispatchDomainEventsAsync(this);

            var result = await base.SaveChangesAsync();

            return true;
        }
    }
}
