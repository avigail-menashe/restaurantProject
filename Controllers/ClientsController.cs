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

        public static List<Client> clients = new List<Client>
        {
            new Client{Id=1,Phone="1111", Name="Avigail"},
            new Client{Id=2,Phone="5555", Name="Yael"}

        };
        static int count = 3;
        // GET: api/<ClientsController>
        [HttpGet]
        public IEnumerable<Client> Get()
        {
            return clients;
        }

        // GET api/<ClientsController>/5
        [HttpGet("{id}")]
        public Client Get(int id)
        {
            int index = clients.FindIndex(c => c.Id == id);
            return clients[index];

        }

        // POST api/<ClientsController>
        [HttpPost]
        public Client Post([FromBody] Client value)
        {
            value.Id = count++;
            clients.Add(value);
                return value;
        }

        // PUT api/<ClientsController>/5
        [HttpPut("{id}")]
        public Client Put(int id, [FromBody] Client value)
        {
            int index = clients.FindIndex((Client c) => { return c.Id == id; });
            clients[index].Name = value.Name;
            clients[index].Phone =value.Phone;
            return clients[index];
        }

        // DELETE api/<ClientsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            int index = clients.FindIndex((Client c) => { return c.Id == id; });
            clients.RemoveAt(index);

        }
    }
}
