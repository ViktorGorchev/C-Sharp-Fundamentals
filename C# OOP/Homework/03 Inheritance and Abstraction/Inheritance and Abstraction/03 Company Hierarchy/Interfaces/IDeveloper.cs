using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03_Company_Hierarchy.Persone.Employee;

namespace _03_Company_Hierarchy.Interfaces
{
    interface IDeveloper
    {
        List<Projects> Projects { get; set; }
    }
}
