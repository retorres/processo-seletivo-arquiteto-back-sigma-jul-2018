using GP.CommandSide.Domain.Abstractions;

namespace GP.CommandSide.Domain.DomainEvents
{
    public class ModeloExcluido : IDomainEvent
    {
        public ModeloExcluido(long modeloId)
        {
            ModeloId = modeloId;
        }

        public long ModeloId { get; }
    }
}
