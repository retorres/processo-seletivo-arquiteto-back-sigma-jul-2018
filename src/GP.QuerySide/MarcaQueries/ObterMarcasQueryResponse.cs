using System;
using System.Collections.Generic;
using System.Linq;

namespace GP.QuerySide.MarcaQueries
{
    public class ObterMarcasQueryResponse
    {
        /// <summary>
        /// Lista de marcas da consulta
        /// </summary>
        public IEnumerable<ObterMarcasItemQueryResponse> Resultado { get; set; } = new List<ObterMarcasItemQueryResponse>();

        /// <summary>
        /// Total de marcas encontradas
        /// </summary>
        public int Total => Resultado.Count();


        public class ObterMarcasItemQueryResponse
        {
            /// <summary>
            /// Id da marca
            /// </summary>
            public long MarcaId { get; set; }
            /// <summary>
            /// Nome da marca
            /// </summary>
            public string Nome { get; set; }
            /// <summary>
            /// Data que foi cadastrada a marca
            /// </summary>
            public DateTime DataCriacao { get; set; }
        }
    }
}
