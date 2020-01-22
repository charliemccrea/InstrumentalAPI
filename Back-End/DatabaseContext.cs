using Microsoft.EntityFrameworkCore;

namespace InstrumentalAPI
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

        public DbSet<Instrument> Instruments { get; set; }
    }
}