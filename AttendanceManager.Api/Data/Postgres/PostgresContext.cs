using Microsoft.EntityFrameworkCore;

namespace Giga.Monitor.Core.Data.Postgres
{
    public class PostgresContext : DbContext
    {
        public PostgresContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pgcrypto");
        }
    }
}
