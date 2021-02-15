using System;
using System.Collections.Generic;
using System.Text;

namespace AIE_34_Inheritance
{
    class SpinningWheel
    {
        public string name = "";

        public SpinningWheel(String name)
        {
            this.name = name;
        }

        public virtual void Spin()
        {
            Console.WriteLine(name + " spinning now");
        }

        public virtual void FanStopsSpinning()
        {
            Console.WriteLine($"The {name.ToLower()} slowly comes to a stop.");
        }

    }
}
