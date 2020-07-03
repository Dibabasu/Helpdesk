using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Helpdesk.Persistence.MSSQL
{
    public class MsSqlContextFactory : IDesignTimeDbContextFactory<MsSqlHelpdeskDbContext>
    {
        public MsSqlHelpdeskDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile("appsettings.local.json", true)
                .AddEnvironmentVariables()
                .Build();

            var builder = new DbContextOptionsBuilder<HelpdeskDbContext>();
            
            builder.UseSqlServer(
                config.GetConnectionString(nameof(HelpdeskDbContext)),
                b => b.MigrationsAssembly("Helpdesk.Persistence.MSSQL")
            );
            return new MsSqlHelpdeskDbContext(builder.Options);
        }
    }
}