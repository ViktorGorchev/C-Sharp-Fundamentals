namespace VegetableNinja.Models.GameItems
{
    using VegetableNinja.Core;

    public class Broccoli : Item
    {
        private const char BroccoliDefaultSymbol = 'B';
        private const int BroccoliDefaultPowerEffectl = 10;
        private const int BroccoliDefaultStaminaEffect = 0;
        private const int BroccoliDefaultRegrowMoves = 3;

        public Broccoli(Position position)
            : base(
            BroccoliDefaultSymbol, 
            BroccoliDefaultPowerEffectl, 
            BroccoliDefaultStaminaEffect, 
            position, 
            BroccoliDefaultRegrowMoves)
        {
            this.CurrentVegetableSymbol = BroccoliDefaultSymbol;
        }
    }
}
