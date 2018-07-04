using System.Threading.Tasks;

namespace GP.CommandSide.Domain.DomainServices.PatrimonioDomainService
{
    public interface ICriacaoPatrimonioDomainService
    {
        Task<long> CriarPatrimonio(long modeloId, string nome, string descricao);
    }
}
