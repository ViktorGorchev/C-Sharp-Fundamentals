﻿namespace VegetableNinja.Core
{
    public struct Position
    {
        public Position(int row, int col)
            : this()
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }
    }
}
