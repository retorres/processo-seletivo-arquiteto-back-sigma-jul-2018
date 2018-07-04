using FluentValidation;
using GP.CommandSide.Application.Core;

namespace GP.CommandSide.Application.Commands.ModeloCommands
{
    public class CriarModeloCommandValidator : CommandValidator<CriarModeloCommand>
    {
        public CriarModeloCommandValidator()
        {
            RuleFor(r => r.MarcaId).GreaterThan(0).WithMessage(CampoObrigatorio);
            RuleFor(r => r.Nome).NotEmpty().WithMessage(CampoObrigatorio);
        }
    }
}
