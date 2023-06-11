namespace orderFormsMananger
{
    public class Customer
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public Customer(string name, string location)
        {
            this.Name = name;
            this.Location = location;
        }
        
        public override string ToString()
        {
            return $"Name: {Name}, Location: {Location}";
        }
        
        public override int GetHashCode()
        {
            return (Name.GetHashCode() + Location.GetHashCode()).GetHashCode();
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
            Customer customer = (Customer) obj;
            return customer.Name == this.Name && customer.Location == this.Location;
        }
    }
}