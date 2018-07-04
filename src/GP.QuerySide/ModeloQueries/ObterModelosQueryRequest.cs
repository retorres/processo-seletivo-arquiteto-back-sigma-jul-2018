using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.QuerySide.ModeloQueries
{
    public class ObterModelosQueryRequest : IRequest<ObterModelosQueryResponse>
    {
        /// <summary>
        /// Id da marca do modelo que deseja filtrar
        /// </summary>
        public long? MarcaId { get; set; }
    }
}
