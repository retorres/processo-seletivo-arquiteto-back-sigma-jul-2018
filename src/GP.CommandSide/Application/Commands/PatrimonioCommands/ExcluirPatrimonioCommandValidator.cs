using FluentValidation;
using GP.CommandSide.Application.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.CommandSide.Application.Commands.PatrimonioCommands
{
    public class ExcluirPatrimonioCommandValidator : CommandValidator<ExcluirPatrimonioCommand>
    {
        public ExcluirPatrimonioCommandValidator()
        {
            RuleFor(r => r.TomboNumero).GreaterThan(0).WithMessage(CampoObrigatorio);
        }
    }
}
