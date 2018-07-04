using MediatR;

namespace GP.QuerySide.MarcaQueries
{
    public class ObterMarcaQueryRequest : IRequest<ObterMarcaQueryResponse>
    {
        
        /// <summary>
        /// Id da marca
        /// </summary>
        public long MarcaId { get; set; }

    }
}
