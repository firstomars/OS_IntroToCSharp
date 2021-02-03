﻿using System;

namespace AIE_17_BranchesLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            //Now that you've seen the if statement and the looping constructs in the C# language, see if you can write C# code to find the sum of all integers 1 through 20 that are divisible by 3. Here are a few hints:

            //The % operator gives you the remainder of a division operation.
            //The if statement gives you the condition to see if a number should be part of the sum.
            //The for loop can help you repeat a series of steps for all the numbers 1 through 20.
            //Try it yourself.Then check how you did.As a hint, you should get 63 for an answer.

            int sum = 0;

            for (int i = 0; i <= 20; i++)
            {

                if (i % 3 == 0)
                {
                    sum += i;
                    Console.WriteLine($"{sum}");
                }
            }

        }
    }
}
