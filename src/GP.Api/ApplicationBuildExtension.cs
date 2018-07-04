using GP.CommandSide.Infra.Ef;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GP.Api
{
    public static class ApplicationBuildExtension
    {
        public static void CreateDatabase(this IApplicationBuilder app)
        {
            var retry = Policy.Handle<SqlException>()
                .WaitAndRetry(10, retryAttempt =>
                                TimeSpan.FromSeconds(5));

            retry.Execute(() =>
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var db = serviceScope.ServiceProvider.GetService<AppDbContext>();
                    db.Database.EnsureCreated();
                }
            });
        }
    }
}
