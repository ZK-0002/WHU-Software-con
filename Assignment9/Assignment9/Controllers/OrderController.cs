using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment9.Models;

namespace Assignment9.Controllers
{
    
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService orderService;

        public OrderController(OrderService orderService){
            this.orderService = orderService;
        }
        [HttpGet]
        public ActionResult<List<Order>> GetOrders()
        {
            return orderService.GetAllOrders();
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(string id)
        {
            var order=orderService.GetOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        [HttpPost]
        public  ActionResult<Order> AddOrder(Order order)
        {
            try{
                order.OrderId=Guid.NewGuid().ToString();
                orderService.AddOrder(order);
            }catch(Exception e){
                return BadRequest(e.InnerException.Message);
            }
           
            return order;
        }   

        [HttpPut("{id}")]
        public ActionResult<Order> udpateOrder(string id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }
            try{ 
                orderService.UpdateOrder(order);
            }catch(Exception e){
                string error=e.Message;
                if(e.InnerException!=null) error=e.InnerException.Message;
                return BadRequest(error);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Order> DeleteOrder(string id)
        {
            try{ 
                orderService.RemoveOrder(id);
            }catch(Exception e){
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }

    }


}