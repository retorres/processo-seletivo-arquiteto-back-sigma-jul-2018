using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.QuerySide.ModeloQueries
{
    public class ObterModeloQueryRequest: IRequest<ObterModeloQueryResponse>
    {

        /// <summary>
        /// Id do Modelo
        /// </summary>
        public long ModeloId { get; set; }
    }
}
