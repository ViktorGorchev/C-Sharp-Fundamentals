using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAGame.Interfaces;

namespace SAGame.UI
{
    public class Renderer : IRenderer
    {
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
