using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age, string gender) 
            : base(name, age, gender)
        {
        }

        public override string Gender
        {
            get { return base.Gender; }
            set
            {
                if (value != "male")
                {
                    throw new AggregateException("Increct tomcat gender!");
                }
                base.Gender = value;
            }
        }
    }
}