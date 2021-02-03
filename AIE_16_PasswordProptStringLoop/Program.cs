using System;

namespace AIE_16_PasswordProptStringLoop
{
    class Program
    {
        static void Main(string[] args)
        {

            //string pw;
            //string pw2;


            //while (pw != pw2)
            //{
            //    Console.WriteLine("Enter password.");
            //    pw = Console.ReadLine();

            //    Console.WriteLine("Enter password again for confirmation.");
            //    pw2 = Console.ReadLine();

            //    if (pw == pw2)
            //    {
            //        Console.WriteLine("Password confirmed.");
            //    }

            //    else
            //    {
            //        Console.WriteLine("Passwords do not match.");
            //    }
            //}


            string pw1;
            string pw2;

            do
            {
                Console.WriteLine("Enter password.");
                pw1 = Console.ReadLine();

                Console.WriteLine("Enter password again for confirm.");
                pw2 = Console.ReadLine();

                if (pw1 == pw2)
                {
                    Console.WriteLine("Password confirmed.");
                    break;
                }

                else if (pw1 != pw2)
                {
                    Console.WriteLine("Passwords do not match.");
                }

            } while (pw1 != pw2);
        }
    }
}
