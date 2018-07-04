using GP.CommandSide.Application.Core;

namespace GP.CommandSide.Application.Commands.MarcaCommands
{
    public class AlterarNomeDaMarcaCommand : ICommand
    {
        public AlterarNomeDaMarcaCommand(long marcaId, string nome)
        {
            MarcaId = marcaId;
            Nome = nome;
        }

        public long MarcaId { get; }
        public string Nome { get; }
    }
}
