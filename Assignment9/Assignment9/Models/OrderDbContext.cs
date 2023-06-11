using Microsoft.EntityFrameworkCore;

namespace Assignment9.Models
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options)
        {
             this.Database.EnsureCreated(); 
        }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Goods> Goods { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}