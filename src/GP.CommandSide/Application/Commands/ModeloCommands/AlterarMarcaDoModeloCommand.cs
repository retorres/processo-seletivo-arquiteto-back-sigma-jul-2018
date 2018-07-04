using GP.CommandSide.Application.Core;

namespace GP.CommandSide.Application.Commands.ModeloCommands
{
    public class AlterarMarcaDoModeloCommand : ICommand
    {
        public AlterarMarcaDoModeloCommand(long modeloId, long marcaId)
        {
            ModeloId = modeloId;
            MarcaId = marcaId;
        }

        public long ModeloId { get; }
        public long MarcaId { get; }
    }
}
