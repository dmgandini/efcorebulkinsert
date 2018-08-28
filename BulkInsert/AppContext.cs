using Microsoft.EntityFrameworkCore;

namespace BulkInsert
{
    public class AppContext : DbContext
    {
        public DbSet<BulkInsertTable> BulkInsertTable { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=OFFICEWS;Initial Catalog=Demo;Integrated Security=True");
        }
    }
}


