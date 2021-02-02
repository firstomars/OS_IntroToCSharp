using System;

namespace AIE_06_IfStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 5;
            int c = 0;

            if ((a + b + c > 10) || (a == b))
            {
                Console.WriteLine("The answer is greater than 10");
                Console.WriteLine("Or A is equal to B");
            }
            else
            {
                Console.WriteLine("The answer is not greater than 10");
                Console.WriteLine("And A is not equal to B");
            }
        }
    }
}
