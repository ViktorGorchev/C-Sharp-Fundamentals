using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blobs.Contracts;

namespace Blobs.UI
{
    public class Renderer : IRender
    {
        public void Render(string output)
        {
            Console.WriteLine(output);
        }
    }
}
