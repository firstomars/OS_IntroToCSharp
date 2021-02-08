using System;

namespace AIE_27_ArraysCalculateAvg
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 10, 3, 6, 6, 4, 8, 1, 7 };

            float avgOfNumbers = CalculateAverage(numbers);

            Console.WriteLine($"The average of all numbers is {avgOfNumbers}");
        }

        static float CalculateAverage(int[] numbers)
        {
            int sumOfNumbers = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                sumOfNumbers += numbers[i];
            }

            return sumOfNumbers / (float)numbers.Length;
        }
    }
}
