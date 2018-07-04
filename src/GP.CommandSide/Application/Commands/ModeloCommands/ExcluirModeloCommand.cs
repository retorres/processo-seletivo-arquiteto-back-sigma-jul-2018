using GP.CommandSide.Application.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace GP.CommandSide.Application.Commands.ModeloCommands
{
    public class ExcluirModeloCommand : ICommand
    {
        public ExcluirModeloCommand(long modeloId)
        {
            ModeloId = modeloId;
        }

        public long ModeloId { get; }
    }
}
