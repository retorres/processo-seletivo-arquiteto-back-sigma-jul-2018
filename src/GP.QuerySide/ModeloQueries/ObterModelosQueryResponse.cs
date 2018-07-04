using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.QuerySide.ModeloQueries
{
    public class ObterModelosQueryResponse
    {
        /// <summary>
        /// Lista de patrimonios da consulta
        /// </summary>
        public IEnumerable<ObterModelosItemQueryResponse> Resultado { get; set; } = new List<ObterModelosItemQueryResponse>();
        /// <summary>
        /// Total de modelos da consulta
        /// </summary>
        public int Total => Resultado.Count();



        public class ObterModelosItemQueryResponse
        {
            /// <summary>
            /// Id do modelo
            /// </summary>
            public long ModeloId { get; set; }
            /// <summary>
            /// Id da marca
            /// </summary>
            public long MarcaId { get; set; }
            /// <summary>
            /// Nome da marca
            /// </summary>
            public string Marca { get; set; }
            /// <summary>
            /// Nome do modelo
            /// </summary>
            public string Nome { get; set; }
            /// <summary>
            /// Data de cadastro do modelo
            /// </summary>
            public DateTime DataCriacao { get; set; }
        }
    }
}
