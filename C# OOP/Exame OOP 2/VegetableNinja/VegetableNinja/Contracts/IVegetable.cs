namespace VegetableNinja.Contracts
{
    public interface IVegetable
    {
        int RegrowMoves { get; }

        char CurrentVegetableSymbol { get; set; }
    }
}
