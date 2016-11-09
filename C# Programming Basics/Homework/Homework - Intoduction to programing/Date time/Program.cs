using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Date_time
{
    class Program
    {
        static void Main()
        {
            Console.Write(DateTime.Now.ToString("dd.MM.yyyy" + " г. "));

            Console.Write(DateTime.Now.ToString("h:mm:ss" + " ч."));
           
        }
    }
}
