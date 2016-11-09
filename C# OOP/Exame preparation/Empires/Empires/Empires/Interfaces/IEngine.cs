using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empires.Interfaces
{
    public interface IEngine
    {
        IReader InputReader { get; }
        IRender OutputRender { get; }
        IDataBase DataBase { get; }

        void Run();

    }
}
