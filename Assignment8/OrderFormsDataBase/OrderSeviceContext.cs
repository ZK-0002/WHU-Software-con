using System.Data.Entity;
using MySql.Data.EntityFramework;
using OrderFormsDataBase.order;

namespace OrderFormsDataBase
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class OrderSeviceContext : DbContext
    {
        public OrderSeviceContext() : base("OrderDataBase")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<OrderSeviceContext>());
        }
        
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}