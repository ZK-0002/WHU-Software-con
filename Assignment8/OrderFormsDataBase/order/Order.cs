using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderFormsDataBase.order {

    public class Order : IComparable<Order> {

        public List<OrderDetail> details { get; set; } = new List<OrderDetail>();

        public int Id { get; set; }

        public Customer Customer { get; set; }
        
        public int CustomerId { get; set; }

        public DateTime CreateTime { get; set; }
        
        public OrderService OrderService { get; set; }
        
        public float TotalPrice {
            get => Details.Sum(d => d.TotalPrice);
        }

        public List<OrderDetail> Details => details;

        public Order() {
            CreateTime = DateTime.Now;
        }

        public Order(int orderId, Customer customer, DateTime creatTime) {
            Id = orderId;
            Customer = customer;
            CreateTime = creatTime;
        }

        public void AddDetails(OrderDetail orderDetail) {
            if (Details.Contains(orderDetail)) {
                throw new ApplicationException($"The goods ({orderDetail.Goods.Name}) exist in order {Id}");
            }
            Details.Add(orderDetail);
        }

        public int CompareTo(Order other) {
            return (other == null)?1: Id - other.Id;
        }

        public override bool Equals(object obj) {
            var order = obj as Order;
            return order != null && Id == order.Id;
        }

        public override int GetHashCode() {
            return Id.GetHashCode();
        }

        public void RemoveDetails(int num) {
            Details.RemoveAt(num);
        }

        public override string ToString() {
            StringBuilder result = new StringBuilder();
            result.Append($"orderId:{Id}, customer:({Customer})");
            Details.ForEach(detail => result.Append("\n\t" + detail));
            return result.ToString();
        }

    }
}
