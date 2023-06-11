using System;
using System.Data.Entity;
using System.Linq;
using OrderFormsDataBase.order;

namespace OrderFormsDataBase
{
    internal class Program
    {
        static int newOrderId = 0;
        static int newCustomerId = 0;

        private static void AddOrder()
        {
            using (var context = new OrderSeviceContext())
            {
                var order1 = new Order()
                {
                    Id = newOrderId,
                    Customer = new Customer()
                    {
                        Id = newCustomerId,
                        Name = "Customer1"
                    },
                    CreateTime = DateTime.Now
                };
                order1.AddDetails(new OrderDetail()
                {
                    Goods = new Goods()
                    {
                        Name = "apple",
                        Price = 5.5f
                    },
                    Quantity = 10
                });
                context.Orders.Add(order1);
                context.SaveChanges();
                newOrderId++;
                newCustomerId++;
            }

        }
        
        public static void Main(string[] args)
        {
            using (var context = new OrderSeviceContext())
            {
                var customer2 = new Customer()
                {
                    Id = newCustomerId,
                    Name = "Customer2"
                };
                context.Customers.Add(customer2);
                context.SaveChanges();
            }

            using (var context = new OrderSeviceContext())
            {
                var orderdetail2 = new OrderDetail()
                {
                    Goods = new Goods()
                    {
                        Name = "banana",
                        Price = 3.5f
                    },
                    Quantity = 20,
                    OrderId = newOrderId
                };
                context.Entry(orderdetail2).State = EntityState.Added;
                context.SaveChanges();
            }

            using (var context = new OrderSeviceContext())
            {
                var order = context.Orders.FirstOrDefault(o => o.Id == newOrderId);
                Console.WriteLine(order);
            }
        }
    }
}