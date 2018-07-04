using System.Threading.Tasks;

namespace GP.CommandSide.Domain.DomainServices.ModeloDomainService
{
    public interface ICriacaoModeloDomainService
    {
        Task<long> CriarModeloAsync(long marcaId, string nome);
    }
}
