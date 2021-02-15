using System;
using System.Collections.Generic;
using System.Text;

namespace AIE_35_InheritanceTwo
{
    class Animal
    {
        public string name = "";

        //Constructor

        public Animal(string name)
        {
            this.name = name;
        }

        // Method is virtual - it can be overriden in derived classes
        public virtual void MakeNoise()
        {
            Console.WriteLine(name + " makes some noise.");
        }

        public virtual void EatFood()
        {
            Console.WriteLine(name + " eats food");
            MakeNoise();
        }

    }
}
