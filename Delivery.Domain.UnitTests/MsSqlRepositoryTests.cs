using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.UnitTests
{
    [TestClass]
    public class MsSqlRepositoryTests
    {
        public MsSqlRepositoryTests()
        {
            // TODO Recreate tables (run script)
            Console.WriteLine("Start");
        }

        ~MsSqlRepositoryTests()
        {
            // TODO Cleanup test tables (run script)
            Console.WriteLine("End");
        }

        [TestMethod]
        public void T1()
        {
            // TODO CRUD tests
        }
    }
}
