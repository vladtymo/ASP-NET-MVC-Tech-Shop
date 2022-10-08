using Microsoft.EntityFrameworkCore;
using Data.Models;
using Data.Mock;

namespace Data
{
    public class TechShopDbContext : DbContext
    {
        //public TechShopDbContext() { }
        public TechShopDbContext(DbContextOptions options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TechShopDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Laptop>().HasData(MockData.GetLaptops());
        }

        public DbSet<Laptop> Laptops { get; set; }
    }
}
