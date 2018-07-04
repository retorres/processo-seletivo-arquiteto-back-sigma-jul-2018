using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.QuerySide.ModeloQueries
{
    public class ObterModeloQueryResponse
    {
        /// <summary>
        /// Id do model
        /// </summary>
        public long ModeloId { get; set; }
        /// <summary>
        /// Id da marca deste modelo
        /// </summary>
        public long MarcaId { get; set; }
        /// <summary>
        /// Nome do modelo
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Data de cadastro deste modelo
        /// </summary>
        public DateTime DataCriacao { get; set; }

    }
}
