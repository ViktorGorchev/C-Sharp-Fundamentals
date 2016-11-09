namespace VegetableNinja.Models.GameItems
{
    using System;

    using VegetableNinja.Contracts;
    using VegetableNinja.Core;

    public abstract class Item : IItem
    {
        private int regrowMoves;

        protected Item(char itemSymbol, int powerEffect, int staminaEffect, Position position, int regrowMoves)
        {
            this.ItemSymbol = itemSymbol;
            this.PowerEffect = powerEffect;
            this.StaminaEffect = staminaEffect;
            this.Position = position;
            this.RegrowMoves = regrowMoves;
        }

        public char ItemSymbol { get; private set; }

        public int PowerEffect { get; private set; }

        public int StaminaEffect { get; private set; }

        public Position Position { get; set; }

        public int RegrowMoves
        {
            get
            {
                return this.regrowMoves;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Moves cannot be less than zero!");
                }

                this.regrowMoves = value;
            }
        }

        public char CurrentVegetableSymbol { get; set; }
    }
}
