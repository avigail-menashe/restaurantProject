using rstaurantProject.enties;

namespace rstaurantProject
{
    public class DataContext

    {
        public List<Client> clients {  get; set; } 
        public List <Order> orders { get; set; }
        public DataContext() {
            orders = new List<Order>
            {
                 new Order{OrderId=1, OrderDate=new DateTime(), OrderStatus =" yyy",Totalcost=-1}

            };
            clients = new List<Client>()
            {
                new Client{Id=1,Phone="1111", Name="Avigail"},
                new Client{Id=2,Phone="5555", Name="Yael"}
            };

        }
    }
}
