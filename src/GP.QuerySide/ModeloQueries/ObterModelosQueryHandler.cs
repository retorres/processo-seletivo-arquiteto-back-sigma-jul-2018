using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static GP.QuerySide.ModeloQueries.ObterModelosQueryResponse;

namespace GP.QuerySide.ModeloQueries
{
    public class ObterModelosQueryHandler : IRequestHandler<ObterModelosQueryRequest, ObterModelosQueryResponse>
    {
        private readonly IDbConnection _con;

        public ObterModelosQueryHandler(IDbConnection con)
        {
            _con = con;
        }
        public async Task<ObterModelosQueryResponse> Handle(ObterModelosQueryRequest request, CancellationToken cancellationToken)
        {
            var sql = @" 
SELECT        mo.ModeloId, mo.MarcaId, ma.Nome AS Marca, mo.Nome, mo.DataCriacao
FROM            Modelo AS mo INNER JOIN
                         Marca AS ma ON mo.MarcaId = ma.MarcaId
WHERE 1=1";

            if (request.MarcaId.HasValue)
            {
                sql += " AND ma.MarcaId=@MarcaId";

            }
            var @params = new { MarcaId = request.MarcaId };

            var result = await _con.QueryAsync<ObterModelosItemQueryResponse>(sql, @params);

            return new ObterModelosQueryResponse { Resultado = result };
        }
    }
}
