namespace VegetableNinja.Core
{
    using System;

    using VegetableNinja.Contracts;
    using VegetableNinja.Models.GameItems;
    using VegetableNinja.Models.GamePlayers;

    public class Factory : IFactory
    {
        public IPlayer CreatePlayer(string name, int row, int col)
        {
            return new Ninja(name, new Position(row, col));
        }

        public IItem CreateItem(char symbol, int row, int col)
        {
            switch (symbol)
            {
                case 'A':
                    return new Asparagus(new Position(row, col));
                case 'B':
                    return new Broccoli(new Position(row, col));
                case 'C':
                    return new CherryBerry(new Position(row, col));
                case 'M':
                    return new Mushroom(new Position(row, col));
                case 'R':
                    return new Royal(new Position(row, col));
                default:
                    throw new ArgumentException("Invalid item symbol!");
            }
        }
    }
}
