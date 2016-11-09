using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCapitalism.Interfaces;

namespace TestCapitalism.UI
{
    public class Reader: IRead
    {
        public string Reade()
        {
            return Console.ReadLine();
        }
    }
}
