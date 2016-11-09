using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Company_Hierarchy.Interfaces
{
    interface IProjects
    {
        string Name { get; set; }
        DateTime StartDate { get; set; }
        void CloseProject();
    }
}
