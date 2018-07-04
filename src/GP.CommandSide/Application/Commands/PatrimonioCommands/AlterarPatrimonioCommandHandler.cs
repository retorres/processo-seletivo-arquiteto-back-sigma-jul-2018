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
    public class AlterarPatrimonioCommandHandler : CommandHandler<AlterarPatrimonioCommand>
    {
        private readonly IPatrimonioRepository _patrimonioRepository;

        public AlterarPatrimonioCommandHandler(
            IPatrimonioRepository patrimonioRepository,
            ICommandValidatorService validatorService) : base(validatorService)
        {
            _patrimonioRepository = patrimonioRepository;
        }

        public override async Task HandleCore(AlterarPatrimonioCommand request, CancellationToken cancellationToken)
        {
            var patrimonio = await _patrimonioRepository.ObterPorIdAsync(request.TomboNumero);

            patrimonio.AlterarInformacoesCadastrais(request.Nome, request.Descricao);
        }
    }
}
