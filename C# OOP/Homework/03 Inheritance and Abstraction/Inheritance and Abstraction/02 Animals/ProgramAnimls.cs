using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Animals
{
    class ProgramAnimls
    {
        static void Main()
        {
            List<Animal> animals = new List<Animal>()
            {
                new Dog("Sharo1", 10,"male"),
                new Dog("Sharo2", 11,"male"),
                new Dog("Sharo3", 7,"male"),
                new Frog("Kvaki1", 1, "female"),
                new Frog("Kvaki2", 2, "female"),
                new Frog("Kvaki3", 3, "female"),
                new Kitten("Pisana1", 4, "female"),
                new Kitten("Pisana2", 9, "female"),
                new Kitten("Pisana3", 4, "female"),
                new Tomcat("Tom1", 7, "male"),  
                new Tomcat("Tom2", 5, "male"),
                new Tomcat("Tom3", 7, "male")
            };
            foreach (var animal in animals)
            {
                Console.Write("{0} said:", animal.Name);
                animal.ProduceSound();
            }

            var dogsAverageAge = animals.Where(x => x is Dog).Average(x => x.Age);
            Console.WriteLine("The average age of all dogs is: {0}", dogsAverageAge);

            var frogsAverageAge = animals.Where(x => x is Frog).Average(x => x.Age);
            Console.WriteLine("The average age of all frogs is: {0}", frogsAverageAge);

            var kittensAverageAge = animals.Where(x => x is Kitten).Average(x => x.Age);
            Console.WriteLine("The average age of all kittens is: {0}", kittensAverageAge);

            var tomcatsAverageAge = animals.Where(x => x is Tomcat).Average(x => x.Age);
            Console.WriteLine("The average age of all tomcats is: {0}", tomcatsAverageAge);
            
        }
    }
}
