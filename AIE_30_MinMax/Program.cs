using System;
//using System.Linq;

namespace AIE_30_MinMax
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 10, 3, 6, 6, 4, 8, 1, 7 };
            var minmax = FindMinMax(numbers); //return array of 2

            Console.WriteLine(minmax[0]); // 1
            Console.WriteLine(minmax[1]); // 10
        }

        static int[] FindMinMax(int[] numbers)
        {
            int[] minmax = new int[2];

            int smallest = numbers[0];
            int largest = numbers[1];

            for (int i = 0; i <numbers.Length; i++)
            {

                if (numbers[i] < smallest)
                    smallest = numbers[i];

                if (numbers[i] > largest)
                    largest = numbers[i];
            }

            //int maxValue = numbers.Max();
            //int minValue = numbers.Min();
            //int maxIndex = numbers.ToList().IndexOf(maxValue);
            minmax[0] = smallest;
            minmax[1] = largest;

            return minmax;
        }

    }
}
