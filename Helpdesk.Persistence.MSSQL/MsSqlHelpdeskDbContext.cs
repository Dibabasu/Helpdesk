using Microsoft.EntityFrameworkCore;

namespace Helpdesk.Persistence.MSSQL
{
    public class MsSqlHelpdeskDbContext : HelpdeskDbContext
    {
        public MsSqlHelpdeskDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}