using GP.CommandSide.Application.Core;
using GP.CommandSide.Application.Services;
using GP.CommandSide.Domain.Entities;
using GP.CommandSide.Domain.Exceptions;
using GP.CommandSide.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace GP.CommandSide.Application.Commands.MarcaCommands
{
    public class AlterarNomeDaMarcaCommandHandler : CommandHandler<AlterarNomeDaMarcaCommand>
    {
        private readonly IMarcaRepository _repository;

        public AlterarNomeDaMarcaCommandHandler(
            IMarcaRepository repository,
            ICommandValidatorService validatorService) : base(validatorService)
        {
            _repository = repository;
        }

        public override async Task HandleCore(AlterarNomeDaMarcaCommand request, CancellationToken cancellationToken)
        {
            var marca = await _repository.ObterPorIdAsync(request.MarcaId);
            if (marca == default(Marca)) throw new EntityNotFoundException(typeof(Marca).Name, request.MarcaId);

            marca.AlterarNome(request.Nome);
        }
    }
}
