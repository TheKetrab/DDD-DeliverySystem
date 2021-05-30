using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Generic.Utils
{
    public static class Extensions
    {

        public static IEnumerable<To> Cast<From,To>(
            this IEnumerable<From> collection, Func<From,To> func)
        {
            var res = new List<To>();
            foreach (var x in collection)
                res.Add(func(x));

            return res;
        }
    }
}
