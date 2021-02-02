using System;

namespace AIE_08_HiLow
{
    class Program
    {
        static void Main(string[] args)
        {
            string sNumber = Console.ReadLine();
            int number = int.Parse(sNumber);

            if (number > 50)
            {
                Console.WriteLine($"{number} is greater than 50.");
            }

            else if (number < 50)
            {
                Console.WriteLine($"{number} is less than 50.");
            }

            else
            {
                Console.WriteLine("SAME");
            }

        }
    }
}
