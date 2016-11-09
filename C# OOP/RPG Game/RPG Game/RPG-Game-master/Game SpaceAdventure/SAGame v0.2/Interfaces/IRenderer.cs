using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAGame_v0._2.Interfaces
{
    public interface IRenderer
    {
        void WriteLine(string message, params object[] parameters);
        void WriteLine(string message);
        void Clear();
    }
}
