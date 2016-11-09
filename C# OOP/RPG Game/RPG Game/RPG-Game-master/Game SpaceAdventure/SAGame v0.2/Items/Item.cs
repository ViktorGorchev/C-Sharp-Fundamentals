using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAGame_v0._2.Enums;
using SAGame_v0._2.Interfaces;

namespace SAGame_v0._2.Items
{
    public abstract class Item : ICollectible, IObjectPosition
    {
        private string name;
        private Position position;

        protected Item(string name, Position position)
        {
            this.Name = name;
            this.Position = position;
            this.State = ItemState.Available;
        }
        public string Name { get; }
        public Position Position { get; set; }
        public ItemState State { get; set; }

        public override string ToString()
        {
            StringBuilder item = new StringBuilder();
            item.AppendFormat(this.Name);
            return item.ToString();
        }
    }
}
