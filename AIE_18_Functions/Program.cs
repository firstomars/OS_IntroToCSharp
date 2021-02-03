using System;

namespace AIE_18_Functions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number for 'A':");

            string numA = Console.ReadLine();
            int a = int.Parse(numA);

            Console.Write("Enter a number for 'B':");

            string numB = Console.ReadLine();
            int b = int.Parse(numB);

            MinusTwoNumbers(a, b);

            Console.WriteLine($"{a} minus {b} = {MinusTwoNumbers(a, b)}");
        }

        static int MinusTwoNumbers(int a, int b)
        {
            int result = a - b;
            return result;
        }
    }
}
