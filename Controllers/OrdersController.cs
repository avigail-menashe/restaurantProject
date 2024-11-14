using Microsoft.AspNetCore.Mvc;
using rstaurantProject.enties;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rstaurantProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly DataContext _context;

        public OrdersController(DataContext context)
        {
            _context = context;
        }
        static int count = 2;

        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _context.orders;
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            int index = _context.orders.FindIndex(o => o.OrderId == id);
            return _context.orders[index];
        }

        // POST api/<OrdersController>
        [HttpPost]
        public Order Post([FromBody]Order value)
        {
            value.OrderId = count++;
            _context.orders.Add(value);
            return value;
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public Order Put(int id, [FromBody]Order value)
        {
            int index = _context.orders.FindIndex((Order o) => { return o.OrderId == id; });
            _context.orders[index].OrderDate = value.OrderDate;
            _context.orders[index].OrderStatus = value.OrderStatus;
            _context.orders[index].Totalcost = value.Totalcost;  
            return _context.orders[index];
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            int index = _context.orders.FindIndex((Order o) => { return o.OrderId == id; });
            _context.orders.RemoveAt(index);
        }
    }
}
