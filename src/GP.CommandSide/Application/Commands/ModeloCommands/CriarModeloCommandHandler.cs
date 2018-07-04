using GP.CommandSide.Application.Core;
using GP.CommandSide.Application.Services;
using GP.CommandSide.Domain.DomainServices.ModeloDomainService;
using System.Threading;
using System.Threading.Tasks;

namespace GP.CommandSide.Application.Commands.ModeloCommands
{
    public class CriarModeloCommandHandler : CommandHandler<CriarModeloCommand, long>
    {
        private readonly ICriacaoModeloDomainService _criacaoModeloDomainService;

        public CriarModeloCommandHandler(
            ICriacaoModeloDomainService criacaoModeloDomainService,
            ICommandValidatorService validatorService) : base(validatorService)
        {
            _criacaoModeloDomainService = criacaoModeloDomainService;
        }

        public override async Task<long> HandleCore(CriarModeloCommand request, CancellationToken cancellationToken)
        {
            var id = await _criacaoModeloDomainService.CriarModeloAsync(request.MarcaId, request.Nome);

            return id;
        }
    }
}
