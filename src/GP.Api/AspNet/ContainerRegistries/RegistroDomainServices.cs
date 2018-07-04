using GP.CommandSide.Domain.DomainServices.MarcaDomainService;
using GP.CommandSide.Domain.DomainServices.ModeloDomainService;
using GP.CommandSide.Domain.DomainServices.PatrimonioDomainService;
using Microsoft.Extensions.DependencyInjection;

namespace GP.Api.AspNet.ContainerRegistries
{
    public static class RegistroDomainServices
    {
        public static void RegistrarDomainServices(this IServiceCollection services)
        {
            services.AddScoped<ICriacaoMarcaDomainService, CriacaoMarcaDomainService>();
            services.AddScoped<ICriacaoModeloDomainService, CriacaoModeloDomainService>();
            services.AddScoped<IAlteracaoMarcaDoModeloDomainService, AlteracaoMarcaDoModeloDomainService>();
            services.AddScoped<ICriacaoPatrimonioDomainService, CriacaoPatrimonioDomainService>();

        }
    }
}
