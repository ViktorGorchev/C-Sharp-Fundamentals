using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCapitalism
{
    public class Department: ICompany,IManager
    {
        private string companyName;
        private string mainDepartmentName;
        private string departmentName;


        public Department(string companyName, string departmentName)
        {
            this.CompanyName = companyName;
            this.DepartmentName = departmentName;
        }

        public Department(string companyName, string mainDepartmentName, string departmentName)
        {
            this.CompanyName = companyName;
            this.MainDepartmentName = mainDepartmentName;
            this.DepartmentName = departmentName;
        }

        public string CompanyName
        {
            get { return this.companyName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new AggregateException("Invalid CompanyName!");
                }
                this.companyName = value;
            }
        }

        public string MainDepartmentName
        {
            get { return this.mainDepartmentName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new AggregateException("Ivalid  MainDepartmentName!");
                }
                this.mainDepartmentName = value;
            }
        }

        public string DepartmentName
        {
            get { return this.departmentName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Ivalid DepartmentName!");
                }
                this.departmentName = value;
            }
        }
    }
}