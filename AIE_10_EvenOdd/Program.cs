using System;

namespace AIE_10_EvenOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number and we'll tell you if it's even or odd");

            string sNum = Console.ReadLine();
            int num = int.Parse(sNum);
            
            //int number = 5;

            /*
            if(num % 2 == 0)
            {
                Console.WriteLine($"{num} is even.");
            }

            else
            {
                Console.WriteLine($"{num} is odd.");
            }
            */

            // (condition) ? (true statement) : (flase statement)

            Console.WriteLine((num % 2 == 0 ? $"{num} is even." : $"{num} is odd."));
        }
    }
}
