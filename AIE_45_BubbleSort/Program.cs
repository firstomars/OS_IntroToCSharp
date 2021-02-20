using System;

namespace AIE_45_BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayToBeSorted = new int[] {
                 14,65,63,1,54,
                 89,84,9,98,57,
                 71,18,21,84,69,
                 28,11,83,13,42,
                 64,58,78,82,13,
                 9,96,14,39,89,
                 40,32,51,85,48,
                 40,23,15,94,93,
                 35,81,1,9,43,
                 39,15,17,97,52 };

            Console.WriteLine("Unsorted");

            PrintArray(arrayToBeSorted);

            BubbleSort(arrayToBeSorted);

            Console.WriteLine(" ");

            Console.WriteLine("Sorted Array");

            PrintArray(arrayToBeSorted);

        }

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0},\t", array[i]);
                if (i % 10 == 9)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void BubbleSort(int[] array)
        {
            if (array.Length <= 1) return;

            int n = array.Length;

            bool sorted = false;

            while(!sorted)
            {

                sorted = true;
                
                for (int i = 0; i <= n - 2; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = temp;
                        sorted = false;
                    }
                }
            }
        }

    }
}


