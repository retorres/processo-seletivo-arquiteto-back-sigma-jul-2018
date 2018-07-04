using FluentValidation;

namespace GP.CommandSide.Application.Core
{
    public abstract class CommandValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : ICommandWithValidation
    {
        protected const string CampoObrigatorio = "{PropertyName} é obrigatório.";

    }
}
