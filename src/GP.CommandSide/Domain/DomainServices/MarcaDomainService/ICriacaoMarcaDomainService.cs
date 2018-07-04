using System.Threading.Tasks;

namespace GP.CommandSide.Domain.DomainServices.MarcaDomainService
{
    public interface ICriacaoMarcaDomainService
    {
        Task<long> CriarMarcaAsync(string nome);
    }
}
