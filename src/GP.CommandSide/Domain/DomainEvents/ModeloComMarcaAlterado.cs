using GP.CommandSide.Domain.Abstractions;

namespace GP.CommandSide.Domain.DomainEvents
{
    public class ModeloComMarcaAlterado : IDomainEvent
    {

        public ModeloComMarcaAlterado(long modeloId, long marcaId)
        {
            ModeloId = modeloId;
            MarcaId = marcaId;
        }

        public long ModeloId { get; }
        public long MarcaId { get; }
    }
}