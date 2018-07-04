using GP.CommandSide.Domain.Entities;
using GP.CommandSide.Domain.Exceptions;
using GP.CommandSide.Domain.Repositories;
using GP.CommandSide.Domain.Abstractions;
using System.Threading.Tasks;

namespace GP.CommandSide.Domain.DomainServices.PatrimonioDomainService
{
    public class CriacaoPatrimonioDomainService : ICriacaoPatrimonioDomainService
    {
        private readonly IModeloRepository _modeloRepository;
        private readonly IPatrimonioRepository _patrimonioRepository;
        private readonly IIdGeneratorService<long> _idGenerator;
        private readonly ITimeProvider _timeProvider;

        public CriacaoPatrimonioDomainService(
            IModeloRepository modeloRepository,
            IPatrimonioRepository patrimonioRepository,
            IIdGeneratorService<long> idGenerator,
            ITimeProvider timeProvider
            )
        {
            _modeloRepository = modeloRepository;
            _patrimonioRepository = patrimonioRepository;
            _idGenerator = idGenerator;
            _timeProvider = timeProvider;
        }


        public async Task<long> CriarPatrimonio(long modeloId, string nome, string descricao)
        {
            var modelo = await _modeloRepository.ObterPorIdAsync(modeloId);
            if (modelo == default(Modelo)) throw new EntityNotFoundException(typeof(Modelo).Name, modeloId);

            var patrimonio = modelo.NovoPatrimonio(_idGenerator.GenerateId(), nome, _timeProvider.UtcNow, descricao);

            await _patrimonioRepository.IncluirAsync(patrimonio);

            return patrimonio.TomboNumero;
        }
    }
}
