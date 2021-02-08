using System;

namespace AIE_26_ArraysNeedleHaystack
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] hayStack = new string[] { "hay", "junk", "hay", "hay", "moreJunk", "needle", "randomJunk" };

            var needleLocation = FindNeedle(hayStack);

            Console.WriteLine($"Needle is located at {needleLocation}.");
        }

        //static int FindNeedleIndex(string[] hay)
        //{

        //    var stringToFind = "needle";

        //    int keyIndex = Array.FindIndex(hay, element => element == stringToFind);

        //    return keyIndex;

        //}

        static int FindNeedle(string[] haySTAX)
        {
            for (int i = 0; i < haySTAX.Length; i++)
            {
                if (haySTAX[i] == "needle")
                {
                    return i;
                }
            }
            return -1;
        }


    }
}
