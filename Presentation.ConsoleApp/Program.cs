using System;

using Delivery.Application;
using Delivery.Domain.Model.Clients;
using Delivery.Generic.Security;

namespace Presentation.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IDeliveryService service = new DeliveryService();

            Console.WriteLine(" ----- DELIVERY SYSTEM ----- ");
            Console.WriteLine(" > Login first, put your email and password");
            Console.Write(" > Email (admin@gmail.com): ");
            string email = "admin@gmail.com";//Console.ReadLine();
            Console.Write(" > Password (abc): ");
            string password = "abc";// Console.ReadLine();

            Client currentClient = service.GetClientByEmail(email);

            if (!service.VerifyPassword(currentClient, password))
            {
                Console.WriteLine(" > Wrong credentials!");
                return;
            }

            Console.WriteLine(" > Your orders:");
            foreach (var o in service.GetClientOrders(currentClient))
                Console.WriteLine("\tLatest date: {0}\tAddress: {1}",
                    o.LatestDeliveryDate, o.DeliveryAddress.ToString());

            Console.ReadLine();            
        }
    }
}
