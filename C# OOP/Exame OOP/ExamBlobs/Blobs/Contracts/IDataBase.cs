using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blobs.Contracts
{
    public interface IDataBase
    {
        IEnumerable<ICharacters> AllCharacters { get; }
        void AddCharacter(ICharacters character);
    }
}
