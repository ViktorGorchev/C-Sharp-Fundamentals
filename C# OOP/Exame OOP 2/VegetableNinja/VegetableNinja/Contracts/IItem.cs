namespace VegetableNinja.Contracts
{
    using VegetableNinja.Core;

    public interface IItem
    {
        char ItemSymbol { get; }

        int PowerEffect { get; }

        int StaminaEffect { get; }

        Position Position { get; set; }

        int RegrowMoves { get; }

        char CurrentVegetableSymbol { get; set; }
    }
}
