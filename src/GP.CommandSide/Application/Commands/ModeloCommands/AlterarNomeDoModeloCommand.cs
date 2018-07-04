using GP.CommandSide.Application.Core;

namespace GP.CommandSide.Application.Commands.ModeloCommands
{
    public class AlterarNomeDoModeloCommand : ICommand
    {
        public AlterarNomeDoModeloCommand(long modeloId, string nome)
        {
            ModeloId = modeloId;
            Nome = nome;
        }

        public long ModeloId { get; }
        public string Nome { get; }
    }
}
