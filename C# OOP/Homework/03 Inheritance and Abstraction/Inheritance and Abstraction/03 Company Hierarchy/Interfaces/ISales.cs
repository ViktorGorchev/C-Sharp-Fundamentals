using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace _03_Company_Hierarchy.Interfaces
{
    interface ISales
    {
        string ProductName { get; set; }
        DateTime Date { get; set; }
        decimal Price { get; set; }
    }
}
