using GP.CommandSide.Domain.Abstractions;

namespace GP.CommandSide.Domain.DomainEvents
{
    public class MarcaExcluida : IDomainEvent
    {
        private readonly long marcaId;

        public MarcaExcluida(long marcaId)
        {
            this.marcaId = marcaId;
        }
    }
}
