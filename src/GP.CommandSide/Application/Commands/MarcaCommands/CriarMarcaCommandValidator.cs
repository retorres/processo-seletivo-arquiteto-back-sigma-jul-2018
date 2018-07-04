using GP.CommandSide.Application.Core;
using FluentValidation.Validators;
using FluentValidation;
namespace GP.CommandSide.Application.Commands.MarcaCommands
{
    public class CriarMarcaCommandValidator : CommandValidator<CriarMarcaCommand>
    {
        public CriarMarcaCommandValidator()
        {
            RuleFor(r => r.Nome).NotEmpty().WithMessage(CampoObrigatorio);
        }
    }
}
