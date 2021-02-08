using System;

namespace AIE_24_Arrays
{
    class Program
    {
        // why aren't these variables recognised by Main()?
        //int[] someNumberArr1 = new int[3] { 5, 10, 6 };
        //int[] someNumberArr2 = new int[] { 2, 6, 90, 12, 45, 68 };

        static void PrintArrayValues(int[] arr) // is this creating a new variable?
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        static int[] CreateRandomArray(int size)
        {
            Random rand = new Random();

            int[] arrARRR = new int[size];

            for(int i=0; i<size; i++)
            {
                arrARRR[i] = rand.Next();
            }
            
            return arrARRR;
        }

        static void Main(string[] args)
        {
            //int[] myInts = new int[4] { 3, -5, 8, 9 };

            ////for (int i = 0; i <= myInts.Length; i++) Why does <= not work?

            //for (int i = 0; i < myInts.Length; i++)
            //{
            //    Console.WriteLine(myInts[i]);
            //}

            int[] someNumberArr1 = new int[3] { 5, 10, 6 };
            int[] someNumberArr2 = new int[] { 2, 6, 90, 12, 45, 68 };

            PrintArrayValues(someNumberArr1);
            PrintArrayValues(someNumberArr2);

            Console.WriteLine(" ");

            CreateRandomArray(4); //not working?

        }





        
    }
}
