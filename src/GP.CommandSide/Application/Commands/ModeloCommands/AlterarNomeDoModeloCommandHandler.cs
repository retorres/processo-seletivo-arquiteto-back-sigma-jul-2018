using GP.CommandSide.Application.Core;
using GP.CommandSide.Application.Services;
using GP.CommandSide.Domain.Entities;
using GP.CommandSide.Domain.Exceptions;
using GP.CommandSide.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace GP.CommandSide.Application.Commands.ModeloCommands
{
    public class AlterarNomeDoModeloCommandHandler : CommandHandler<AlterarNomeDoModeloCommand>
    {
        private readonly IModeloRepository _modeloRepository;

        public AlterarNomeDoModeloCommandHandler(
            IModeloRepository modeloRepository,
            ICommandValidatorService validatorService) : base(validatorService)
        {
            _modeloRepository = modeloRepository;
        }

        public override async Task HandleCore(AlterarNomeDoModeloCommand request, CancellationToken cancellationToken)
        {
            var modelo = await _modeloRepository.ObterPorIdAsync(request.ModeloId);
            if (modelo == default(Modelo)) throw new EntityNotFoundException(typeof(Modelo).Name, request.ModeloId);

            modelo.AlterarNome(request.Nome);
        }
    }
}
