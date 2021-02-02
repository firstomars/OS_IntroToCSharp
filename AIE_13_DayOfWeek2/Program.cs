using System;

namespace AIE_13_DayOfWeek2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type in a day of the week, and we'll give you a corresponding number.");

            string dayOfWeek = Console.ReadLine();
            dayOfWeek = dayOfWeek.ToLower();
            dayOfWeek = dayOfWeek.Trim();
            dayOfWeek = dayOfWeek.Replace(" ", "");

            if(dayOfWeek == "monday")
            {
                Console.Write("1");
            }

            if (dayOfWeek == "tuesday")
            {
                Console.Write("2");
            }

            if (dayOfWeek == "wednesday")
            {
                Console.Write("3");
            }

            if (dayOfWeek == "thursday")
            {
                Console.Write("4");
            }

            if (dayOfWeek == "friday")
            {
                Console.Write("5");
            }

            if (dayOfWeek == "saturday")
            {
                Console.Write("6");
            }

            if (dayOfWeek == "sunday")
            {
                Console.Write("7");
            }
        }
    }
}
