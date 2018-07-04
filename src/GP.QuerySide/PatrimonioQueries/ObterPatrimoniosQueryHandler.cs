using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static GP.QuerySide.PatrimonioQueries.ObterPatrimoniosQueryResponse;

namespace GP.QuerySide.PatrimonioQueries
{
    public class ObterPatrimoniosQueryHandler : IRequestHandler<ObterPatrimoniosQueryRequest, ObterPatrimoniosQueryResponse>
    {
        private readonly IDbConnection _con;

        public ObterPatrimoniosQueryHandler(IDbConnection con)
        {
            _con = con;
        }

        public async Task<ObterPatrimoniosQueryResponse> Handle(ObterPatrimoniosQueryRequest request, CancellationToken cancellationToken)
        {

            var sql = @"
SELECT        ma.Nome AS Marca, mo.Nome AS Modelo, p.TomboNumero, p.Nome, p.Descricao, p.DataCriacao
FROM            Patrimonio AS p INNER JOIN
                         Modelo AS mo ON p.ModeloId = mo.ModeloId INNER JOIN
                         Marca AS ma ON mo.MarcaId = ma.MarcaId
WHERE 1=1
";

            if (request.MarcaId.HasValue)
            {
                sql += " AND ma.MarcaId=@MarcaId";
            }
            if (request.ModeloId.HasValue)
            {
                sql += " AND mo.ModeloId=@ModeloId";
            }
            if (request.TomboNumero.HasValue)
            {
                sql += " AND p.TomboNumero=@TomboNumero";
            }
            if (!string.IsNullOrWhiteSpace(request.Nome))
            {
                sql += " AND p.Nome LIKE CONCAT('%',@Nome,'%')";
            }


            var @params = new
            {
                MarcaId = request.MarcaId,
                ModeloId = request.ModeloId,
                TomboNumero = request.TomboNumero,
                Nome = request.Nome
            };


            var result = await _con.QueryAsync<ObterPatrimoniosItemQueryResponse>(sql, @params);

            return new ObterPatrimoniosQueryResponse { Resultado = result };
        }
    }
}
