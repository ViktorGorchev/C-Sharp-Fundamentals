namespace VegetableNinja.Contracts
{
    using System.Collections.Generic;

    public interface IDatabase
    {
        IEnumerable<IPlayer> Players { get; set; }

        IEnumerable<IItem> Items { get; set; }

        void AddPlayer(IPlayer player);

        void AddItem(IItem item);

        void ChagePlayerPsition(string playerName, int row, int col);

        void PlayerTurn(string playerName, bool isOnTurn);

        void SetPower(string playerName, int newPower);

        void SetStamina(string playerName, int newStamina);
    }
}
