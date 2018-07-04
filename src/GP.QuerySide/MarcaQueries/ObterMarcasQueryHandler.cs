using Dapper;
using MediatR;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using static GP.QuerySide.MarcaQueries.ObterMarcasQueryResponse;

namespace GP.QuerySide.MarcaQueries
{
    public class ObterMarcasQueryHandler : IRequestHandler<ObterMarcasQueryRequest, ObterMarcasQueryResponse>
    {
        private readonly IDbConnection _con;

        public ObterMarcasQueryHandler(IDbConnection con)
        {
            _con = con;
        }
        public async Task<ObterMarcasQueryResponse> Handle(ObterMarcasQueryRequest request, CancellationToken cancellationToken)
        {
            var sql = " SELECT MarcaId, Nome, DataCriacao FROM dbo.Marca WHERE 1=1";

            if (request.MarcaId.HasValue)
            {
                sql += " AND MarcaId=@MarcaId";
            }
            if (!string.IsNullOrWhiteSpace(request.Nome))
            {
                sql += " AND Nome LIKE CONCAT('%',@Nome,'%')";
            }

            var @params = new
            {
                MarcaId = request.MarcaId,
                Nome = request.Nome
            };

            var result = await _con.QueryAsync<ObterMarcasItemQueryResponse>(sql, @params);

            return new ObterMarcasQueryResponse { Resultado = result };
        }
    }
}
