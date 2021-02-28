using System;
using System.Collections.Generic;

namespace AIE_50_ReversePolishCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            string[] inputs;
            List<float> numbers = new List<float>();
            List<string> operations = new List<string>();
            float total = 0;

            //Read console input and store in array
            input = Console.ReadLine();
            inputs = StoreInputsInArray(input);

            //Sort numbers and operations into their own lists
            SortNumbersAndOperations(numbers, operations, inputs);

            //Print numbers and operations back to screen to confirm
            Console.WriteLine(" ");
            ConfirmNumbersAndOperations(numbers, operations);

            //Apply operations to numbers and save in total variable
            total = ApplyOperations(numbers, operations);

            //Write total to screen
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(total);
        }

        private static void ConfirmNumbersAndOperations(List<float> numbers, List<string> operations)
        {
            foreach (float i in numbers)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine(" ");

            foreach (string i in operations)
            {
                Console.WriteLine(i + " ");
            }
        }

        private static float ApplyOperations(List<float> numbers, List<string> operations)
        {
            float total;
            if (operations[0] == "+")
            {
                total = numbers[0] + numbers[1];
            }

            else if (operations[0] == "-")
            {
                total = numbers[0] + numbers[1];
            }

            else if (operations[0] == "/")
            {
                total = numbers[0] / numbers[1];
            }

            else
            {
                total = numbers[0] * numbers[1];
            }

            for (int i = 2; i < numbers.Count; i++)
            {
                if (operations[i-1] == "+")
                {
                    total += numbers[i];
                }

                else if (operations[i - 1] == "-")
                {
                    total -= numbers[i];
                }

                else if (operations[i - 1] == "/")
                {
                    total /= numbers[i];
                }

                else
                {
                    total *= numbers[i];
                }
            }
            return total;
        }

        private static void SortNumbersAndOperations(List<float> numbers, List<string> operations, string[] inputs)
        {
            // run through array, test if it's 1. an operation * + - /; 2. test if it's a number
            for (int i = 0; i < inputs.Length; i++)
            {
                // tryparse ints. store into new int[]
                int tmp;

                //bool isNumeric = int.TryParse("123", out n);
                if (int.TryParse(inputs[i], out tmp))
                {
                    numbers.Add(tmp);
                }

                else
                {
                    operations.Add(inputs[i]);
                }
            }
        }

        private static string[] StoreInputsInArray(string input)
        {
            //create array, and split by " " into array.
            string[] inputs = input.Split(" ");

            for (int i = 0; i < inputs.Length; i++)
            {
                Console.WriteLine(inputs[i]);
            }
            return inputs;
        }
    }
}

//for (int i = 0; i < numbers.Count; i++)
//{
//    var nextNum = i + 1;

//    if (nextNum < numbers.Count)
//    {
//        int tmp = 0;
//        tmp = numbers[i] + numbers[i + 1];
//        total += tmp;
//        numbers[i + 1] = tmp;
//    }

//    else
//    {
//        break;
//    }
//}

//for (int i = 2; i < numbers.Count; i++)
//{
//    for (int j = 1; j < operations.Count; j++)
//    {
//        if (operations[j] == "+")
//        {
//            total += numbers[i];
//        }

//        else if (operations[j] == "-")
//        {
//            total -= numbers[i];
//        }

//        else if (operations[j] == "/")
//        {
//            total /= numbers[i];
//        }

//        else //if (operations[j] == "*")
//        {
//            total *= numbers[i];
//        }
//    }
//}