using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.QuerySide.PatrimonioQueries
{
    public class ObterPatrimoniosQueryResponse
    {
        /// <summary>
        /// Lista de patrimonios da consulta
        /// </summary>
        public IEnumerable<ObterPatrimoniosItemQueryResponse> Resultado { get; set; } = new List<ObterPatrimoniosItemQueryResponse>();


        /// <summary>
        /// Total de patrimonios encontrados 
        /// </summary>
        public int Total => Resultado.Count();

        public class ObterPatrimoniosItemQueryResponse
        {
            /// <summary>
            /// Nome da marca
            /// </summary>
            public string Marca { get; set; }

            /// <summary>
            /// Nome do modelo
            /// </summary>
            public string Modelo { get; set; }

            /// <summary>
            /// Numero do Tombo deste patrimonio
            /// </summary>
            public long TomboNumero { get; set; }

            /// <summary>
            /// Nome do Patrimonio
            /// </summary>
            public string Nome { get; set; }
            
            /// <summary>
            /// Descrição do patrimonio
            /// </summary>
            public string Descricao { get; set; }

            /// <summary>
            /// Data de cadastro do patrimonio
            /// </summary>
            public DateTime DataCriacao { get; set; }

        }
    }
}
