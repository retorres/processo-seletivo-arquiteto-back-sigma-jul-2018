using GP.Api.AspNet.ContainerRegistries;
using GP.Api.AspNet.Filters;
using GP.CommandSide.Domain;
using GP.CommandSide.Infra.Ef;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;

namespace GP.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            Configuration = configuration;
            Logger = loggerFactory.CreateLogger("Console");

        }

        public IConfiguration Configuration { get; }
        public ILogger Logger { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var stringConexao = Configuration["ConnectionString"];
            services.AddMvc(opts =>
            {
                opts.Filters.Add(typeof(CustomExceptionFilter));
            })
               .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<AppDbContext>(opts =>
                opts.UseSqlServer(stringConexao));

            services.AddScoped<IDbConnection>(provider =>
            {
                return new SqlConnection(stringConexao);
            });

            services.AddScoped<IUnitOfWork>(e => e.GetService<AppDbContext>());

            services.RegistrarMediator();
            services.RegistrarRepositories();
            services.RegistrarDomainServices();
            services.RegistrarValidationServices();
            services.RegistrarCommonServices();
            services.RegistrarSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.CreateDatabase();


            app.UseMvc();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

        }
    }
}
