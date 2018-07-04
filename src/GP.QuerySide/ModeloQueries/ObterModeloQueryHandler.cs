using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GP.QuerySide.ModeloQueries
{
    public class ObterModeloQueryHandler : IRequestHandler<ObterModeloQueryRequest, ObterModeloQueryResponse>
    {
        private readonly IDbConnection _con;

        public ObterModeloQueryHandler(IDbConnection con)
        {
            _con = con;
        }


        public async Task<ObterModeloQueryResponse> Handle(ObterModeloQueryRequest request, CancellationToken cancellationToken)
        {
            var sql = " SELECT ModeloId, MarcaId, Nome, DataCriacao FROM dbo.Modelo WHERE ModeloId = @ModeloId";

            var @params = new { ModeloId = request.ModeloId };

            var result = await _con.QueryFirstOrDefaultAsync<ObterModeloQueryResponse>(sql, @params);

            return result;
        }
    }
}
