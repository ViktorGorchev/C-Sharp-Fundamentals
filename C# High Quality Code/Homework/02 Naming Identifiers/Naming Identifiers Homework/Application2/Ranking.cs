using System;

namespace Minesweeper
{
    public class Ranking
    {
        private string player;
        private int points;

        public Ranking(string player, int points)
        {
            this.Player = player;
            this.Points = points;
        }

        public string Player
        {
            get
            {
                return this.player;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new AggregateException("Player name can't be null!");
                }

                this.player = value;
            }
        }

        public int Points
        {
            get
            {
                return this.points;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "The points can't be less than 0!");
                }

                this.points = value;
            }
        }
    }
}
