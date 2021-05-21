using System;

using Delivery.Application;
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
            string email = "mail2@gmail.com";//Console.ReadLine();
            Console.Write(" > Password (abc): ");
            string password = "abc";// Console.ReadLine();

            if (!service.VerifyPassword(email, password))
            {
                Console.WriteLine(" > Wrong credentials!");
                return;
            }

            Console.WriteLine(" > Your orders:");
            foreach (var o in service.GetOwnOrders(email))
                Console.WriteLine("\tAddress: {0}\tLatest date: {1}",
                    o.DeliveryAddress.ToString(), o.LatestDeliveryDate);

            Console.ReadLine();            
        }
    }
}
