using GP.CommandSide.Application.Core;
using GP.CommandSide.Application.Services;
using GP.CommandSide.Domain.DomainServices.ModeloDomainService;
using GP.CommandSide.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GP.CommandSide.Application.Commands.ModeloCommands
{
    public class ExcluirModeloCommandHandler : CommandHandler<ExcluirModeloCommand>
    {
        private readonly IExclusaoModeloDomainService _exclusaoModeloDomainService;
        private readonly IModeloRepository _modeloRepository;

        public ExcluirModeloCommandHandler(
            IExclusaoModeloDomainService exclusaoModeloDomainService,
            IModeloRepository modeloRepository,
            ICommandValidatorService validatorService) : base(validatorService)
        {
            _exclusaoModeloDomainService = exclusaoModeloDomainService;
            _modeloRepository = modeloRepository;
        }

        public override async Task HandleCore(ExcluirModeloCommand request, CancellationToken cancellationToken)
        {
            await _exclusaoModeloDomainService.ExcluirModeloAsync(request.ModeloId);
        }
    }
}
