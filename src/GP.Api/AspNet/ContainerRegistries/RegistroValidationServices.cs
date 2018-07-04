using FluentValidation;
using GP.CommandSide.Application.Core;
using GP.CommandSide.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace GP.Api.AspNet.ContainerRegistries
{
    public static class RegistroValidationServices
    {
        public static void RegistrarValidationServices(this IServiceCollection services)
        {
            services.AddSingleton<ICommandValidatorService, CommandValidatorService>();


            //Registra todas os command validators no container de ioc
            var tipos = typeof(CommandValidator<>).Assembly.GetExportedTypes()
                .Where(d =>
                    !d.IsAbstract
                    && !d.IsGenericType
                    && d.GetInterfaces().Any(r => r == typeof(IValidator))
                    ).ToList();

            var regs = (from r in tipos
                        select new
                        {
                            Implementation = r,
                            Service = r.BaseType.GetTypeInfo().GetGenericArguments().FirstOrDefault()
                        }).ToList();

            var genericClass = typeof(CommandValidator<>);

            foreach (var reg in regs)
            {
                var constructedClass = genericClass.MakeGenericType(reg.Service);

                services.AddSingleton(constructedClass, reg.Implementation);
            }
        }
    }
}
