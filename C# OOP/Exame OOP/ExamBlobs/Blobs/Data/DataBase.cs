using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blobs.Contracts;

namespace Blobs.Data
{
    public class DataBase: IDataBase
    {
        private readonly ICollection<ICharacters> allCharacters = new List<ICharacters>();
        
        IEnumerable<ICharacters> IDataBase.AllCharacters
        {
            get { return this.allCharacters; }
        }

        public void AddCharacter(ICharacters character)
        {
            this.allCharacters.Add(character);
        }

        
    }
}
