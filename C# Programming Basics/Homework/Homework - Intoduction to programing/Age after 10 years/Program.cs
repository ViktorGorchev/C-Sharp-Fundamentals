using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Age_after_10_years
{
    class Program
    {
        static void Main()
        {
            string inputDate = Console.ReadLine();
            DateTime date = DateTime.Parse(inputDate);
            int age = new DateTime(DateTime.Now.Subtract(date).Ticks).Year - 1;
            int ageAfterTenYears = age + 10;
                 
            Console.WriteLine("Now: " + age);
            Console.WriteLine("After 10 years: " + ageAfterTenYears);

        }
    }
}
