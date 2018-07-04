using MediatR;

namespace GP.CommandSide.Application.Core
{

    public interface ICommand : IRequest, ICommandWithValidation
    {
    }

    public interface ICommand<out TResponse> : IRequest<TResponse>, ICommandWithValidation
    {
    }

}