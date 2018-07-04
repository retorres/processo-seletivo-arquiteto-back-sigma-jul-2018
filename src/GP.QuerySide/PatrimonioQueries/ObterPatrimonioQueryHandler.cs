using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GP.QuerySide.PatrimonioQueries
{
    public class ObterPatrimonioQueryHandler : IRequestHandler<ObterPatrimonioQueryRequest, ObterPatrimonioQueryResponse>
    {
        private readonly IDbConnection _con;

        public ObterPatrimonioQueryHandler(IDbConnection con)
        {
            _con = con;
        }

        public async Task<ObterPatrimonioQueryResponse> Handle(ObterPatrimonioQueryRequest request, CancellationToken cancellationToken)
        {
            var sql = @"
SELECT        ma.Nome AS Marca, ma.MarcaId, mo.Nome AS Modelo, mo.ModeloId, p.TomboNumero, p.Nome, p.Descricao, p.DataCriacao
FROM            Patrimonio AS p INNER JOIN
                         Modelo AS mo ON p.ModeloId = mo.ModeloId INNER JOIN
                         Marca AS ma ON mo.MarcaId = ma.MarcaId
WHERE p.TomboNumero=@TomboNumero 
";

            var @params = new { TomboNumero = request.TomboNumero};

            var result = await _con.QueryFirstOrDefaultAsync<ObterPatrimonioQueryResponse>(sql, @params);

            return result;
        }
    }
}
