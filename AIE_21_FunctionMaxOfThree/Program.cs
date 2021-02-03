using System;

namespace AIE_21_FunctionMaxOfThree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the first number: ");
            string sNum1 = Console.ReadLine();
            int num1 = int.Parse(sNum1);

            Console.Write("Enter the second number: ");
            string sNum2 = Console.ReadLine();
            int num2 = int.Parse(sNum2);

            Console.Write("Enter the third number: ");
            string sNum3 = Console.ReadLine();
            int num3 = int.Parse(sNum3);

            ReturnHighestNumber(num1, num2, num3);
        }

        static int ReturnHighestNumber(int num1, int num2, int num3)
        {
            return num1;
        }
    }
}
