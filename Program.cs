using Newtonsoft.Json;
namespace C_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var store = new Store();
            store.AddProduct(new Product { ID = 1, Name = "laptop", Price = 1000m });
            store.AddProduct(new Product { ID = 2, Name = "Phone", Price = 500m });
            store.AddProduct(new Product { ID = 3, Name = "laptop2", Price = 1000m });
            store.AddProduct(new Product { ID = 4, Name = "Phone2", Price = 500m });

            var order = new CustomerOrder
            {
                CustomerName = "John Smith",
                CustomerAddress = "123 main st",
                CustomerPhone = "555-1234"
            };
            var laptop = store.FindProductByName("Laptop").FirstOrDefault();
            var phone = store.FindProductByName("Phone").FirstOrDefault();
            if(laptop.ID!=0) { order.AddProduct(laptop, 1); }
            if(phone.ID!=0) { order.AddProduct(phone, 2);}
            //Сохраняем заказ
            store.AddOrder(order);

            Console.WriteLine(JsonHelper.SerializeObject(order));
            JsonHelper.SaveToFile(order, "order.json");

            var loadOrder = JsonHelper.LoadFromFile<CustomerOrder>("order.json");
            Console.WriteLine("\nLoaded Order: ");
            Console.WriteLine("Customer: " + loadOrder.CustomerName);
            Console.WriteLine("Total Price: " + loadOrder.GetTotalPrice());

            //Поиск заказов клиента
            var customerOrders = store.FindCustomerOrderByName("John Smith");
            Console.WriteLine("\nOrders for John Smith");
            foreach(var customerOrder in customerOrders)
            {
                Console.WriteLine("Order Total: " + customerOrder.GetTotalPrice());
            }

        }
    }
}
