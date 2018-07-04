using GP.CommandSide.Application.Services;
using GP.CommandSide.Domain.Abstractions;
using GP.CommandSide.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GP.Api.AspNet.ContainerRegistries
{
    public static class RegistroCommonServices
    {
        /// <summary>
        /// Registra os serviços comuns
        /// </summary>
        /// <param name="services"></param>
        public static void RegistrarCommonServices(this IServiceCollection services)
        {
            services.AddSingleton<ITimeProvider, TimeProvider>();
            services.AddSingleton<IIdGeneratorService<long>, Id64GeneratorService>();

        }
    }
}
