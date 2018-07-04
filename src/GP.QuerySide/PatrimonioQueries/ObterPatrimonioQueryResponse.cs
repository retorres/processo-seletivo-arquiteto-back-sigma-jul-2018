using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.QuerySide.PatrimonioQueries
{
    public class ObterPatrimonioQueryResponse
    {
        public string Marca { get; set; }
        public long MarcaId { get; set; }
        public string Modelo { get; set; }
        public long ModeloId { get; set; }
        public long TomboNumero { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
