using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using TestCapitalism.Exeptions;
using TestCapitalism.Interfaces;
using TestCapitalism.Models.Eployes;
using TestCapitalism.UI;

namespace TestCapitalism.Engine
{
    public class CpitalismEngine : ICapitalismEngine
    {
        private bool PrgramRunning = true;
        private IRead reader;
        private IRender render;
        private Company company;
        private Ceo ceo;
        private Department department;
        private Manager manager;
        private Salesmen salesman;
        private Accountant accountant;
        private ChiefTelephoneOfficers chiefTelephoneOfficers;
        private CleaningLady cleaningLady;
        private Regular regular;

        private IList<Employes> companyEmployeses;  
        private Dictionary<string, decimal> companiesInfo;
        private List<string> deparments;
        private Dictionary<string, decimal> paidSalariesCount;
       
        public CpitalismEngine()
        {
            reader = new Reader();
            render = new Renderer();
            companyEmployeses = new List<Employes>();
            companiesInfo = new Dictionary<string, decimal>();
            deparments = new List<string>();
            paidSalariesCount = new Dictionary<string, decimal>();
           
        }

        public void Run()
        {

            while (PrgramRunning)
            {
                var input = reader.Reade();
                ExecuteCommand(input);
            }

        }

        public virtual void ExecuteCommand(string input)
        {
            var tempArray = input.Split().ToArray();
            tempArray[0] = tempArray[0].Replace("-", " ");
            string tempString = string.Join(" ", tempArray);
            var comandInfo = tempString.Split().ToArray();

            Execute(comandInfo);
            
        }

        public virtual void Execute(string[] input)
        {
            if (input[0].ToLower() == "create")
            {
                switch (input[1].ToLower())
                {
                    case "company":
                       company = new Company(input[2]);
                       ceo = new Ceo(input[2], input[3], input[4], decimal.Parse(input[5]));
                        companiesInfo.Add(input[2], decimal.Parse(input[5]));
                        paidSalariesCount.Add(input[2], 0);
                        companyEmployeses.Add(ceo);
                        break;
                    case "department":
                        if (companiesInfo.ContainsKey(input[2]))
                        {
                            if (deparments.Contains(input[3]))
                            {
                                break;
                            }
                            else if (input.Length == 4)
                            {
                                department = new Department(input[2], input[3]);
                                deparments.Add(input[3]);
                                break;
                            }

                            department = new Department(input[2], input[4], input[3]);
                            deparments.Add(input[3]);
                           break;

                        }
                        break;
                    case "employee":
                        if (companiesInfo.ContainsKey(input[5]))
                        {
                            switch (input[4].ToLower())
                            {
                                case "manager":
                                    manager = new Manager(input[5], input[2], input[3],companiesInfo[input[5]],input[6],input[4]);
                                    companyEmployeses.Add(manager);
                                    break;
                                case "salesman":
                                    salesman = new Salesmen(input[5], input[2], input[3], companiesInfo[input[5]],input[6], input[4]);
                                    companyEmployeses.Add(salesman);
                                    break;
                                case "accountant":
                                    accountant = new Accountant(input[5], input[2], input[3], companiesInfo[input[5]], input[6], input[4]);
                                    companyEmployeses.Add(accountant);
                                    break;
                                case "chieftelephoneofficer":
                                    chiefTelephoneOfficers = new ChiefTelephoneOfficers(input[5], input[2], input[3], companiesInfo[input[5]], input[6], input[4]);
                                    companyEmployeses.Add(chiefTelephoneOfficers);
                                    break;
                                case "cleaninglady":
                                    cleaningLady = new CleaningLady(input[5], input[2], input[3], companiesInfo[input[5]], input[6], input[4]);
                                    companyEmployeses.Add(cleaningLady);
                                    break;
                                case "regular":
                                    regular = new Regular(input[5], input[2], input[3], companiesInfo[input[5]], input[6], input[4]);
                                    companyEmployeses.Add(regular);
                                    break;
                            }
                        }
                        
                        break;

                }
            }
            else if (input[0].ToLower() == "pay")
            {
                if (companiesInfo.ContainsKey(input[2]))
                {
                    paidSalariesCount[input[2]] += 1;
                }
            }
            else if (input[0].ToLower() == "show")
            {
                if (companiesInfo.ContainsKey(input[2]))
                {
                    foreach (var employee in companyEmployeses)
                    {
                        if (employee.CompanyName == input[2])
                        {
                            int count = 0;
                            
                            StringBuilder sb = new StringBuilder();
                            if (DepartmentStructure(employee.DepartmentName) > 0)
                            {
                               sb.Append(' ', 4 * DepartmentStructure(employee.DepartmentName));
                                count = DepartmentStructure(employee.DepartmentName);
                            }

                            decimal salarySubDepartmentsReduction = companiesInfo[employee.CompanyName] * 0.01m * count;
                            sb.Append(employee);
                            sb.AppendFormat("({0:F2})", (employee.Salary - salarySubDepartmentsReduction) * paidSalariesCount[input[2]]);
                            render.Render(sb.ToString());
                        }
                    }
                }
            }
            else if (input[0].ToLower() == "end")
            {
                this.PrgramRunning = false;
            }
            else
            {
                render.Render("Unknown command!");
            }
          
        }

        public virtual int DepartmentStructure(string employeeDepartment)
        {
            if (string.IsNullOrEmpty(employeeDepartment))
            {
                 return 0;
            }
            var departmentChild = employeeDepartment.Replace("-", " ").Split().ToArray();
            if (departmentChild.Length > 1)
            {
                return departmentChild.Length - 1;
            }
            return 0;
            
        }
    }
}
