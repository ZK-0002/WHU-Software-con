using System;
using System.Collections.Generic;

namespace orderFormsMananger
{
    public class Order
    {
        private static int _orderCount;
        
        public List<OrderDetails> Details { get; set; } = new List<OrderDetails>();
        public int OrderId { get; }
        public string TimeStamp { get; set; }
        public Customer Customer { get; set; }

        public Order()
        {
            OrderId = _orderCount;
            _orderCount++;
            TimeStamp = System.DateTime.Now.ToString();
        }

        public void AddOrderDetails(OrderDetails orderDetails)
        {
            if (Details.Contains(orderDetails))
            {
                Console.WriteLine("Could not add existing order details.");
                return;    
            }
            Details.Add(orderDetails);
        }

        public void RemoveOrderDetails(OrderDetails orderDetails)
        {
            if (Details.Contains(orderDetails))
            {
                Details.Remove(orderDetails);
            }
        }

        public int GetTotalPrice()
        {
            int totalPrice = 0;
            if (Details.Count != 0)
            {
                foreach (var orderDetails in Details)
                {
                    totalPrice += orderDetails.GetTotalPrice();
                }
            }
            return totalPrice;
        }
        
        public void AddOneProduct(Product product)
        {
            var orderDetails = OrderUtils.CreateOrderDetails(product, 1);
            Details.ForEach((details =>
            {
                if (details.Equals(orderDetails) )
                {
                    details.AddOne();
                    return;
                }
            }));
        }
        
        public void RemoveOneProduct(Product product)
        {
            var orderDetails = OrderUtils.CreateOrderDetails(product, 1);
            Details.ForEach((details =>
            {
                if (details.Equals(orderDetails) )
                {
                    details.RemoveOne();
                    return;
                }
            }));
        }
        
        public override int GetHashCode()
        {
            return (OrderId + TimeStamp.GetHashCode() + Customer.GetHashCode() + Details.GetHashCode()).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            Order order = (Order)obj;
            return order.OrderId == this.OrderId;
        }

        public override string ToString()
        {
            string details = "";
            Details.ForEach((detail) => details += detail.ToString() + ", ");
            return $"Order ID: {OrderId} TimeStamp: {TimeStamp} Customer: {Customer} Details: {details}" + $"Total Price: {GetTotalPrice()}";
        }
    }
}