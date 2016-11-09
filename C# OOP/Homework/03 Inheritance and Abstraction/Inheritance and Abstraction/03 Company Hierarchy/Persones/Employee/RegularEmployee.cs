using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Company_Hierarchy.Persone.Employee
{
    public abstract class RegularEmployee : Manager
    {
        public RegularEmployee(string id, string firstName, string lastName, decimal salary, string department) 
            : base(id, firstName, lastName, salary, department)
        {
        }
    }
}
