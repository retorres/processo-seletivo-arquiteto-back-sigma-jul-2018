using System.Threading.Tasks;

namespace GP.CommandSide.Domain.DomainServices.ModeloDomainService
{
    public interface IAlteracaoMarcaDoModeloDomainService
    {
        Task AlterarMarcaDoModeloAsync(long modeloId, long marcaId);

    }
}
