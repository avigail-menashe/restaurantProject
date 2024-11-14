using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using rstaurantProject.enties;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rstaurantProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

  

    public class ClientsController : ControllerBase
    {
        private readonly DataContext _Context;
        public ClientsController(DataContext context)
        {
            _Context = context;
        }

        static int count = 3;
        // GET: api/<ClientsController>
        [HttpGet]
        public IEnumerable<Client> Get()
        {
            return _Context.clients;
        }

        // GET api/<ClientsController>/5
        [HttpGet("{id}")]
        public Client Get(int id)
        {
            int index = _Context.clients.FindIndex(c => c.Id == id);
            return _Context.clients[index];

        }

        // POST api/<ClientsController>
        [HttpPost]
        public Client Post([FromBody] Client value)
        {
            value.Id = count++;
            _Context.clients.Add(value);
                return value;
        }

        // PUT api/<ClientsController>/5
        [HttpPut("{id}")]
        public Client Put(int id, [FromBody] Client value)
        {
            int index = _Context.clients.FindIndex((Client c) => { return c.Id == id; });
            _Context.clients[index].Name = value.Name;
            _Context.clients[index].Phone =value.Phone;
            return _Context.clients[index];
        }

        // DELETE api/<ClientsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            int index = _Context.clients.FindIndex((Client c) => { return c.Id == id; });
            _Context.clients.RemoveAt(index);

        }
    }
}
