namespace VegetableNinja.Contracts
{
    using VegetableNinja.Core;

    public interface IPlayer
    {
        string Name { get; }

        char PlayerSymbol { get; }

        int Power { get; set; }

        int Stamina { get; set; }

        Position Position { get; set; }

        bool IsOnTurn { get; set; }
    }
}
