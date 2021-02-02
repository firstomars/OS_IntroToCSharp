using System;

namespace AIE_01_HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // started here

            Console.WriteLine("Hello World!");

            string aFriend = "Harry";

            Console.WriteLine("Hey " + aFriend);

            aFriend = "Tom";

            Console.WriteLine("How are you " + aFriend + " ?");

            Console.WriteLine($"Hi again {aFriend}.");

            string firstMate = "Joe";

            string secondMate = "Jamie";

            Console.WriteLine($"What are you up to {firstMate} and {secondMate}?");

            Console.WriteLine($"The name {secondMate} has {secondMate.Length} letters.");

            string greeting = "      Hello World!       ";
            Console.WriteLine($"[{greeting}]");

            string trimmedHello = greeting.TrimStart();
            Console.WriteLine($"[{trimmedHello}]");

            trimmedHello = greeting.TrimEnd();
            Console.WriteLine($"[{trimmedHello}]");

            trimmedHello = greeting.Trim();
            Console.WriteLine($"[{trimmedHello}]");

            string sayHello = "Hello World";
            Console.WriteLine(sayHello);
            sayHello = sayHello.Replace("Hello", "What's up");
            Console.WriteLine(sayHello);

            Console.WriteLine(sayHello.ToUpper());
            Console.WriteLine(sayHello.ToLower());

            string songLyrics = "You say goodbye, and I say hello";
            Console.WriteLine(songLyrics.StartsWith("You"));
            Console.WriteLine(songLyrics.StartsWith("goodbye"));

            Console.WriteLine(songLyrics.EndsWith("hello"));
            Console.WriteLine(songLyrics.EndsWith("goodbye"));

            int a = 5;
            int b = 10;
            int w = 2;
            int g = (a + b) / w;
            int h = (a + b) % w;


            Console.WriteLine(g);
            Console.WriteLine($"quotient: {g}");

            Console.WriteLine(h);
            Console.WriteLine($"remainder: {h}");


            int c = b / a;


            int x = 11;
            int y = 12;
            int z = x * y;

            int p = b - a;
            int q = z + c;

            int d = a + b * x;

            int e = (a + b) * x;

            int f = (a + b) - 6 * c + (12 * 8) / 3 + 12;

            Console.WriteLine(z);

            Console.WriteLine(c);

            Console.WriteLine(p);
            Console.WriteLine(q);

            Console.WriteLine(d);

            Console.WriteLine(e);

            Console.WriteLine(f);


            int max = int.MaxValue;
            int min = int.MinValue;
            Console.WriteLine($"The range of integers is {min} and {max}");

            int what = max + 3;
            Console.WriteLine($"An example of an overflow: {what}");

            double ab = 19;
            double bc = 23;
            double cd = 8;
            double de = (ab + bc) / cd;
            Console.WriteLine(de);

            double maxD = double.MaxValue;
            double minD = double.MinValue;

            Console.WriteLine($"The max value of a double is {maxD} and the min value is {minD}");

            double third = 1.0 / 3.0;
            Console.WriteLine(third);

            decimal minV = decimal.MinValue;
            decimal maxV = decimal.MaxValue;

            Console.WriteLine($"The min value of decimal is {minV} and the max is {maxV}");

            double xy = 1.0;
            double yz = 3.0;
            Console.WriteLine(xy / yz);

            decimal fg = 1.0M;
            decimal gh = 3.0M;
            Console.WriteLine(fg / gh);

            double circleRadius = 2.50;
            double radiusSquared = circleRadius * circleRadius;

            double circleArea = radiusSquared * Math.PI;

            Console.WriteLine($"The area circle with a radius of {circleRadius} is {circleArea}");

        }


    }
}
