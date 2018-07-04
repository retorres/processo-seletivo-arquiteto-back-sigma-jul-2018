using GP.CommandSide.Domain.Entities;
using GP.CommandSide.Domain.Exceptions;
using GP.CommandSide.Domain.Repositories;
using GP.CommandSide.Domain.Abstractions;
using System.Threading.Tasks;

namespace GP.CommandSide.Domain.DomainServices.MarcaDomainService
{
    public class CriacaoMarcaDomainService : ICriacaoMarcaDomainService
    {
        private readonly ITimeProvider _timeProvider;
        private readonly IIdGeneratorService<long> _idGeneratorService;
        private readonly IMarcaRepository _repository;

        public CriacaoMarcaDomainService(
            ITimeProvider timeProvider,
            IIdGeneratorService<long> idGeneratorService,
            IMarcaRepository repository)
        {
            _timeProvider = timeProvider;
            _idGeneratorService = idGeneratorService;
            _repository = repository;
        }
        public async Task<long> CriarMarcaAsync(string nome)
        {
            var marcaRepetida = await _repository.ObterPorNomeAsync(nome);
            if (marcaRepetida != null) throw new DuplicatedEntityException(typeof(Marca).Name, nome);

            var marca = new Marca(_idGeneratorService.GenerateId(), nome, _timeProvider.UtcNow);

            await _repository.IncluirAsync(marca);

            return marca.MarcaId;
        }
    }
}
