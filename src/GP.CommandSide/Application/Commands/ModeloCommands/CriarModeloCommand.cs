using GP.CommandSide.Application.Core;

namespace GP.CommandSide.Application.Commands.ModeloCommands
{
    public class CriarModeloCommand : ICommand<long>
    {
        public CriarModeloCommand(long marcaId, string nome)
        {
            MarcaId = marcaId;
            Nome = nome;
        }

        public long MarcaId { get; }
        public string Nome { get; }
    }
}
