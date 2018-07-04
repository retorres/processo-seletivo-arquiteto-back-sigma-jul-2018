using GP.CommandSide.Application.Core;

namespace GP.CommandSide.Application.Commands.MarcaCommands
{
    public class CriarMarcaCommand : ICommand<long>
    {
        public CriarMarcaCommand(string nome) => Nome = nome;

        public string Nome { get; }

    }
}
