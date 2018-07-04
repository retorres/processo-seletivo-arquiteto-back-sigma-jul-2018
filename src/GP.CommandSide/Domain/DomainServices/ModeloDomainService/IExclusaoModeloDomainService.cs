using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GP.CommandSide.Domain.DomainServices.ModeloDomainService
{
    public interface IExclusaoModeloDomainService
    {
        Task ExcluirModeloAsync(long modeloId);
    }
}
