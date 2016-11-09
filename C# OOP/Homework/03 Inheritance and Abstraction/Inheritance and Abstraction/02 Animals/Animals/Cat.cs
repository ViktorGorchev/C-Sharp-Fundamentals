﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_Animals
{
    public abstract class Cat : Animal
    {
        protected Cat(string name, int age, string gender) 
            : base(name, age, gender)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Miauu");
        }
    }
}