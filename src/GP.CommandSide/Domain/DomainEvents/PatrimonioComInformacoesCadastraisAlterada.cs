using GP.CommandSide.Domain.Abstractions;

namespace GP.CommandSide.Domain.DomainEvents
{
    public class PatrimonioComInformacoesCadastraisAlterada : IDomainEvent
    {

        public PatrimonioComInformacoesCadastraisAlterada(long tomboNumero, string nome, string descricao)
        {
            TomboNumero = tomboNumero;
            Nome = nome;
            Descricao = descricao;
        }

        public long TomboNumero { get; }
        public string Nome { get; }
        public string Descricao { get; }
    }
}