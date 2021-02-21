using System;

namespace AIE_47_AssessmentMuckAround
{
    class Program
    {
        static void Main(string[] args)
        {
            float firstNumber = 8.54f;
            float secondNumber = 6.8f;

            // Output your result to the console 
            Console.WriteLine(AddNumbers(firstNumber, secondNumber));

            if (args.Length < 2) //?
            {
                Console.WriteLine("Insufficient input arguments.");
                return;
            }

            firstNumber = float.Parse(args[0]); //what to do with these lines?
            secondNumber = float.Parse(args[1]);
        }
        static int AddNumbers(float a, float b)
        {
            // Write a function that will sum the two input floating point numbers
            // and return an integer
            int sum = (int)(a + b);
            return sum;
        }
    }
}
