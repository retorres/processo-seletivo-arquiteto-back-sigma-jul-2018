using GP.CommandSide.Application.Core;
using GP.CommandSide.Application.Services;
using GP.CommandSide.Domain.DomainServices.PatrimonioDomainService;
using System.Threading;
using System.Threading.Tasks;

namespace GP.CommandSide.Application.Commands.PatrimonioCommands
{
    public class CriarPatrimonioCommandHandler : CommandHandler<CriarPatrimonioCommand, long>
    {
        private readonly ICriacaoPatrimonioDomainService _criacaoPatrimonioDomainService;

        public CriarPatrimonioCommandHandler(
            ICriacaoPatrimonioDomainService criacaoPatrimonioDomainService,
            ICommandValidatorService validatorService) : base(validatorService)
        {
            _criacaoPatrimonioDomainService = criacaoPatrimonioDomainService;
        }

        public override async Task<long> HandleCore(CriarPatrimonioCommand request, CancellationToken cancellationToken)
        {
            var tomboNumero = await _criacaoPatrimonioDomainService.CriarPatrimonio(request.ModeloId, request.Nome, request.Descricao);

            return tomboNumero;
        }
    }
}
