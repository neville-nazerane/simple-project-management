using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.EntityFrameworkCore
{
    public static class DbContextExtensions
    {

        public static void Configure(this DbContextOptionsBuilder options, 
                                        IConfiguration configuration, string migrationAssembly = null)
        {
            options.UseSqlServer(configuration.GetConnectionString("sqlDb"), o => {
                if (migrationAssembly != null) o.MigrationsAssembly(migrationAssembly);
            });
        }

    }
}
