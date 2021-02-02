using System;

namespace AIE_05_TempConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            float celcius = 24;

            float celsiusToFahrenheit = ((celcius / 5) * 9) + 32;

            Console.WriteLine($"{celcius} celcius is {celsiusToFahrenheit} fahrenheit");

            float fahrenheightToCelsius = ((celsiusToFahrenheit - 32) * 5) / 9;

            Console.WriteLine($"{celsiusToFahrenheit} is Fahrenheight is {fahrenheightToCelsius} celcius");
        }
    }
}
