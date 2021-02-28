using System;
using System.Collections.Generic;
using System.Linq;

namespace AIE_52_ReversePolishCalculator2
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawString;
            List<string> list;
            List<float> numbersList = new List<float>();

            //Add console input to rawList
            rawString = Console.ReadLine();

            //Split string and add items to list
            list = rawString.Split(' ').ToList();

            RunThroughListAndCalculate(list, numbersList);

            foreach (float number in numbersList)
            {
                Console.WriteLine($"The last number in the stack is {number}.");
            }
        }

        private static void RunThroughListAndCalculate(List<string> list, List<float> numbersList)
        {
            foreach (string item in list)
            {
                if (float.TryParse(item, out float tmp))
                {
                    numbersList.Add(tmp);
                }

                else if (item == "+")
                {
                    float lastNum = numbersList[numbersList.Count - 1];
                    float secondLastNum = numbersList[numbersList.Count - 2];

                    numbersList.RemoveAt(numbersList.Count - 2);
                    numbersList.RemoveAt(numbersList.Count - 1);

                    float newNum = secondLastNum + lastNum;
                    numbersList.Add(newNum);
                }

                else if (item == "-")
                {
                    float lastNum = numbersList[numbersList.Count - 1];
                    float secondLastNum = numbersList[numbersList.Count - 2];

                    numbersList.RemoveAt(numbersList.Count - 2);
                    numbersList.RemoveAt(numbersList.Count - 1);

                    float newNum = secondLastNum - lastNum;
                    numbersList.Add(newNum);
                }

                else if (item == "*")
                {
                    float lastNum = numbersList[numbersList.Count - 1];
                    float secondLastNum = numbersList[numbersList.Count - 2];

                    numbersList.RemoveAt(numbersList.Count - 2);
                    numbersList.RemoveAt(numbersList.Count - 1);

                    float newNum = secondLastNum * lastNum;
                    numbersList.Add(newNum);
                }

                else if (item == "/")
                {
                    float lastNum = numbersList[numbersList.Count - 1];
                    float secondLastNum = numbersList[numbersList.Count - 2];

                    numbersList.RemoveAt(numbersList.Count - 2);
                    numbersList.RemoveAt(numbersList.Count - 1);

                    float newNum = secondLastNum / lastNum;
                    numbersList.Add(newNum);
                }
            }
        }
    }
}

//foreach (int number in numbersList)
//{
//    Console.Write(number + " ");
//}
