using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAGame.Interfaces;

namespace SAGame.UI
{
    public class InputReader : IInputReader
    {
        public string ReadLine()
        {
            var input = Console.ReadLine();
            return input;
        }
    }
}
