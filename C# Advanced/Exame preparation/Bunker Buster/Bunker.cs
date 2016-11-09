namespace MyBunkerBuster
{
    using System;
    using System.Linq;
    
    public class Bunker
    {
        public static void Main()
        {
            var matrixData = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = matrixData[0];
            int cols = matrixData[1];

            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var dataBunker = Console.ReadLine().Split().ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = int.Parse(dataBunker[col]);
                }
            }

            int destroyed = 0;

            string inputCommand = Console.ReadLine();
            while (inputCommand != "cease fire!")
            {
                var input = inputCommand.Split().ToArray();
                int bombRow = int.Parse(input[0]);
                int bombCol = int.Parse(input[1]);
                var charArr = input[2].ToCharArray();
                int damage = charArr[0];

                matrix[bombRow, bombCol] = matrix[bombRow, bombCol] - damage;
                double halfDamage = Math.Round((double)damage / 2, 0, MidpointRounding.AwayFromZero);

                int damagedRow = bombRow - 2;
                int damagedCol = bombCol - 2;

                for (int r = 0; r < 3; r++)
                {
                    damagedRow++;
                    for (int c = 0; c < 3; c++)
                    {
                        damagedCol++;
                        bool notBobedCell = damagedRow != bombRow || damagedCol != bombCol;
                        bool rowInMatrix = damagedRow >= 0 && damagedRow <= rows - 1;
                        bool colInMatrix = damagedCol >= 0 && damagedCol <= cols - 1;
                        if (rowInMatrix && colInMatrix && notBobedCell)
                        {
                            matrix[damagedRow, damagedCol] = matrix[damagedRow, damagedCol] - (int)halfDamage;
                        }
                    }

                    damagedCol = bombCol - 2;
                }

                inputCommand = Console.ReadLine();
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] <= 0)
                    {
                        destroyed++;
                    }
                }
            }

            Console.WriteLine("Destroyed bunkers: {0}", destroyed);
            double percentNotDestroyed = ((double)destroyed / ((double)rows * (double)cols)) * 100;
            Console.WriteLine("Damage done: {0:F1} %", percentNotDestroyed);

            //PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
