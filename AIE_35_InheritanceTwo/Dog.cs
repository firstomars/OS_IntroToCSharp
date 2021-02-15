using System;
using System.Collections.Generic;
using System.Text;

namespace AIE_35_InheritanceTwo
{
    class Dog : Animal
    {
        public Dog() : base("dog")
        {

        }

        public override void MakeNoise()
        {
            Console.WriteLine("WOOF WOOF");
        }
    }
}
