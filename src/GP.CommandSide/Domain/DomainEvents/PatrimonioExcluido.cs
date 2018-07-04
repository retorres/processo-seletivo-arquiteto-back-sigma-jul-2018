using GP.CommandSide.Domain.Abstractions;

namespace GP.CommandSide.Domain.DomainEvents
{
    public class PatrimonioExcluido : IDomainEvent
    {
        public PatrimonioExcluido(long tomboNumero)
        {
            TomboNumero = tomboNumero;
        }

        public long TomboNumero { get; }
    }
}