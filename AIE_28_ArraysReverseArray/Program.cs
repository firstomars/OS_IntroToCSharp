using System;

namespace AIE_28_ArraysReverseArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 10, 3, 6, 6, 4, 8, 1, 7 };

            var reversed = ReverseArray(numbers); // returns array


            for (int i = 0; i < numbers.Length; i++)
                Console.Write($"{numbers[i]}, ");

            Console.WriteLine("");

            for (int i = 0; i < reversed.Length; i++)
                Console.Write($"{reversed[i]}, ");
        }

        static int[] ReverseArray(int[] numbers)
        {
            int arrayLength = numbers.Length;

            int[] reversed1 = new int[arrayLength];

            

            for (int i = 0; i < arrayLength; i++)
            {
                reversed1[arrayLength - 1 - i] = numbers[i];
            }

            return reversed1;
        }
    }
}
