using GP.CommandSide.Domain.Entities;
using GP.CommandSide.Domain.Exceptions;
using GP.CommandSide.Domain.Repositories;
using GP.CommandSide.Domain.Abstractions;
using System.Threading.Tasks;
using System.Linq;

namespace GP.CommandSide.Domain.DomainServices.ModeloDomainService
{
    public class CriacaoModeloDomainService : ICriacaoModeloDomainService
    {
        private readonly ITimeProvider _timeProvider;
        private readonly IIdGeneratorService<long> _idGeneratorService;
        private readonly IMarcaRepository _marcaRepository;
        private readonly IModeloRepository _repository;

        public CriacaoModeloDomainService(
            ITimeProvider timeProvider,
            IIdGeneratorService<long> idGeneratorService,
            IMarcaRepository marcaRepository,
            IModeloRepository repository)
        {
            _timeProvider = timeProvider;
            _idGeneratorService = idGeneratorService;
            _marcaRepository = marcaRepository;
            _repository = repository;
        }
        public async Task<long> CriarModeloAsync(long marcaId, string nome)
        {
            var marca = await _marcaRepository.ObterPorIdAsync(marcaId);
            if (marca == null) throw new EntityNotFoundException(typeof(Marca).Name, marcaId);

            if (marca.Modelos.Any(r => r.Nome == nome)) throw new DuplicatedEntityException(typeof(Modelo).Name, nome);

            var modelo = marca.NovoModelo(_idGeneratorService.GenerateId(), nome, _timeProvider.UtcNow);

            await _repository.IncluirAsync(modelo);

            return modelo.ModeloId;
        }
    }
}
