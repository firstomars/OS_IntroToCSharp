using System;
using System.Collections.Generic;
using System.Text;

namespace AIE_34_Inheritance
{
    class HamsterWheel : SpinningWheel
    {
        public HamsterWheel() : base("Hamster Wheel")
        {

        }

        public override void Spin()
        {
            Console.WriteLine($"Hamster jumped on the {name.ToLower()}. Wheel is now spinning");
        }
    }

}
