using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03_Company_Hierarchy.Persone;
using _03_Company_Hierarchy.Persone.Customer;
using _03_Company_Hierarchy.Persone.Employee;

namespace _03_Company_Hierarchy
{
    public class TestHierarchy
    {
        static void Main()
        {
          List<Sales> peshoSales = new List<Sales>()
            {
                new Sales("Xbox game1", DateTime.Today, 23000),
                new Sales("Xbox game2", DateTime.Today, 23000),
                new Sales("Xbox game3", DateTime.Today, 23000)
            };
            List<Sales> draganSales = new List<Sales>()
            {
                new Sales("PS1", DateTime.Today, 30000),
                new Sales("Xbox game", DateTime.Today, 23000),
                
            };
            List<Sales> ivoSales = new List<Sales>()
            {
                new Sales("Xbox game", DateTime.Today, 23000),
            };
            
            IList<Projects> asenProjectses = new List<Projects>()
            {
                new Projects("PS1", DateTime.Today),
                new Projects("PS2", DateTime.Today),
                new Projects("PS3", DateTime.Today)
            };
            asenProjectses[1].CloseProject();
            IList<Projects> ignatProjectses = new List<Projects>()
            {
                new Projects("Xbox game1", DateTime.Today),
                new Projects("Xbox game2", DateTime.Today)
            };
            ignatProjectses[0].CloseProject();
            
            List<Person> differentEmployees = new List<Person>()
            {
                new Manager("1234R", "Ivan", "Goshev", 500.20m, "Production"),
                new Manager("1234Q", "Soas", "Ivanov",700.20m, "Sales"),
                new Manager("1234W", "Grigor", "Asenov", 800, "Accounting"),
                new SalesEmployee("2345P", "Pesho", "Peshev", 300m,"Sales", peshoSales),
                new SalesEmployee("2345P", "Dragan", "Ivanov", 500m,"Sales", draganSales),
                new SalesEmployee("2345P", "Ivo", "Milanov", 300m,"Sales", ivoSales),
                new Developer("6789P", "Asen", "Georgiev", 700m, "Production", (List<Projects>)asenProjectses),
                new Developer("6789W", "Ignat", "Peshev", 900m, "Production", (List<Projects>)ignatProjectses),
            };
            foreach (var employee in differentEmployees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
