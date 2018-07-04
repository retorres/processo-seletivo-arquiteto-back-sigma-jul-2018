using Dapper;
using MediatR;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace GP.QuerySide.MarcaQueries
{
    public class ObterMarcaQueryHandler : IRequestHandler<ObterMarcaQueryRequest, ObterMarcaQueryResponse>
    {
        private readonly IDbConnection _con;

        public ObterMarcaQueryHandler(IDbConnection con)
        {
            _con = con;
        }
        public async Task<ObterMarcaQueryResponse> Handle(ObterMarcaQueryRequest request, CancellationToken cancellationToken)
        {
            var sql = " SELECT MarcaId, Nome, DataCriacao FROM dbo.Marca WHERE MarcaId = @MarcaId";

            var @params = new { MarcaId = request.MarcaId };

            var result = await _con.QueryFirstOrDefaultAsync<ObterMarcaQueryResponse>(sql, @params);

            return result;
        }
    }
}
