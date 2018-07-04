using GP.CommandSide.Domain.Entities;
using GP.CommandSide.Domain.Exceptions;
using GP.CommandSide.Domain.Repositories;
using System.Threading.Tasks;

namespace GP.CommandSide.Domain.DomainServices.ModeloDomainService
{
    public class AlteracaoMarcaDoModeloDomainService : IAlteracaoMarcaDoModeloDomainService
    {
        private readonly IMarcaRepository _marcaRepository;
        private readonly IModeloRepository _modeloRepository;

        public AlteracaoMarcaDoModeloDomainService(
            IMarcaRepository marcaRepository,
            IModeloRepository modeloRepository)
        {
            _marcaRepository = marcaRepository;
            _modeloRepository = modeloRepository;
        }
        public async Task AlterarMarcaDoModeloAsync(long modeloId, long marcaId)
        {
            var modelo = await _modeloRepository.ObterPorIdAsync(modeloId);
            if (modelo == null) throw new EntityNotFoundException(typeof(Modelo).Name, modeloId);

            var marca = await _marcaRepository.ObterPorIdAsync(marcaId);
            if (marca == null) throw new EntityNotFoundException(typeof(Marca).Name, marcaId);

            modelo.AlterarMarca(marca);
        }
    }
}
