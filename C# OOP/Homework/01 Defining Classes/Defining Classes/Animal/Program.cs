﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal
{
    class Program
    {
        static void Main()
        {
            Dog unnamed = new Dog();
            Dog sharo = new Dog("Sharo", "Melez");
            unnamed.Breed = "German Shepard";
            unnamed.Bark();
            sharo.Bark();

            Dog[] allDogs = new Dog[2];
            allDogs[0] = unnamed;
            allDogs[1] = sharo;
            foreach (var dog in allDogs)
            {
                dog.Bark();
            }

        }
    }
}
