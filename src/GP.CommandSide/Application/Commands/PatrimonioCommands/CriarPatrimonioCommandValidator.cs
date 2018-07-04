using FluentValidation;
using GP.CommandSide.Application.Core;

namespace GP.CommandSide.Application.Commands.PatrimonioCommands
{
    public class CriarPatrimonioCommandValidator : CommandValidator<CriarPatrimonioCommand>
    {
        public CriarPatrimonioCommandValidator()
        {
            RuleFor(r => r.ModeloId).GreaterThan(0).WithMessage(CampoObrigatorio);
            RuleFor(r => r.Nome).NotEmpty().WithMessage(CampoObrigatorio);
        }
    }
}
