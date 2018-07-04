using MediatR;

namespace GP.QuerySide.MarcaQueries
{
    public class ObterMarcasQueryRequest : IRequest<ObterMarcasQueryResponse>
    {
        /// <summary>
        /// Id da marca que deseja filtrar
        /// </summary>
        public long? MarcaId { get; set; }

        /// <summary>
        /// Nome da marca que deseja filtrar
        /// </summary>
        public string Nome { get; set; }

    }

}
