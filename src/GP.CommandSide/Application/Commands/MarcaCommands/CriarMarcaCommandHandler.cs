using GP.CommandSide.Application.Core;
using GP.CommandSide.Application.Services;
using GP.CommandSide.Domain.DomainServices.MarcaDomainService;
using System.Threading;
using System.Threading.Tasks;

namespace GP.CommandSide.Application.Commands.MarcaCommands
{
    public class CriarMarcaCommandHandler : CommandHandler<CriarMarcaCommand, long>
    {
        private readonly ICriacaoMarcaDomainService _criacaoMarcaDomainService;

        public CriarMarcaCommandHandler(
            ICriacaoMarcaDomainService criacaoMarcaDomainService,
            ICommandValidatorService validatorService)
            : base(validatorService)
        {
            _criacaoMarcaDomainService = criacaoMarcaDomainService;
        }

        public override async Task<long> HandleCore(CriarMarcaCommand request, CancellationToken cancellationToken)
        {
            var id = await _criacaoMarcaDomainService.CriarMarcaAsync(request.Nome);

            return id;

        }
    }
}
