using GP.CommandSide.Domain.Repositories;
using GP.CommandSide.Infra.Ef.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GP.Api.AspNet.ContainerRegistries
{
    public static class RegistroRepositories
    {
        public static void RegistrarRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped<IModeloRepository, ModeloRepository>();
            services.AddScoped<IPatrimonioRepository, PatrimonioRepository>();
        }
    }
}
