namespace VegetableNinja.Contracts
{
    using VegetableNinja.Core;

    public interface IFactory
    {
        IPlayer CreatePlayer(string name, int row, int col);

        IItem CreateItem(char symbol, int row, int col);
    }
}
