using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Generic.Utils
{
    public static class Randoms
    {
        private static Random rnd = new Random();

        private static string[] RandomCities = {
            "Warszawa", "Nowy Targ", "Wrocław",
            "Katowice", "Gdańsk", "Bielsko-Biała", "Żywiec"
        };

        private static string[] RandomStreets = {
            "Kosmonautów", "Grabiszyńska", "Otmuchowska",
            "Krakowska", "Kwiatowa", "Tulipanów", "Osienicka",
            "Poniatowskiego", "Trzebiatowska", "Spacerowa"
        };

        private static string[] RandomProductNames = {
            "Gitara", "Samochód", "Komputer", "Kartka", "Szklanka",
            "Telefon", "Długopis", "Myszka", "Szafka", "Lampka",
            "Łóżko", "Szafa", "Stół", "Zbiór zadań", "Szyba", "Słoik"
        };

        public static string RandomStreet()
        {
            return RandomStreets[RandomInt(0, RandomStreets.Length - 1)];
        }

        public static string RandomCity()
        {
            return RandomCities[rnd.Next(0, RandomCities.Length - 1)];
        }
        public static string RandomProductName()
        {
            return RandomProductNames[rnd.Next(0, RandomProductNames.Length - 1)];
        }

        public static string RandomString(int length = 10)
        {
            string str = "";
            for (int i = 0; i < length; i++)
                str += char.ConvertFromUtf32(rnd.Next(33, 122));

            return str;
        }

        public static string RandomZipCode()
        {
            return RandomInt(10000, 99999).ToString().Insert(2, "-");
        }

        public static int RandomInt(int min, int max)
        {
            return rnd.Next(min, max+1);
        }

        public static double RandomDouble(double min, double max)
        {
            double d = max - min;
            return rnd.NextDouble() * d + min;
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
