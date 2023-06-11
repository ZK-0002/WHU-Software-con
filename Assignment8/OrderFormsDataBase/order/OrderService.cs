using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderFormsDataBase.order {

    public class OrderService {

        public int OrderServiceId { get; set; }

        public OrderService() {
        }

        private static Order FixOrder(Order order) {
            if (order == null)
            {
                throw new ApplicationException("order is null!");
            }
            order.CustomerId = order.Customer.Id;
            order.Customer = null;
            return order;
        }
        
        public void AddOrder(Order order) {
            using (var db = new OrderSeviceContext())
            {
                if (db.Orders.Count() == 0)
                {
                    order.Id = 1;
                }
                else
                {
                    order.Id = db.Orders.Max(o => o.Id) + 1;
                }
                db.Orders.Add(FixOrder(order));
                db.SaveChanges();
            }
        }

        public void Update(Order order) {
            using (var db = new OrderSeviceContext())
            {
                db.Entry(order).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            
        }

        public Order GetById(int orderId) {
            using (var db = new OrderSeviceContext())
            {
                return db.Orders.Where(o => o.Id == orderId).FirstOrDefault();
            }
        }

        public void RemoveOrder(int orderId) {
            using (var db = new OrderSeviceContext())
            {
                db.Orders.Remove(db.Orders.Where(o => o.Id == orderId).FirstOrDefault());
                db.SaveChanges();
            } 
        }

        public List<Order> QueryAll() {
            var orders = new List<Order>();
            using (var db = new OrderSeviceContext())
            {
                db.Orders.ToList().ForEach(o => orders.Add(o));
            }
            return orders;
        }

        public List<Order> QueryByCustomerName(string customerName) {
            var query = orders
                .Where(o => o.Customer.Name == customerName)
                .OrderBy(o => o.TotalPrice);
            return query.ToList();
        }

        public List<Order> QueryByGoodsName(string goodsName) {
            var query = orders.Where(
              o => o.Details.Any(d => d.Goods.Name == goodsName))
                .OrderBy(o => o.TotalPrice);
            return query.ToList();
        }

        public List<Order> QueryByTotalPrice(float totalPrice) {
            var query = orders.Where(o => o.TotalPrice >= totalPrice)
                .OrderBy(o => o.TotalPrice);
            return query.ToList();
        }

        public void Sort(Comparison<Order> comparison) {
            orders.Sort(comparison);
        }

        public IEnumerable<Order> Query(Predicate<Order> condition) {
            return orders.Where(o => condition(o)).OrderBy(o=>o.TotalPrice);
        }

    }
}
