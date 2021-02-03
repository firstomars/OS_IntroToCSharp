using System;

namespace AIE_22_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the first number: ");
            string sNum1 = Console.ReadLine();
            int num1 = int.Parse(sNum1);

            Console.Write("Enter the second number: ");
            string sNum2 = Console.ReadLine();
            int num2 = int.Parse(sNum2);

            Console.WriteLine("What do you want to do with these two numbers?");
            Console.WriteLine("Multiply? Divide? Subtract? Add?");
            string operation = Console.ReadLine();

            Console.WriteLine(Calculate(num1, num2, operation));

            // Parameters:
            //Functions have a parameter list, in the example above SumTwoNumbers, 
            //the parameter list is (int a, int b) these are the parameters that define the functions inputs.
            //Arguments:
            //Arguments refer to the values passed into the function.In the examples above, 
            //we called the function twice: SumTwoNumbers(5, 10) 5 and 10 are the arguments..They are the values used.
        }

        static int Calculate(int num1, int num2, string operation)
        {
            int result = 0;

            if (operation == "Add")
            {
                return result = num1 + num2;
            }

            if (operation == "Subtract")
            {
                return result = num1 - num2;
            }

            if (operation == "Divide")
            {
                return result = num1 / num2;
            }

            if (operation == "Multiply")
            {
                return result = num1 * num2;
            }

            throw new Exception($"The operation {operation} is not supported.");

            //while (operation != "Add" || operation != "Subtract" || operation != "Divide" || operation != "Multiply")
            // {
            //do (string operation)
            //{
            //    if (operation == "Add")
            //    {
            //        return result = num1 + num2;
            //    }

            //    if (operation == "Subtract")
            //    {
            //        return result = num1 - num2;
            //    }

            //    if (operation == "Divide")
            //    {
            //        return result = num1 / num2;
            //    }

            //    if (operation == "Multiply")
            //    {
            //        return result = num1 * num2;
            //    }
            //} while (operation != "Add" || operation != "Subtract" || operation != "Divide" || operation != "Multiply")

            //throw new Exception($"The operation {operation} is not supported.");
        }
    }
}
