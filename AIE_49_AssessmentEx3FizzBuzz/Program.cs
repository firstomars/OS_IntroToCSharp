using System;

namespace AIE_49_AssessmentEx3FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's play FizzBuzz. What number should we go up to?");

            string num = Console.ReadLine();
            
            int numberOfElements = int.Parse(num);

            FizzBuzz(numberOfElements);

            if (args.Length < 1)
            {
                Console.WriteLine("Insufficient input arguments.");
                return;
            }

            numberOfElements = Int32.Parse(args[0]);
        }

        // TODO:
        // Write a function to generate output according to the FizzBuzz project brief

        static void FizzBuzz(int n)
        {
            //If i is a multiple of both 3 and 5, print FizzBuzz.

            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 != 0)
                {
                    Console.WriteLine($"{i} Fizz");
                }

                else if (i % 3 != 0 && i % 5 == 0)
                {
                    Console.WriteLine($"{i} Buzz");
                }
                
                else if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine($"{i} FizzBuzz");
                }

                else
                {
                    Console.WriteLine(i);
                }

                
            }

            //If i is a multiple of 3(but not 5), print Fizz.
            //If i is a multiple of 5(but not 3), print Buzz.
            //If i is not a multiple of 3 or 5, print the value of i.
        }

        // The function must print the appropriate response for each value i in the 
        // set {1, 2, ... n} in ascending order, each on a separate line

    }
}
