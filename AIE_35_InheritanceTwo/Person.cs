using System;
using System.Collections.Generic;
using System.Text;

namespace AIE_35_InheritanceTwo
{
    class Person
    {
        public string personName = "";

        public Person(string personName)
        {
            this.personName = personName;
        }

        public void FeedAnimal(Animal animal)
        {
            Console.WriteLine(personName + " feeds " + animal.name);
            animal.EatFood();
        }
    }
}
