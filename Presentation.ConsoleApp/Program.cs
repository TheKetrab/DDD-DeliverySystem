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
            Console.Write(" > Email (mail1@gmail.com): ");
            string email = Console.ReadLine();
            Console.Write(" > Password (abc): ");
            string password = Console.ReadLine();

            if (!service.VerifyPassword(email, password))
            {
                Console.WriteLine(" > Wrong credentials!");
                return;
            }

            Console.WriteLine(" > Your orders:");
            foreach (var o in service.GetOwnOrders(email))
                Console.WriteLine("\t Latest date: {0}\t Status: {1}",
                    o.LatestDeliveryDate, o.Status);

            Console.ReadLine();            
        }
    }
}
