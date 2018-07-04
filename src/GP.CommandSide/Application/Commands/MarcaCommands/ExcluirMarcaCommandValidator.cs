using FluentValidation;
using GP.CommandSide.Application.Core;

namespace GP.CommandSide.Application.Commands.MarcaCommands
{
    public class ExcluirMarcaCommandValidator : CommandValidator<ExcluirMarcaCommand>
    {
        public ExcluirMarcaCommandValidator()
        {
            RuleFor(r => r.MarcaId).GreaterThan(0).WithMessage(CampoObrigatorio);
        }
    }
}
