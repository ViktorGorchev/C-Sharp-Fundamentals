using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCapitalism.Exeptions
{
    public class CommandExeption : Exception
    {
        public CommandExeption(string message)
            : base(message)
        {
        }
    }
}
