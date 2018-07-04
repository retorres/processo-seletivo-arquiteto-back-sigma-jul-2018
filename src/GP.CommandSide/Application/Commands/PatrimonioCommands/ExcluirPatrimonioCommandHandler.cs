using GP.CommandSide.Application.Core;
using GP.CommandSide.Application.Services;
using GP.CommandSide.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GP.CommandSide.Application.Commands.PatrimonioCommands
{
    public class ExcluirPatrimonioCommandHandler : CommandHandler<ExcluirPatrimonioCommand>
    {
        private readonly IPatrimonioRepository _patrimonioRepository;

        public ExcluirPatrimonioCommandHandler(
            IPatrimonioRepository patrimonioRepository,
            ICommandValidatorService validatorService) : base(validatorService)
        {
            _patrimonioRepository = patrimonioRepository;
        }

        public override async Task HandleCore(ExcluirPatrimonioCommand request, CancellationToken cancellationToken)
        {
            var patrimonio = await _patrimonioRepository.ObterPorIdAsync(request.TomboNumero);

            patrimonio.Excluir();

            await _patrimonioRepository.ExcluirAsync(patrimonio);
        }
    }
}
