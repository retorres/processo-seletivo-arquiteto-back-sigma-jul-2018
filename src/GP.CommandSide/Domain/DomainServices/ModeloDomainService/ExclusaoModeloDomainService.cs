using GP.CommandSide.Domain.Entities;
using GP.CommandSide.Domain.Exceptions;
using GP.CommandSide.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GP.CommandSide.Domain.DomainServices.ModeloDomainService
{
    public class ExclusaoModeloDomainService : IExclusaoModeloDomainService
    {
        private readonly IModeloRepository _modeloRepository;

        public ExclusaoModeloDomainService(
            IModeloRepository modeloRepository)
        {
            _modeloRepository = modeloRepository;
        }
        public async Task ExcluirModeloAsync(long modeloId)
        {
            var modelo = await _modeloRepository.ObterPorIdAsync(modeloId);
            if (modelo == null) throw new EntityNotFoundException(typeof(Modelo).Name, modeloId);

            if (await _modeloRepository.ModeloPossuiPatrimonio(modelo.ModeloId))
                throw new DomainException("Este modelo não pode ser excluido, pois o mesmo possui patrimonios vinculados");

            modelo.Excluir();

            await _modeloRepository.ExcluirAsync(modelo);
        }
    }
}
