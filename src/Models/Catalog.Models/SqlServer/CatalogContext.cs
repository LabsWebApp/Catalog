using Catalog.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Models.SqlServer
{
    public class CatalogContext : DbContext
    {
        public DbSet<Entities.Catalog> Catalogs { get; set; }
        public DbSet<Good> Goods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ЗАМЕНИТЬ НА СВОЮ:
            string connectionString =
                @"Data Source=(local)\SQLEXPRESS; Database=CatalogDB; Persist Security Info=false; User ID='sa'; Password='sa'; MultipleActiveResultSets=True; Trusted_Connection=False;";

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Весь код в этом методе для простоты заполнения каталога в ручную
            modelBuilder.Entity<Entities.Catalog>()
                .Property(p => p.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<Good>()
                .Property(p => p.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            modelBuilder.Entity<Good>()
                .Property(g => g.Count).HasDefaultValue(10);
            modelBuilder.Entity<Good>()
                .Property(g => g.Price).HasDefaultValue(100);
            modelBuilder.Entity<Good>()
                .Property(g => g.Name).HasDefaultValue("Плохой товар");
        }
    }
}
