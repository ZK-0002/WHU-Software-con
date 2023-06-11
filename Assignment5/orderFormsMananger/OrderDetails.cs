using System;
using System.Collections.Generic;

namespace orderFormsMananger
{
    public class OrderDetails
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        
        private bool IsValid()
        {
            return Product != null && Quantity > 0;
        }
        
        public OrderDetails(Product product, int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), quantity, "Quantity must be greater than zero.");
            }
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            }
            Product = product;
            Quantity = quantity;
        }
        
        public override int GetHashCode()
        {
            return Product.GetHashCode();
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
            OrderDetails orderDetails = (OrderDetails) obj;
            return orderDetails.Product == this.Product;
        }
        
        public override string ToString()
        {
            return $"{Product} Quantity: {Quantity}";
        }
        
        public void AddOne()
        {
            Quantity++;
        }
        
        public void RemoveOne()
        {
            if (Quantity > 1)
            {
                Quantity--;
            }
        }
        
        public int GetTotalPrice()
        {
            return Product.Price * Quantity;
        }
    }
}