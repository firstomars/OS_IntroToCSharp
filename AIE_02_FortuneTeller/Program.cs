using System;

namespace AIE_02_FortuneTeller
{
    class Program
    {

        


        static void Main(string[] args)
        {
            uint numberOfChildren = 5; //unsigned int - cannot be negative
            string partnersName = "Halima";
            string geoLocation = "Petaling Jaya, Malaysia";
            string jobTitle = "Homemaker";

            //Console.WriteLine($"You will be a {jobTitle} in {geoLocation}, married to {partnersName} with {numberOfChildren} kids.");


            /*
            Console.WriteLine("You will be a");
            Console.WriteLine("You will be a");
            Console.WriteLine("You will be a");
            Console.WriteLine("You will be a");
            Console.WriteLine("You will be a");
            */

            string output = string.Format("You will be a {0} in {1}, married to {2} with {3} kids.", jobTitle, geoLocation, partnersName, numberOfChildren);

            Console.WriteLine(output);
        }
    }
}
