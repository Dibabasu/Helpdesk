using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Helpdesk.Persistence.MSSQL
{
    public static class MsSqlServiceCollectionExtensions
    {
        public static IServiceCollection AddMssqlDbContext(
            this IServiceCollection serviceCollection,
            IConfiguration config = null)
        {
            serviceCollection.AddDbContext<HelpdeskDbContext, MsSqlHelpdeskDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("HelpdeskDbContext"), b => b.MigrationsAssembly("Helpdesk.Persistence.MSSQL"));
            });
            return serviceCollection;
        }
    }
}