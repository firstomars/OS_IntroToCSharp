using System;

namespace AIE_04_CircleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double circleRadius = 5.30;

            double circleCircumference = circleRadius * 2 * Math.PI;

            Console.WriteLine($"The circle's circumference is {circleCircumference}.");

            //double circleArea = circleRadius * circleRadius * Math.PI;

            double circleArea = Math.Pow(circleRadius, 2) * Math.PI;

            Console.WriteLine($"The circle's area is {circleArea}.");
        }
    }
}
