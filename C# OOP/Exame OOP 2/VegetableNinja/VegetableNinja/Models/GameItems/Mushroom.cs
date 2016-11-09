namespace VegetableNinja.Models.GameItems
{
    using VegetableNinja.Core;

    public class Mushroom : Item
    {
        private const char MushroomDefaultSymbol = 'M';
        private const int MushroomDefaultPowerEffectl = -10;
        private const int MushroomDefaultStaminaEffect = -10;
        private const int MushroomDefaultRegrowMoves = 5;

        public Mushroom(Position position)
            : base(
            MushroomDefaultSymbol, 
            MushroomDefaultPowerEffectl, 
            MushroomDefaultStaminaEffect, 
            position, 
            MushroomDefaultRegrowMoves)
        {
            this.CurrentVegetableSymbol = MushroomDefaultSymbol;
        }
    }
}
