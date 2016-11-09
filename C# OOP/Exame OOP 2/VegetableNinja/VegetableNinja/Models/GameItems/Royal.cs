namespace VegetableNinja.Models.GameItems
{
    using VegetableNinja.Core;

    public class Royal : Item
    {
        private const char RoyalDefaultSymbol = 'R';
        private const int RoyalDefaultPowerEffectl = 20;
        private const int RoyalDefaultStaminaEffect = 10;
        private const int RoyalDefaultRegrowMoves = 10;

        public Royal(Position position)
            : base(
            RoyalDefaultSymbol, 
            RoyalDefaultPowerEffectl, 
            RoyalDefaultStaminaEffect, 
            position, 
            RoyalDefaultRegrowMoves)
        {
            this.CurrentVegetableSymbol = RoyalDefaultSymbol;
        }
    }
}
