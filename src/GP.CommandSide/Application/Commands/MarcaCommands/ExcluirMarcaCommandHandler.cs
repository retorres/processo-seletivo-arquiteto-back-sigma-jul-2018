using GP.CommandSide.Application.Core;
using GP.CommandSide.Application.Services;
using GP.CommandSide.Domain.Entities;
using GP.CommandSide.Domain.Exceptions;
using GP.CommandSide.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace GP.CommandSide.Application.Commands.MarcaCommands
{
    public class ExcluirMarcaCommandHandler : CommandHandler<ExcluirMarcaCommand>
    {
        private readonly IMarcaRepository _marcaRepository;

        public ExcluirMarcaCommandHandler(
            IMarcaRepository marcaRepository,
            ICommandValidatorService validatorService) : base(validatorService)
        {
            _marcaRepository = marcaRepository;
        }

        public override async Task HandleCore(ExcluirMarcaCommand request, CancellationToken cancellationToken)
        {
            var marca = await _marcaRepository.ObterPorIdAsync(request.MarcaId);
            if (marca == default(Marca)) throw new EntityNotFoundException(typeof(Marca).Name, request.MarcaId);

            marca.Excluir();

            await _marcaRepository.ExcluirAsync(marca);
        }
    }
}
