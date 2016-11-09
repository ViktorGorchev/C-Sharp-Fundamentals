using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03_Company_Hierarchy.Interfaces;

namespace _03_Company_Hierarchy.Persone.Employee
{
    public class Developer : RegularEmployee, IDeveloper
    {
        List<Projects> projects = new List<Projects>();
        
        public Developer(string id, string firstName, string lastName, decimal salary, string department, List<Projects> projects) 
            : base(id, firstName, lastName, salary, department)
        {
            this.Projects = projects;
        }

        public List<Projects> Projects
        {
            get { return this.projects; }
            set { this.projects = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.ToString() + "Projects count: " + projects.Count + Environment.NewLine);
            sb = sb.Replace("Manager --> ", "Developer --> ");
            foreach (var project in this.Projects)
            {
                sb.Append(project);
            }
            return sb.ToString();
        }
    }
}
