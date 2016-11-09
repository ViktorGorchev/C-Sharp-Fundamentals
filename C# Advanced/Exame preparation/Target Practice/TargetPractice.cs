namespace MyTargetPractice
{
    using System;

    public class TargetPractice
    {
        /// <summary>
        /// 1 chas!
        /// </summary>
        public static void Main()
        {
            var matrixData = Console.ReadLine().Split();
            int rows = int.Parse(matrixData[0]);
            int cols = int.Parse(matrixData[1]);

            string snake = Console.ReadLine();

            var shotData = Console.ReadLine().Split();
            int shotRowIndex = int.Parse(shotData[0]);
            int shotColIndex = int.Parse(shotData[1]);
            int radius = int.Parse(shotData[2]);

            int snakeIndex = 0;
            bool startAtEndOfrow = true;
            char[,] matrix = new char[rows, cols];
            for (int row = rows - 1; row >= 0; row--)
            {
                if (startAtEndOfrow)
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[snakeIndex];
                        snakeIndex++;
                        if (snakeIndex >= snake.Length)
                        {
                            snakeIndex = 0;
                        }
                    }

                    startAtEndOfrow = false;
                }
                else
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = snake[snakeIndex];
                        snakeIndex++;
                        if (snakeIndex >= snake.Length)
                        {
                            snakeIndex = 0;
                        }
                    }

                    startAtEndOfrow = true;
                }
            }

           

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
