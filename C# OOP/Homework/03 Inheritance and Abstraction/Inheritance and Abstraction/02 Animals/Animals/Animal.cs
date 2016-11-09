using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_Animals
{
    public abstract class Animal: ISoundProducible
    {
        private string name;
        private int age;
        private string gender;

        protected Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new AggregateException("InvalidCastException name!");
                }
                this.name = value;
            }
        }
        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid age!");
                }
                this.age = value;
            }
        }

        public virtual string Gender
        {
            get { return this.gender; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new AggregateException("Invalid gender!");
                }
                this.gender = value;
            }
        }

        public abstract void ProduceSound();

    }
    
}