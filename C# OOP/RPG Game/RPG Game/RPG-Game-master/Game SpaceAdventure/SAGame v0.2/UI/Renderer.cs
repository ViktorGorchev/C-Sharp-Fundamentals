using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAGame_v0._2.Interfaces;

namespace SAGame_v0._2.UI
{
    public class Renderer : IRenderer
    {
        public void WriteLine(string output, params object[] parameters)
        {
            Console.WriteLine(output, parameters);
        }

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
