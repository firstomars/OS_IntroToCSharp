using System;

namespace AIE_11_Divisible
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number and we'll tell if it is divisble by 4 or 6");

            string sNum = Console.ReadLine();
            int num = int.Parse(sNum);

            if (num % 4 == 0 && num % 6 == 0)
            {
                Console.WriteLine($"{num} is divisible by 4 and 6.");
            }

            else if (num % 4 == 0)
            {
                Console.WriteLine($"{num} is divisble by 4.");
            }

            else if (num % 6 == 0)
            {
                Console.WriteLine($"{num} is divisble by 6.");
            }

            else
            {
                Console.WriteLine($"{num} is not divisible by 4 or 6.");
            }
        }
    }
}
