using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_HumanStudentAndWorker
{
    class Student : Human
    {
        private string facultyNumber;
        private const int minFacultyNumberDigits = 5;
        private const int maxFacultyNumberDigits = 10;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return this.facultyNumber; }
            set
            {
                if (value.Length < minFacultyNumberDigits || value.Length > maxFacultyNumberDigits)
                {
                    throw new AggregateException("Faculty number must be more than 4 and less than 10 digits/letters!");
                }
                this.facultyNumber = value;
            }
        }
    }
}
