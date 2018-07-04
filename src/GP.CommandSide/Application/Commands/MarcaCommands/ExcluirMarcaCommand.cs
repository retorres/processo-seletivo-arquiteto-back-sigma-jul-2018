using GP.CommandSide.Application.Core;

namespace GP.CommandSide.Application.Commands.MarcaCommands
{
    public class ExcluirMarcaCommand : ICommand
    {
        public ExcluirMarcaCommand(long marcaId)
        {
            MarcaId = marcaId;
        }

        public long MarcaId { get; }
    }
}
