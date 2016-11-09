using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Persones
{
    class Persone
    {
        private string name;
        private int age;
        private string email;

        public Persone()
        {

        }

        public Persone(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }

        public Persone(string name, int age)
        {
            this.Name = name;
            this.Age = age;            
        }

        public string Name 
        {
            get
            {
                return this.name;
            }   
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new AggregateException("Not a valid name!");
                }
                this.name = value;
            }
        }
        public int Age 
        { 
            get
            {
                return this.age;
            }
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new AggregateException("Not a valid age!");
                }
                this.age = value;
            }
        }
        public string Email 
        {
            get 
            {
                return this.email;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && !value.Contains('@'))
                {
                    throw new ArgumentException("Not a valid e-mail!");
                }
                this.email = value;
            }
        }
        public override string ToString()
        {
            return string.Format("Name: {0}, Age: {1}, E-mail: {2}", this.Name, this.Age, this.Email);
        }

    }
}
