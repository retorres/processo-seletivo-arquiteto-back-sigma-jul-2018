using FluentValidation;
using GP.CommandSide.Application.Core;

namespace GP.CommandSide.Application.Commands.ModeloCommands
{
    public class ExcluirModeloCommandValidator : CommandValidator<ExcluirModeloCommand>
    {
        public ExcluirModeloCommandValidator()
        {
            RuleFor(r => r.ModeloId).GreaterThan(0).WithMessage(CampoObrigatorio);
        }
    }
}
