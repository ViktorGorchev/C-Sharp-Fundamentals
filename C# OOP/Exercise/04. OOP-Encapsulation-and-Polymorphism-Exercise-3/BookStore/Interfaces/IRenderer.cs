using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.UI
{
    interface IRenderer
    {
        void WriteLine(string message, params string[] parameters);

    }
}
