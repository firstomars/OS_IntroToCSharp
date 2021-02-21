using System;

namespace AIE_46_NewBubbleSortFunction
{
    class Program
    {
        static int swaps = 0;
        static int comparisons = 0;

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

            Console.WriteLine("Sorted");

            //NewBubbleSort(arrayToBeSorted);
            //OptimisedBubbleSort(arrayToBeSorted);
            CocktailShakerSort(arrayToBeSorted);

            PrintArray(arrayToBeSorted);

            Console.WriteLine($"Comparisons no.: {comparisons}");
            Console.WriteLine($"Swaps no.: {swaps}");

        }

        static void NewBubbleSort(int[] array)
        {
            bool sorted = false;

            while(!sorted)
            {
                sorted = true;

                for (int i = 0; i <= array.Length - 2; i++)
                {
                    if (CompareNumbers(array[i], array[i+1]) == true)
                    {
                        swaps += 1;
                        
                        int temp  = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = temp;
                        sorted = false;
                    }
                }
            }
        }

        static bool CompareNumbers(int a, int b)
        {
            comparisons += 1;
            
            if (a > b)
            {
                return true;
            }

            else
            {
                return false;
            }
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

        static void OptimisedBubbleSort(int[] array)
        {
            if (array.Length <= 1) return;

            bool sorted = false;
            int forLoopCounter = 0;

            while (!sorted)
            {
                sorted = true;

                for (int i = 0; i < array.Length - forLoopCounter - 1; i++)
                {
                    if (CompareNumbers(array[i], array[i + 1]) == true)
                    {
                        swaps += 1;

                        int temp = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = temp;
                        sorted = false;
                    }
                }
                forLoopCounter += 1;
            }
        }

        //static void CocktailShakerSort(int[] array)
        //{
        //    if (array.Length <= 1) return;

        //    bool sorted = false;
        //    int forLoopCounterUp = 0;
        //    int forLoopCounterDown = 0;

        //    while(!sorted)
        //    {
        //        for(int i = 0; i < array.Length - 1 - forLoopCounterUp; i++)
        //        {
        //            if (CompareNumbers(array[i], array[i+1]) == true)
        //            {
        //                swaps += 1;

        //                int temp = array[i + 1];
        //                array[i + 1] = array[i];
        //                array[i] = temp;
        //            }
        //        }

        //        for (int j = array.Length - 1 ; j >= 0 + forLoopCounterDown; j--)
        //        {

        //            //if (j - 1 > array.Length - 1 || j + 1 < 0) return;

        //            if (CompareNumbers(array[j], array[j+1]) == false)
        //            {
        //                swaps += 1;

        //                int temp = array[j + 1];
        //                array[j + 1] = array[j];
        //                array[j] = temp;
        //            }
        //        }
        //        forLoopCounterUp += 1;
        //    }
        //}

        static void CocktailShakerSort(int[] array)
        {
            if (array.Length <= 1) return;

            bool sorted = false;

            int end = array.Length - 1;
            int start = 0;

            while (!sorted)
            {
                sorted = true;
                
                for (int i = 0; i < end; i++)
                {
                    if (CompareNumbers(array[i], array[i + 1]) == true)
                    {
                        swaps += 1;

                        int temp = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = temp;
                        sorted = false;
                    }
                }

                end--;

                for (int j = end - 1; j >= start; j--)
                {
                    if (CompareNumbers(array[j], array[j + 1]) == false)
                    {
                        swaps += 1;

                        int temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                        sorted = false;
                    }
                }
                start++;

                // Comparisons = 1825 (1105)
                // Swaps = 1379 (628)
            }
        }
    }
}
