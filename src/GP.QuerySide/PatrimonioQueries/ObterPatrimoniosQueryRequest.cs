using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.QuerySide.PatrimonioQueries
{
    public class ObterPatrimoniosQueryRequest : IRequest<ObterPatrimoniosQueryResponse>
    {
        /// <summary>
        /// Id da marca
        /// </summary>
        public long? MarcaId { get; set; }
        /// <summary>
        /// Id do modelo
        /// </summary>
        public long? ModeloId { get; set; }
        /// <summary>
        /// Número do tombo
        /// </summary>
        public long? TomboNumero { get; set; }
        /// <summary>
        /// Nome do patrimonio
        /// </summary>
        public string Nome { get; set; }
    }
}
