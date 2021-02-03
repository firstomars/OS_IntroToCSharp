using System;

namespace AIE_20_FunctionVowel
{
    class Program
    {
        static void Main(string[] args)
        {
            bool didEnterVowel = false;

            do
            {
                Console.WriteLine("Enter a letter and we'll tell you whether it is a vowel or a consonant.");
                string sLetter = Console.ReadLine();
                char letter = char.Parse(sLetter);
                

                didEnterVowel = IsVowel(letter);

            } while (didEnterVowel == false);

            Console.WriteLine("Thanks for entering a vowel");




        }

        static bool IsVowel(char letter)
        {
            letter = char.ToLower(letter); // convert character to lower case
            bool foo = (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u');
            return foo;
        }

        static void IdentifyVowelOrConsonant(string letter, bool isLetterVowel)
        {
            if (letter == "a" || letter == "e" || letter == "i" || letter == "o" || letter == "u")
            {
                Console.WriteLine("The letter is a vowel.");
                isLetterVowel = true;
            }

            else
            {
                Console.WriteLine("The letter is a consonant.");
                isLetterVowel = false;
            }
        }
    }
}
