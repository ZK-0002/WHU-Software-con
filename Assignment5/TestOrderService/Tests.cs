using System;
using NUnit.Framework;
using System.Collections.Generic;
using orderFormsMananger;
using static orderFormsMananger.OrderUtils;

namespace TestOrderService
{
    
    [TestFixture]
    public class Tests
    {
        private static Product Apple = CreateProduct("Apple", 10);
        private static Product Orange = CreateProduct("Orange", 20);
        private static Product Banana = CreateProduct("Banana", 30);
        private static Product Watermelon = CreateProduct("Watermelon", 40);
        private static Customer Smith = CreateCustomer("Smith", "USA");
        private static Customer Jones = CreateCustomer("Jones", "UK");
        private static Customer Brown = CreateCustomer("Brown", "China");
        private static Customer Davis = CreateCustomer("Davis", "Japan");
        
        private static OrderService _orderService;
        private static Order _order1;
        private static Order _order2;
        private static Order _order3;
        private static Order _order4;
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var orderService = new OrderService();
            var order1 = CreateOrder(Smith, Apple, 10);
            var order2 = CreateOrder(Jones, Orange, 20);
            var order3 = CreateOrder(Brown, Banana, 30);
            var order4 = CreateOrder(Smith, Banana, 40);
            order1.AddOneProduct(Apple);
            var orderDetail1 = CreateOrderDetails(Watermelon, 30);
            order1.AddOrderDetails(orderDetail1);
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            orderService.AddOrder(order3);
            orderService.AddOrder(order4);
            _orderService = orderService;
            _order1 = order1;
            _order2 = order2;
            _order3 = order3;
            _order4 = order4;
        }
        
        [Test]
        public void TestSort()
        {
            _orderService.Sort();
            List<Order> orders = new List<Order>(){_order1, _order2, _order3, _order4};
            Assert.AreEqual(orders, _orderService.Orders);
            _orderService.Sort(((order, order1) => order.GetTotalPrice().CompareTo(order1.GetTotalPrice())));
            orders = new List<Order>(){_order2, _order3, _order4, _order1};
            Assert.AreEqual(orders, _orderService.Orders);
            _orderService.Sort(((order, order1) => order.Customer.Name.CompareTo(order1.Customer.Name)));
            orders = new List<Order>(){_order3, _order2, _order4, _order1};
            Assert.AreEqual(orders, _orderService.Orders);
        }
        
        [Test]
        public void TestBadAddRemoveOrder()
        {
            Assert.Throws<ArgumentNullException>(() => _orderService.AddOrder(null));
            var test = new OrderService();
            Assert.Throws<ArgumentException>(() => test.RemoveOrder(_order1));
        }
        
        [Test]
        public void TestSearch()
        {
            var orders = _orderService.SearchByOrderId(0);
            Assert.AreEqual(1, orders.Count);
            Assert.AreEqual(_order1, orders[0]);
            
            orders = _orderService.SearchByCustomer(Smith);
            Assert.AreEqual(2, orders.Count);
            Assert.AreEqual(_order1, orders[0]);
            
            orders = _orderService.SearchByProductName("Apple");
            Assert.AreEqual(1, orders.Count);
            Assert.AreEqual(_order1, orders[0]);
            
            orders = _orderService.SearchByTotalPrice(30);
            Assert.AreEqual(0, orders.Count);
        }

        [Test]
        public void TestPrint()
        {
            var str = _order1.ToString();
            Console.WriteLine(_order1);
            Assert.True(true);
        }
        
        [Test]
        public void TestChangeOrder()
        {
            var newOrderService = new OrderService();
            newOrderService.AddOrder(_order1);
            newOrderService.AddOrder(_order2);
            newOrderService.AddOrder(_order3);
            newOrderService.ChangeOrderCustomer(_order1, Davis);
            Assert.AreEqual(Davis, newOrderService.Orders[2].Customer);
            Assert.AreEqual(_order1.GetTotalPrice(), newOrderService.Orders[2].GetTotalPrice());
        }
    }
}