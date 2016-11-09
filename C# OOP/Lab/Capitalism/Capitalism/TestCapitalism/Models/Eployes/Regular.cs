using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCapitalism.Models.Eployes
{
    public class Regular : RegularEmployees
    {
        
        public Regular(string companyName, string firstName, string lastName, decimal salary,
            string departmentName, string position) 
            : base(companyName, firstName, lastName, salary, departmentName, position)
        {
        }
    }
}
