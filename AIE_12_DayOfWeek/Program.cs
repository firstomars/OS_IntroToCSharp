using System;

namespace AIE_12_DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter a number between 1 and 7, and we'll tell you the corresponding day of the week.");
            string sNum = Console.ReadLine();
            int num = int.Parse(sNum);

            if(num == 1)
            {
                Console.WriteLine("Monday");
            }

            else if (num == 2)
            {
                Console.Write("Tuesday");
            }

            else if (num == 3)
            {
                Console.Write("Wednesday");
            }

            else if (num == 4)
            {
                Console.Write("Thursday");
            }

            else if (num == 5)
            {
                Console.Write("Friday");
            }

            else if (num == 6)
            {
                Console.Write("Saturday");
            }

            else if (num == 7)
            {
                Console.Write("Sunday");
            }

        }
    }
}
