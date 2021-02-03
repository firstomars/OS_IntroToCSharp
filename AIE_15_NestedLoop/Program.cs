using System;

namespace AIE_15_NestedLoop
{
    class Program
    {
        static void Main(string[] args)
        {

            //All Times Tables

            Console.WriteLine(" ");

            Console.WriteLine("Nested For Loop");

            for (int i = 0; i <= 10; i++)
            {
                for (int k = 0; k <= 10; k++)
                {
                    int multi = i * k;

                    Console.WriteLine($"{i} x {k} = {multi}");
                }
            }

            Console.WriteLine(" ");

            Console.WriteLine("Nested While Loop");


            int a = 0;

            while (a <= 10)
            {
                int b = 0;

                while (b <= 10)
                {
                    int m = a * b;
                    Console.WriteLine($"{a} x {b} = {m}");
                    b++;
                }

                a++;
            }

            Console.WriteLine(" ");

            Console.WriteLine("Nested Do Loop");

            int x = 0;

            do
            {
                int y = 0;

                do
                {

                    int mu = x * y;

                    Console.WriteLine($"{x} x {y} = {mu}");
                    y++;

                } while (y <= 10);

                x++;

            } while (x <= 10);
        }
    }
}
