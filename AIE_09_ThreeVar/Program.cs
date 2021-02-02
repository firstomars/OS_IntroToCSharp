using System;

namespace AIE_09_ThreeVar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a value for the first number");

            string sNum1 = Console.ReadLine();
            int num1 = int.Parse(sNum1);

            Console.WriteLine($"The first number is {sNum1}");

            Console.WriteLine("Enter a value for the second number");

            string sNum2 = Console.ReadLine();
            int num2 = int.Parse(sNum2);

            Console.WriteLine($"The second number is {sNum2}");

            Console.WriteLine("Enter a value for the third number");

            string sNum3 = Console.ReadLine();
            int num3 = int.Parse(sNum3);

            Console.WriteLine($"The second number is {sNum3}");

            if ((num1 > num2) && (num1 > num3))
            {
                Console.WriteLine($"Number 1, {num1} is the greatest");
            }

            else if ((num2 > num1) && (num2 > num3))
            {
                Console.WriteLine($"Number 2, {num2} is the greatest");
            }

            else
            {
                Console.WriteLine($"Number 3, {num3} is the greatest");
            }

        }
    }
}
