using System;
using System.Collections.Generic;
using System.Linq;

namespace orderFormsMananger
{
    public class OrderService
    {
        public List<Order> Orders { get; } = new List<Order>();

        public OrderService() {} 
        
        public void Sort()
        {
            Orders.Sort(((order, order1) => order.OrderId - order1.OrderId));
        }
        
        public void Sort(Comparison<Order> sortMethod)
        {
            Orders.Sort(sortMethod);
        }
        
        public void AddOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Order cannot be null.");
            }
            if (Orders.Contains(order))
            {
                throw new ArgumentException("Order already exists.");
            }
            Orders.Add(order);
        }
        
        public void RemoveOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Order cannot be null.");
            }
            if (!Orders.Contains(order))
            {
                throw new ArgumentException("Order does not exist.");
            }
            Orders.Remove(order);
        }
        
        public List<Order> SearchByOrderId(int orderId)
        {
            return Orders.Where(order => order.OrderId == orderId).OrderBy(order => order.OrderId).ToList();
        }

        public List<Order> SearchByCustomer(Customer customer)
        {
            return Orders.Where(order => order.Customer == customer).OrderBy(order => order.OrderId).ToList();
        }
        
        public List<Order> SearchByProductName(string productName)
        {
            return Orders.Where(order => order.Details.Any(orderDetails => orderDetails.Product.ProductName == productName)).ToList();
        }
        
        public List<Order> SearchByTotalPrice(int totalPrice)
        {
            return Orders.Where(order => order.GetTotalPrice() == totalPrice).OrderBy(order => order.OrderId).ToList();
        }
        
        public void ChangeOrderCustomer(Order order, Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer), "Customer cannot be null.");
            }
            if (!Orders.Contains(order))
            {
                throw new ArgumentException("Order does not exist.");
            }
            var newOrder = OrderUtils.CreateOrder(order);
            newOrder.Customer = customer;
            Orders.Remove(order);
            Orders.Add(newOrder);
        }
    }
}