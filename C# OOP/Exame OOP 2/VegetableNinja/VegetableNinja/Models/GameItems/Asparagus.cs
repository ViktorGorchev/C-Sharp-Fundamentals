namespace VegetableNinja.Models.GameItems
{
    using VegetableNinja.Core;

    public class Asparagus : Item
    {
        private const char AsparagusDefaultSymbol = 'A';
        private const int AsparagusDefaultPowerEffectl = 5;
        private const int AsparagusDefaultStaminaEffect = -5;
        private const int AsparagusDefaultRegrowMoves = 2;

        public Asparagus(Position position)
            : base(
            AsparagusDefaultSymbol, 
            AsparagusDefaultPowerEffectl, 
            AsparagusDefaultStaminaEffect, 
            position, 
            AsparagusDefaultRegrowMoves)
        {
            this.CurrentVegetableSymbol = AsparagusDefaultSymbol;
        }
    }
}
