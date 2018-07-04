using GP.CommandSide.Application.Core;
using GP.CommandSide.Application.Services;
using GP.CommandSide.Domain.DomainServices.ModeloDomainService;
using System.Threading;
using System.Threading.Tasks;

namespace GP.CommandSide.Application.Commands.ModeloCommands
{
    public class AlterarMarcaDoModeloCommandHandler : CommandHandler<AlterarMarcaDoModeloCommand>
    {
        private readonly IAlteracaoMarcaDoModeloDomainService _alteracaoMarcaDoModeloDomainService;

        public AlterarMarcaDoModeloCommandHandler(
            IAlteracaoMarcaDoModeloDomainService alteracaoMarcaDoModeloDomainService,
            ICommandValidatorService validatorService) 
            : base(validatorService)
        {
            _alteracaoMarcaDoModeloDomainService = alteracaoMarcaDoModeloDomainService;
        }

        public override async Task HandleCore(AlterarMarcaDoModeloCommand request, CancellationToken cancellationToken)
        {
            await _alteracaoMarcaDoModeloDomainService.AlterarMarcaDoModeloAsync(request.ModeloId, request.MarcaId);
        }
    }
}
