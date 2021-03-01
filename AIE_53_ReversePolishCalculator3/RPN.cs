using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AIE_53_ReversePolishCalculator3
{
    class RPN
    {
        public static float Calculate(string input)
        {
            string[] inputs;
            List<string> list;
            List<float> numbersList = new List<float>();
            float total = 0;

            inputs = StoreInputsInArray(input);

            list = inputs.OfType<string>().ToList();

            return total = RunThroughListAndCalculate(list, numbersList);
        }

        private static string[] StoreInputsInArray(string input)
        {
            string[] inputs = input.Split(" ");
            return inputs;
        }

        private static float RunThroughListAndCalculate(List<string> list, List<float> numbersList)
        {
            // if list is empty


            foreach (string item in list)
            {
                if (float.TryParse(item, out float tmp))
                {
                    numbersList.Add(tmp);
                }

                else if (item == "+")
                {
                    GetParams(numbersList, out float lastNum, out float secondLastNum);
                    numbersList.Add(secondLastNum + lastNum);
                }

                else if (item == "-")
                {
                    GetParams(numbersList, out float lastNum, out float secondLastNum);

                    float newNum = secondLastNum - lastNum;
                    numbersList.Add(newNum);
                }

                else if (item == "*")
                {
                    GetParams(numbersList, out float lastNum, out float secondLastNum);

                    float newNum = secondLastNum * lastNum;
                    numbersList.Add(newNum);
                }

                else if (item == "/")
                {

                    GetParams(numbersList, out float lastNum, out float secondLastNum);

                    float newNum = secondLastNum / lastNum;
                    numbersList.Add(newNum);
                }
            }


            float total = numbersList.FirstOrDefault<float>();

            return total;
        }




        static void GetParams(List<float> numbersList, out float a, out float b)
        {
            b = numbersList[numbersList.Count - 1];
            a = numbersList[numbersList.Count - 2];

            numbersList.RemoveAt(numbersList.Count - 1);
            numbersList.RemoveAt(numbersList.Count - 1);
        }

    }
}
