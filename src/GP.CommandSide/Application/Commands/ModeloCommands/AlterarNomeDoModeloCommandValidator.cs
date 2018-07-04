using FluentValidation;
using GP.CommandSide.Application.Core;

namespace GP.CommandSide.Application.Commands.ModeloCommands
{
    public class AlterarNomeDoModeloCommandValidator : CommandValidator<AlterarNomeDoModeloCommand>
    {
        public AlterarNomeDoModeloCommandValidator()
        {
            RuleFor(r => r.ModeloId).GreaterThan(0).WithMessage(CampoObrigatorio);
            RuleFor(r => r.Nome).NotEmpty().WithMessage(CampoObrigatorio);
        }
    }
}
