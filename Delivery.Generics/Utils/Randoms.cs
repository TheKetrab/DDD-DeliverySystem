using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Generic.Utils
{
    public static class Randoms
    {
        private static Random rnd = new Random();

        public static string RandomString(int length = 10)
        {
            string str = "";
            for (int i = 0; i < length; i++)
                str += char.ConvertFromUtf32(rnd.Next(33, 122));

            return str;
        }

        public static int RandomInt(int min, int max)
        {
            return rnd.Next(min, max);
        }

        public static string RandomDigitsString(int length)
        {
            string str = "";
            for (int i = 0; i < length; i++)
                str += char.ConvertFromUtf32(rnd.Next('0', '9'));

            return str;
        }

        public static string RandomPhoneNumber()
        {
            string str = "+48";

            if (rnd.Next(2) == 0)
            {
                str += " " + RandomDigitsString(3);
                str += " " + RandomDigitsString(3);
                str += " " + RandomDigitsString(3);
            }
            else
            {
                str += " " + RandomDigitsString(2);
                str += " " + RandomDigitsString(3);
                str += " " + RandomDigitsString(2);
                str += " " + RandomDigitsString(2);
            }

            return str;
        }
    }
}
