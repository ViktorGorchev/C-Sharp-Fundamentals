using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03_Company_Hierarchy.Interfaces;

namespace _03_Company_Hierarchy.Persone
{
    public abstract class Person : IPerson
    {
        private string id;
        private string firstName;
        private string lastName;

        protected Person(string id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string Id
        {
            get { return this.id; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new AggregateException("Ivalid ID!");
                }
                this.id = value;
            } 
            
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new AggregateException("Invalid first name!");
                }
                this.firstName = value;
            } 
            
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new AggregateException("Invalid last name!");
                }
                this.lastName = value;
            }
        }

        public override string ToString()
        {
            return string.Format("ID: {0}, Name: {1} {2},", this.Id, this.FirstName, this.LastName);
        }
    }
}
