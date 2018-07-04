using FluentValidation;
using GP.CommandSide.Application.Core;

namespace GP.CommandSide.Application.Commands.ModeloCommands
{

    public class AlterarMarcaDoModeloCommandValidator : CommandValidator<AlterarMarcaDoModeloCommand>
    {
        public AlterarMarcaDoModeloCommandValidator()
        {
            RuleFor(r => r.MarcaId).GreaterThan(0).WithMessage(CampoObrigatorio);
            RuleFor(r => r.ModeloId).GreaterThan(0).WithMessage(CampoObrigatorio);
        }
    }
}
