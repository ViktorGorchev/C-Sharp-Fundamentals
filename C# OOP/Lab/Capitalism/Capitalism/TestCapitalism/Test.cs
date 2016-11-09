using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCapitalism.Engine;
using TestCapitalism.Interfaces;

namespace TestCapitalism
{
    public class Test
    {
        static void Main()
        {
            //var a = new Ceo("aa", "bb", "cc", 1000m);
            //Console.WriteLine("CEO--> " + a.Salary);
            
            //var m = new Manager("aa", "b", "c", a.Salary,"hh");
            //Console.WriteLine("Manager--> " + m.Salary);
          
            //var b = new Accountant("aa", "g", "b", a.Salary,"x", "f");
            //Console.WriteLine("Accountant--> " + b.Salary);

            //var ch = new ChiefTelephoneOfficers("aa", "a", "s", a.Salary, "h", "l");
            //Console.WriteLine("Chief Telephone Officers--> " + ch.Salary);

            //var cl = new CleaningLady("aa", "a", "s", a.Salary, "h", "l");
            //Console.WriteLine("Cleaning Lady--> " + cl.Salary);

            //var s = new Salesmen("aa", "a", "s", a.Salary, "h", "l");
            //Console.WriteLine("Salesmen--> " + s.Salary);

            ICapitalismEngine engine = new CpitalismEngine();
            engine.Run();

        }
    }
}
