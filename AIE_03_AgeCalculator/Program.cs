using System;

namespace AIE_03_AgeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //uint currentYear = 2021;
            //uint birthYear = 1988;

            //uint age = currentYear - birthYear;

            //Console.WriteLine($"You were born in {birthYear}. It is now {currentYear}, meaning that you are {age} years old.");

            //string output = string.Format("You were born in {0}. It is now {1}, meaning that you are {2} years old", birthYear, currentYear, age);

            //Console.WriteLine(output);


            DateTime currentYear = new DateTime(2021, 1, 1);
            DateTime birthYear = new DateTime(1988, 1, 1);
            var age = currentYear - birthYear;
            var ageInHours = age.TotalHours;

            Console.WriteLine($"You are {ageInHours} hours old.");
        }
    }
}
