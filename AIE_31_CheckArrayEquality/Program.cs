using System;

namespace AIE_31_CheckArrayEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers1 = new int[] { 10, 3, 6, 6, 4, 8, 1, 7 };
            var numbers2 = new int[] { 10, 3, 6, 6, 4, 8, 1, 7 };
            var numbers3 = new int[] { 10, 3, 6, 6, 6, 8, 1, 7 };

            Console.WriteLine(CheckArrayEquality(numbers1, numbers2)); // true
            Console.WriteLine(CheckArrayEquality(numbers1, numbers3)); // false

            Console.WriteLine(numbers1[0]);
        }

        static bool CheckArrayEquality(int[] numberArray1, int[] numberArray2)
        {
            for (int i = 0; i < numberArray1.Length; i++) 
                //is there a way not to connect this to a specific array?
            {
                if (numberArray1[i] != numberArray2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
