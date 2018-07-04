using GP.CommandSide.Application.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace GP.CommandSide.Application.Commands.PatrimonioCommands
{
    public class AlterarPatrimonioCommand : ICommand
    {
        public AlterarPatrimonioCommand(long tomboNumero, string nome, string descricao)
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
