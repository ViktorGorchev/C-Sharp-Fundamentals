using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAGame_v0._2.Interfaces;

namespace SAGame_v0._2.UI
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
