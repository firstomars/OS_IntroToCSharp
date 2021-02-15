using System;

namespace AIE_35_InheritanceTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal dog = new Dog();
            //dog.MakeNoise();

            Person ruperta = new Person("Ruperta");
            ruperta.FeedAnimal(dog);
        }
    }
}
