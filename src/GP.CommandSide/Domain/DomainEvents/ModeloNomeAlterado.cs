using GP.CommandSide.Domain.Abstractions;

namespace GP.CommandSide.Domain.DomainEvents
{
    public class ModeloNomeAlterado : IDomainEvent
    {
        private long modeloId;
        private string nome;

        public ModeloNomeAlterado(long modeloId, string nome)
        {
            this.modeloId = modeloId;
            this.nome = nome;
        }
    }
}