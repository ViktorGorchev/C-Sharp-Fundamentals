using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03_Company_Hierarchy.Interfaces;

namespace _03_Company_Hierarchy.Persone.Employee
{
    public class Projects: IProjects
    {
        private string name;
        private DateTime startDate;
        private string projectState = "open";

        public Projects(string name, DateTime startDate)
        {
            this.Name = name;
            this.StartDate = startDate;

        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new AggregateException("Ivalid project name!");
                }
                this.name = value;
            }
        }

        public DateTime StartDate { get; set; }

        public void CloseProject()
        {
            this.projectState = "closed";
        }

        public override string ToString()
        {
            return string.Format("Project name: {0}, start date: {1}, project state: {2}", this.Name, this.StartDate, this.projectState + Environment.NewLine);
        }
    }
}
