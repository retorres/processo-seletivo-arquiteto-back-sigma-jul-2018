using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using GP.CommandSide.Application.Services;
using GP.CommandSide.Domain.Exceptions;
using MediatR;

namespace GP.CommandSide.Application.Core
{
    public abstract class CommandHandler<TCommand> : AsyncRequestHandler<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandValidatorService _validatorService;

        public CommandHandler(ICommandValidatorService validatorService)
        {
            _validatorService = validatorService;
        }
        protected override async Task Handle(TCommand request, CancellationToken cancellationToken)
        {
            var resultadoValidacao = _validatorService.Validate(request);

            if (!resultadoValidacao.IsValid)
                throw new DomainException(
                           $"Command Validation Errors for type {typeof(TCommand).Name}",
                           new ValidationException("Validation exception", resultadoValidacao.Errors));

            await HandleCore(request, cancellationToken);
        }

        public abstract Task HandleCore(TCommand request, CancellationToken cancellationToken);
    }


    public abstract class CommandHandler<TCommand, TResult> : IRequestHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
        private readonly ICommandValidatorService _validatorService;

        public CommandHandler(ICommandValidatorService validatorService)
        {
            _validatorService = validatorService;
        }

        public async Task<TResult> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var resultadoValidacao = _validatorService.Validate(request);

            if (resultadoValidacao.IsValid)
                return await HandleCore(request, cancellationToken);


            throw new CommandValidationException(request, resultadoValidacao.Errors);
        }

        public abstract Task<TResult> HandleCore(TCommand request, CancellationToken cancellationToken);
    }
}
