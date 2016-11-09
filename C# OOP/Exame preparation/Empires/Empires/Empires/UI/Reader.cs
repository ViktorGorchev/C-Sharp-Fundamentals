using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Interfaces;

namespace Empires.UI
{
    public class Reader : IReader
    {
        public string Reade()
        {
            var input = Console.ReadLine();
            return input;
        }
    }
}
