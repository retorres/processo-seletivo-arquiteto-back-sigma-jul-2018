using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GP.Api.AspNet.ContainerRegistries
{
    public static class RegistroSwagger
    {
        public static void RegistrarSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Serviço REST para Gerenciamento de patrimonios de uma empresa",
                        Version = "v1",
                        Description = "Esta api tem como objetivo participar do processo seletivo da SIGMA/TJMT.",
                        Contact = new Contact
                        {
                            Name = "Renan Torres",
                            Url = "https://www.linkedin.com/in/renan-torres-378a94a4"
                        }
                    });
            });
        }
    }
}
