using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_Animals
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age, string gender) 
            : base(name, age, gender)
        {
        }

        public override string Gender
        {
            get { return base.Gender; }
            set
            {
                if (value!= "female")
                {
                    throw new AggregateException("Ivalid kitten gender!");
                }
                base.Gender = value;
            }

        }
    }
}