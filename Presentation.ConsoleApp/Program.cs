using System;

using Delivery.Application;

namespace Presentation.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IDeliveryService service = new DeliveryService();

            Console.WriteLine(" ----- DELIVERY SYSTEM ----- ");
            Console.WriteLine(" > Login first, put your email and password");
            Console.Write(" > Email (theadmin@xyz.pl): ");
            string email = Console.ReadLine();
            Console.Write(" > Password (aaa): ");
            string password = Console.ReadLine();

            if (!service.VerifyPassword(email, password))
            {
                Console.WriteLine(" > Wrong credentials!");
                return;
            }

            Console.WriteLine(" > Your orders:");
            foreach (var o in service.GetOwnOrders(email))
                Console.WriteLine("\t Owner: {0}\t status: {1}", o.Owner.Name, o.Status);

            Console.ReadLine();            
        }
    }
}
