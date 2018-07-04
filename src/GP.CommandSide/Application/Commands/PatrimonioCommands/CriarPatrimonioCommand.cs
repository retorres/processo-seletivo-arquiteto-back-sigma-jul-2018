using GP.CommandSide.Application.Core;

namespace GP.CommandSide.Application.Commands.PatrimonioCommands
{
    public class CriarPatrimonioCommand : ICommand<long>
    {
        public CriarPatrimonioCommand(long modeloId, string nome, string descricao)
        {
            ModeloId = modeloId;
            Nome = nome;
            Descricao = descricao;
        }

        public long ModeloId { get; }
        public string Nome { get; }
        public string Descricao { get; }
    }
}
