using System;

namespace AIE_48_AssessmentEx2
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfElements = 30;

            GenerateFibonacciSeq(numberOfElements);

            PrintArray(GenerateFibonacciSeq(numberOfElements), numberOfElements);

            if (args.Length < 1)
            {
                Console.WriteLine("Insufficient input arguments.");
                return;
            }

            numberOfElements = Int32.Parse(args[0]);

            // TODO:
            // Write a function that will, given an integer n, calculate the first n numbers in the 
            // Fibonacci sequence given starting elements of (0, 1). 
            // Output your result to the console 
        }

        //0 1   1   2   3   5   8   13  21  34


        static int[] GenerateFibonacciSeq(int n)
        {
            int[] fSeq = new int[n];

            fSeq[0] = 0;
            fSeq[1] = 1;

            for (int i = 2; i < n; i++)
            {
                fSeq[i] = fSeq[i - 2] + fSeq[i - 1];
            }

            return fSeq;
        }

        static void PrintArray(int[] a, int n)
        {
            for(int i = 0; i < n; i++)
            {
                Console.Write(a[i] + " ");
            }
        }
    }
}
