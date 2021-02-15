using System;
using System.Collections.Generic;
using System.Text;

namespace AIE_34_Inheritance
{
    class Person
    {
        public string personName = "";

        public Person(string name)
        {
            this.personName = name;
        }

        public void SwitchOff(SpinningWheel spinningWheel)
        {
            Console.WriteLine($"{personName} flicks the off switch of the {spinningWheel.name.ToLower()}.");
            spinningWheel.FanStopsSpinning();
        }
    }
}
