namespace orderFormsMananger
{
    public class Product
    {
        public int Price { get; set; }
        public string ProductName { get; set; }
        
        public Product(int price, string productName)
        {
            this.Price = price;
            this.ProductName = productName;
        }

        public override int GetHashCode()
        {
            return (ProductName.GetHashCode() + Price).GetHashCode();
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
            var product = (Product) obj;
            return product.ProductName == this.ProductName && product.Price == this.Price;
        }
        
        public override string ToString()
        {
            return $"{ProductName} Price: {Price}";
        }
    }
}