using GP.CommandSide.Application.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace GP.CommandSide.Application.Commands.PatrimonioCommands
{
    public class ExcluirPatrimonioCommand : ICommand
    {
        public ExcluirPatrimonioCommand(long tomboNumero)
        {
            TomboNumero = tomboNumero;
        }

        public long TomboNumero { get; }
    }
}
