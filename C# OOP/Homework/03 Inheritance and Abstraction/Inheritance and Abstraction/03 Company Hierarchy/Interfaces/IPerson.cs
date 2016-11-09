using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Company_Hierarchy.Interfaces
{
    interface IPerson
    {
        string Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
