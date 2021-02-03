using System;

namespace AIE_19_FunctionCube
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the length of the cube side:");

            string numA = Console.ReadLine();
            int a = int.Parse(numA);

            int cube = CalculateCubeArea(a);

            //how do i take the above result and just add the result to console, as oppsed to adding the function in?

            Console.WriteLine($"The cube area is {cube}");
        }

        static int CalculateCubeArea(int a)
        {
            int cubeArea = a * a * a;
            return cubeArea;
        }
    }
}
