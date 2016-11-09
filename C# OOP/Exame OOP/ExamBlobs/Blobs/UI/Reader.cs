using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blobs.Contracts;

namespace Blobs.UI
{
    public class Reader : IReade
    {
        public string Reade()
        {
            var input = Console.ReadLine();
            return input;
        }
    }
}
