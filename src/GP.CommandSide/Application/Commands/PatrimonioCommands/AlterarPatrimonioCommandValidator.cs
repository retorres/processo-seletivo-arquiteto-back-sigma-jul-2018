using FluentValidation;
using GP.CommandSide.Application.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.CommandSide.Application.Commands.PatrimonioCommands
{
    public class AlterarPatrimonioCommandValidator : CommandValidator<AlterarPatrimonioCommand>
    {
        public AlterarPatrimonioCommandValidator()
        {
            RuleFor(r => r.TomboNumero).GreaterThan(0).WithMessage(CampoObrigatorio);
            RuleFor(r => r.Nome).NotEmpty().WithMessage(CampoObrigatorio);
            RuleFor(r => r.Descricao).NotEmpty().WithMessage(CampoObrigatorio);
        }
    }
}
