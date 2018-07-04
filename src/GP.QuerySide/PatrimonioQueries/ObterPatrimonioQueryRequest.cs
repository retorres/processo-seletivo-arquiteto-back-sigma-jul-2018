using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.QuerySide.PatrimonioQueries
{
    public class ObterPatrimonioQueryRequest : IRequest<ObterPatrimonioQueryResponse>
    {
        public long TomboNumero { get; set; }
    }
}
