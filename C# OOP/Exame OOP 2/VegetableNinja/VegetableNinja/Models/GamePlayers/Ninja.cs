namespace VegetableNinja.Models.GamePlayers
{
    using VegetableNinja.Core;

    public class Ninja : Player
    {
        private const int DefaultPower = 1;
        private const int DefaultStamina = 1;

        public Ninja(string name, Position position)
            : base(name, DefaultPower, DefaultStamina, position)
        {
        }
    }
}
