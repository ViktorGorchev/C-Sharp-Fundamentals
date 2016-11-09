namespace VegetableNinja.Models.GamePlayers
{
    using System;
    using System.Text;

    using VegetableNinja.Contracts;
    using VegetableNinja.Core;

    public abstract class Player : IPlayer
    {
        private string name;
        private int power;
        private int stamina;

        protected Player(string name, int power, int stamina, Position position)
        {
            this.Name = name;
            this.PlayerSymbol = this.Name[0];
            this.Power = power;
            this.Stamina = stamina;
            this.Position = position;
            this.IsOnTurn = false;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can't be null or empty space!");
                }

                this.name = value;
            }
        }

        public char PlayerSymbol { get; private set; }

        public int Power
        {
            get
            {
                return this.power;
            }

            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.power = value;
            }
        }

        public int Stamina
        {
            get
            {
                return this.stamina;
            }

            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.stamina = value;
            }
        }

        public Position Position { get; set; }

        public bool IsOnTurn { get; set; }

        public override string ToString()
        {
            StringBuilder winnerData = new StringBuilder();
            winnerData.AppendLine("Winner: " + this.Name);
            winnerData.AppendLine("Power: " + this.Power);
            winnerData.AppendLine("Stamina: " + this.Stamina);

            return winnerData.ToString();
        }
    }
}
