using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Contracts
{
    public interface IRenderer
    {
        void RenderNewLine(string output);
        void Render(string output);
    }
}
