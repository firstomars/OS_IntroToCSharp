using System;

namespace AIE_34_Inheritance
{
    
    class Program
    {
        static void Main(string[] args)
        {
            SpinningWheel ceilingFan = new CeilingFan();
            //ceilingFan.Spin();

            //SpinningWheel hamsterWheel = new HamsterWheel();
            //hamsterWheel.Spin();

            //FloorFan floorFan = new FloorFan();
            //floorFan.Spin();
            //floorFan.HighSpeed();

            Person hernandez = new Person("Hernandez");
            hernandez.SwitchOff(ceilingFan);
        }
    }


}
