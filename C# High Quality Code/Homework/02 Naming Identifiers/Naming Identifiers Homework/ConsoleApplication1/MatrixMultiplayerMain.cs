namespace ConsoleApplication1
{
    using System;

    /// <summary>
    /// The class defines two matrices, multiplies them and prints their product. 
    /// </summary>
    public class MatrixMultiplayerMain
    {
        /// <summary>
        /// The method defines two matrices and prints their product.
        /// </summary>
        public static void Main()
        {
            var firstMatrix = new double[,] { { 1, 3 }, { 5, 7 } };
            var secondMatrix = new double[,] { { 4, 2 }, { 1, 5 } };
            var productMatrix = MultiplyMatrices(firstMatrix, secondMatrix);
            
            for (int row = 0; row < productMatrix.GetLength(0); row++)
            {
                for (int j = 0; j < productMatrix.GetLength(1); j++)
                {
                    Console.Write(productMatrix[row, j] + " ");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Multiplies the two matrices received as arguments.
        /// </summary>
        /// <param name="firstMatrix">
        /// The first matrix.
        /// </param>
        /// <param name="secondMatrix">
        /// The second matrix.
        /// </param>
        /// <returns>
        /// a matrix which is the product of the multiplication of the two matrices received as arguments
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// The columns number of the first matrix must be equal to the rows number of
        ///     the second matrix.
        /// </exception>
        public static double[,] MultiplyMatrices(double[,] firstMatrix, double[,] secondMatrix)
        {
            if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0))
            {
                throw new ArgumentException(
                    "The columns number of the first matrix must be equal to the rows number of the second matrix.");
            }

            var productMatrix = new double[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
            for (int row = 0; row < productMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < productMatrix.GetLength(1); col++)
                {
                    for (int i = 0; i < firstMatrix.GetLength(1); i++)
                    {
                        productMatrix[row, col] += firstMatrix[row, i] * secondMatrix[i, col];
                    }
                }
            }

            return productMatrix;
        }
    }
}