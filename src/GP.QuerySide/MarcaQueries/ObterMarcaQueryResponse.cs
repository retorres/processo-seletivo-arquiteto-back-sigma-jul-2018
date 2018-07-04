using System;

namespace GP.QuerySide.MarcaQueries
{
    public class ObterMarcaQueryResponse
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
        /// Data em que foi cadastrado a marca
        /// </summary>
        public DateTime DataCriacao { get; set; }
    }
}
