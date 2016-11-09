namespace VegetableNinja.Models.GameItems
{
    using VegetableNinja.Core;

    public class CherryBerry : Item
    {
        private const char CherryBerryDefaultSymbol = 'C';
        private const int CherryBerryDefaultPowerEffectl = 0;
        private const int CherryBerryDefaultStaminaEffect = 10;
        private const int CherryBerryDefaultRegrowMoves = 5;

        public CherryBerry(Position position)
            : base(
            CherryBerryDefaultSymbol, 
            CherryBerryDefaultPowerEffectl, 
            CherryBerryDefaultStaminaEffect, 
            position, 
            CherryBerryDefaultRegrowMoves)
        {
            this.CurrentVegetableSymbol = CherryBerryDefaultSymbol;
        }
    }
}
