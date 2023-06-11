using System;

namespace orderFormsMananger
{
    internal class Program
    {
        private static Product Apple = OrderUtils.CreateProduct("Apple", 10);
        private static Product Orange = OrderUtils.CreateProduct("Orange", 20);
        private static Product Banana = OrderUtils.CreateProduct("Banana", 30);
        private static Product Watermelon = OrderUtils.CreateProduct("Watermelon", 40);

        private static int ReadPurchaseNum()
        {
            Console.WriteLine("请输入购买数量：");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("输入不能为空！");
            }
            return int.Parse(input);
        }

        private static void ChooseProduct(Order order, string input)
        {
            switch (input)
            {
                case "1":
                    var orderDetails = OrderUtils.CreateOrderDetails(Apple, ReadPurchaseNum());
                    order.AddOrderDetails(orderDetails);
                    break;
                case "2":
                    orderDetails = OrderUtils.CreateOrderDetails(Orange, ReadPurchaseNum());
                    order.AddOrderDetails(orderDetails);
                    break;
                case "3":
                    orderDetails = OrderUtils.CreateOrderDetails(Banana, ReadPurchaseNum());
                    order.AddOrderDetails(orderDetails);
                    break;
                case "4":
                    orderDetails = OrderUtils.CreateOrderDetails(Watermelon, ReadPurchaseNum());
                    order.AddOrderDetails(orderDetails);
                    break;
                default:
                    Console.WriteLine("输入有误！");
                    break;
            }
        }
        
        private static void AddOrderDetails(Order order)
        {
            while (true)
            {
                Console.WriteLine("请选择要购买的商品：1 Apple 2 Orange 3 Banana 4 Watermelon q 退出并提交订单");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                ChooseProduct(order, input);
            }
        }

        private static Customer ReadCustomer()
        {
            Console.WriteLine("请输入客户名：");
            var name = Console.ReadLine();
            Console.WriteLine("请输入客户地址：");
            var address = Console.ReadLine();
            return OrderUtils.CreateCustomer(name, address);
        }
        
        
        public static void Main(string[] args)
        {
            var orderService = new OrderService();
            var order = new Order();
            var customer = ReadCustomer();
            order.Customer = customer;
            AddOrderDetails(order);
            orderService.AddOrder(order);
            Console.WriteLine($"当前订单：{order}");
        }
    }
}