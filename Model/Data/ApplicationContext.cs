using Microsoft.EntityFrameworkCore;

namespace GaspromDiagnostics.Model.Data
{
    class ApplicationContext: DbContext
    {
        public DbSet<Object> Objects { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=.\\Objects.sqlite;");
        }
    }
}
