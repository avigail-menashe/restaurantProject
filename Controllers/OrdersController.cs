using Microsoft.AspNetCore.Mvc;
using rstaurantProject.enties;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rstaurantProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        public static List<Order> orders = new List<Order>
        {
            new Order{OrderId=1, OrderDate=new DateTime(), OrderStatus =" yyy",Totalcost=-1}
            

        };
        static int count = 2;

        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return orders;
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            int index = orders.FindIndex(o => o.OrderId == id);
            return orders[index];
        }

        // POST api/<OrdersController>
        [HttpPost]
        public Order Post([FromBody]Order value)
        {
            value.OrderId = count++;
            orders.Add(value);
            return value;
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public Order Put(int id, [FromBody]Order value)
        {
            int index = orders.FindIndex((Order o) => { return o.OrderId == id; });
            orders[index].OrderDate = value.OrderDate;
            orders[index].OrderStatus = value.OrderStatus;
            orders[index].Totalcost = value.Totalcost;  
            return orders[index];
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            int index = orders.FindIndex((Order o) => { return o.OrderId == id; });
            orders.RemoveAt(index);
        }
    }
}
