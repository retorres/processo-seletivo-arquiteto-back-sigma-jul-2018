using FluentValidation;
using GP.CommandSide.Application.Core;

namespace GP.CommandSide.Application.Commands.MarcaCommands
{
    public class AlterarNomeDaMarcaCommandValidator : CommandValidator<AlterarNomeDaMarcaCommand>
    {
        public AlterarNomeDaMarcaCommandValidator()
        {
            RuleFor(r => r.Nome).NotEmpty().WithMessage(CampoObrigatorio);
            RuleFor(r => r.MarcaId).GreaterThan(0).WithMessage(CampoObrigatorio);
        }
    }
}
