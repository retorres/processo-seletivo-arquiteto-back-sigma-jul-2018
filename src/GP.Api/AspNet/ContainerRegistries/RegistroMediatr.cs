using GP.CommandSide.Application.Core;
using GP.CommandSide.Domain.Abstractions;
using GP.QuerySide.MarcaQueries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GP.Api.AspNet.ContainerRegistries
{
    public static class RegistroMediatr
    {

        public static void RegistrarMediator(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup));
            services.AddMediatR(typeof(ICommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(IDomainEvent).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterMarcaQueryRequest).GetTypeInfo().Assembly);
        }
    }
}
