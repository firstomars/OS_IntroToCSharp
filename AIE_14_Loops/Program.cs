using System;

namespace AIE_14_Loops
{
    class Program
    {
        static void Main(string[] args)
        {

            // Nine Times Tables
            
            Console.WriteLine("For Loop");

            for (int i = 0; i <= 10; i++)
            {
                //int multiplication = i * 9;

                //Console.WriteLine($"{i} x 9 = {multiplication}");
                Console.WriteLine($"{i} x 9 = {i * 9}");
            }

            Console.WriteLine(" ");
            Console.WriteLine("While Loop");

            int j = 0;

            while (j <= 10)
            {
                int multiplied = j * 9;
                Console.WriteLine($"{j} x 9 = {multiplied}");
                j++;
            }

            Console.WriteLine(" ");
            Console.WriteLine("Do Loop");

            int k = 0;

            do
            {
                int multi = k * 9;
                Console.WriteLine($"{k} x 9 = {multi}");
                k++;
            } while (k < 5);
        }
    }
}
