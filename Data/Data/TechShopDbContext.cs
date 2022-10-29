using Microsoft.EntityFrameworkCore;
using Data.Models;
using Data.Mock;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Data
{
    public class TechShopDbContext : IdentityDbContext<User>
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

            modelBuilder.Entity<User>().HasMany(u => u.Orders)
                                       .WithOne(o => o.User)
                                       .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<OperationSystem>().HasData(MockData.GetOSs());
            modelBuilder.Entity<Laptop>().HasData(MockData.GetLaptops());
        }

        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OperationSystem> OperationSystems { get; set; }
    }
}
