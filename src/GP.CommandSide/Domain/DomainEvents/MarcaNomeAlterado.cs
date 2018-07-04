using GP.CommandSide.Domain.Abstractions;

namespace GP.CommandSide.Domain.DomainEvents
{
    public class MarcaNomeAlterado : IDomainEvent
    {
        private long marcaId;
        private string nome;

        public MarcaNomeAlterado(long marcaId, string nome)
        {
            this.marcaId = marcaId;
            this.nome = nome;
        }
    }
}