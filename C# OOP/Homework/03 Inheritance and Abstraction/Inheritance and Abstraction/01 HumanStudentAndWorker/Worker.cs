using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_HumanStudentAndWorker
{
    class Worker : Human
    {
        private  const int DaysOfWeek = 7;
        private decimal weekSalary;
        private double workHoursPerDay;
        public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay) 
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get {return this.weekSalary;}
            set{this.weekSalary = value;}
        }
        public double WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            set
            {
                if (value < 0 || value > 24)
                {
                    throw new AggregateException("Ivalide hours of work!");
                }
                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            decimal paymentEarnedByHour = this.WeekSalary / ((decimal)this.WorkHoursPerDay * DaysOfWeek);
            return paymentEarnedByHour;

        }

       
    }
}
