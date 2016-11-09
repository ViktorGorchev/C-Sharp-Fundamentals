namespace RotatingWalkInMatrixTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RotatingWalkInMatrix;

    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        public void TestGenerateMatrixWithSize1()
        {
            const int Size = 1;
            int[,] matrix = WalkInMatrix.GenerateMatrix(Size);

            int[,] expectedResult = { { 1 } };

            CollectionAssert.AreEqual(expectedResult, matrix);
        }

        [TestMethod]
        public void TestGenerateMatrixWithSize2()
        {
            const int Size = 2;
            int[,] matrix = WalkInMatrix.GenerateMatrix(Size);

            int[,] expectedResult = { { 1, 4 }, { 3, 2 } };

            CollectionAssert.AreEqual(expectedResult, matrix);
        }

        [TestMethod]
        public void TestGenerateMatrixWithSize3()
        {
            const int Size = 3;
            int[,] matrix = WalkInMatrix.GenerateMatrix(Size);

            int[,] expectedResult = { { 1, 7, 8 }, { 6, 2, 9 }, { 5, 4, 3 } };

            CollectionAssert.AreEqual(expectedResult, matrix);
        }

        [TestMethod]
        public void TestGenerateMatrixWithSize6()
        {
            const int Size = 6;
            int[,] matrix = WalkInMatrix.GenerateMatrix(Size);

            int[,] expectedResult =
            {
                { 1, 16, 17, 18, 19, 20 },
                { 15, 2, 27, 28, 29, 21 },
                { 14, 31, 3, 26, 30, 22 },
                { 13, 36, 32, 4, 25, 23 },
                { 12, 35, 34, 33, 5, 24 },
                { 11, 10, 9, 8, 7, 6 }
            };

            CollectionAssert.AreEqual(expectedResult, matrix);
        }
    }
}
