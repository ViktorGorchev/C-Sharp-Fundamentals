using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.Contracts;

namespace Minesweeper.UI
{
    public class Renderer : IRenderer
    {
        public void RenderNewLine(string output)
        {
            Console.WriteLine(output);
        }

        public void Render(string output)
        {
            Console.Write(output);
        }
    }
}
