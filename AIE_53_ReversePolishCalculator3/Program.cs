using System;

namespace AIE_53_ReversePolishCalculator3
{
    class Program
    {
        public static void Main(string[] args)
        {
            float check1 = RPN.Calculate("10 20 +");     // should be 30
            float check2 = RPN.Calculate("10 20 5 * +"); // should be 110
            float check3 = RPN.Calculate("10 20 * 5 +"); // should be 205
            float check4 = RPN.Calculate("10 20 * 5 + 5 -"); // should be 200
            float check5 = RPN.Calculate("10 20 5 5 * + -"); // should be -35
            Console.WriteLine(check1 == 30 ? "Check1: Passed" : $"Check1: Failed (expected: 30 received: {check1})");
            Console.WriteLine(check2 == 110 ? "Check2: Passed" : $"Check2: Failed (expected: 110 received: {check2})");
            Console.WriteLine(check3 == 205 ? "Check3: Passed" : $"Check3: Failed (expected: 205 received: {check3})");
            Console.WriteLine(check4 == 200 ? "Check4: Passed" : $"Check4: Failed (expected: 200 received: {check4})");
            Console.WriteLine(check5 == -35 ? "Check5: Passed" : $"Check5: Failed (expected: -35 received: {check5})");
        }
    }
}
