using System;
using System.Collections.Generic;
using System.Text;

namespace AIE_34_Inheritance
{
    class FloorFan : SpinningWheel
    {
        public FloorFan() : base("Floor Fan")
        {

        }

        public void HighSpeed()
        {
            Console.WriteLine(name + " spins faster.");
        }

    }
}
