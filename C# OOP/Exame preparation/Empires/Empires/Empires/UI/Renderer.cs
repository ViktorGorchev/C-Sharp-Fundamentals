using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Interfaces;

namespace Empires.UI
{
    class Renderer : IRender
    {
        public void Render(string output)
        {
            Console.WriteLine(output);
        }
    }
}
