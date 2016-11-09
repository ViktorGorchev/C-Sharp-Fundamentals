using System;

using SAGame.Interfaces;
using SAGame.Enums;

namespace SAGame.Items
{
    public abstract class Item : ICollectible
    {
        private Position position;
        protected Item(Position position)
        {
            this.Position = position;
            this.State = ItemState.Available;
        }

        public Position Position { get; set; }


        public ItemState State { get; set; }
    }
}
