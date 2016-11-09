namespace MyRubiksMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    public class Program
    {
        private static int[,] matrix = null;
        private static List<int> tempList = new List<int>();

        public static void Main()
        {
            var sizeMatrix = ConvertCToSpacesRegex(Console.ReadLine()).Split().Select(int.Parse).ToArray();
            int allRows = sizeMatrix[0];
            int allCols = sizeMatrix[1];
            int numberCommands = int.Parse(ConvertCToSpacesRegex(Console.ReadLine()).Trim());

            int count = 0;
            matrix = new int[allRows, allCols];
            for (int row = 0; row < allRows; row++)
            {
                for (int col = 0; col < allCols; col++)
                {
                    count++;
                    matrix[row, col] = count;
                }
            }

            for (int i = 0; i < numberCommands; i++)
            {
                var input = ConvertCToSpacesRegex(Console.ReadLine()).Split();
                int rowOrCol = int.Parse(input[0]);
                string direction = input[1];
                int moveNumber = int.Parse(input[2]);

                int index;
                tempList = new List<int>();
                switch (direction)
                {
                    case "up":
                        AddColToTempList(allRows, rowOrCol);
                        index = RotateIndexLeftOrRight(0, moveNumber, tempList.Count);
                        tempList = ExchangeArray(tempList.ToArray(), index).ToList();
                        UpdateCol(allRows, rowOrCol);
                        break;
                    case "down":
                        AddColToTempList(allRows, rowOrCol);
                        index = RotateIndexLeftOrRight(0, moveNumber * -1, tempList.Count);
                        tempList = ExchangeArray(tempList.ToArray(), index).ToList();
                        UpdateCol(allRows, rowOrCol);
                        break;
                    case "left":
                        AddRowToTempList(allCols, rowOrCol);
                        index = RotateIndexLeftOrRight(0, moveNumber, tempList.Count);
                        tempList = ExchangeArray(tempList.ToArray(), index).ToList();
                        UpdateRow(allCols, rowOrCol);
                        break;
                    case "right":
                        AddRowToTempList(allCols, rowOrCol);
                        index = RotateIndexLeftOrRight(0, moveNumber * -1, tempList.Count);
                        tempList = ExchangeArray(tempList.ToArray(), index).ToList();
                        UpdateRow(allCols, rowOrCol);
                        break;
                    default:
                        break;
                }
            }

            PrintHowToRearrangeMatrix();
        }

        private static void PrintHowToRearrangeMatrix()
        {
            var rearrangedMatrix = matrix;
            int count = 1;
            for (int row = 0; row < rearrangedMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < rearrangedMatrix.GetLength(1); col++)
                {
                    if (rearrangedMatrix[row, col] == count)
                    {
                        Console.WriteLine("No swap required");
                        count++;
                        continue;
                    }

                    int[] data = null;
                    if (count == 1)
                    {
                        data = FindElement(1, rearrangedMatrix);
                    }
                    else
                    {
                        data = FindElement(count, rearrangedMatrix);
                    }

                    int tempNumber = rearrangedMatrix[row, col];
                    rearrangedMatrix[row, col] = rearrangedMatrix[data[0], data[1]];
                    rearrangedMatrix[data[0], data[1]] = tempNumber;

                    Console.WriteLine("Swap ({0}, {1}) with ({2}, {3})", row, col, data[0], data[1]);

                    count++;
                }
            }

        }

        private static int[] FindElement(int number, int[,] rearrangedMatrix)
        {
            for (int i = 0; i < rearrangedMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < rearrangedMatrix.GetLength(1); j++)
                {
                    if (rearrangedMatrix[i, j] == number)
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return null;
        }

        private static void UpdateCol(int allRows, int col)
        {
            for (int row = 0; row < allRows; row++)
            {
                matrix[row, col] = tempList[row];
            }
        }

        private static void UpdateRow(int allCols, int row)
        {
            for (int col = 0; col < allCols; col++)
            {
                matrix[row, col] = tempList[col];
            }
        }

        private static void AddColToTempList(int allRows, int col)
        {
            for (int row = 0; row < allRows; row++)
            {
                tempList.Add(matrix[row, col]);
            }
        }

        private static void AddRowToTempList(int allCols, int row)
        {
            for (int col = 0; col < allCols; col++)
            {
                tempList.Add(matrix[row, col]);
            }
        }

        private static int RotateIndexLeftOrRight(int currentIndex, int offset, int arrayCount)
        {
            int index = currentIndex; ////index to start from

            if (offset < 0)
            {
                ////rotate left -> offset -1, -2, -3...
                ////Math.Abs() converts -2 to 2
                for (int i = 0; i < Math.Abs(offset); i++)
                {
                    index += -1;
                    if (index < 0)
                    {
                        index = arrayCount - 1;
                    }
                }
            }
            else
            {
                /////rotate right -> offset 1, 2, 3...
                for (int i = 0; i < offset; i++)
                {
                    index += 1;
                    if (index > arrayCount - 1)
                    {
                        index = 0;
                    }
                }
            }

            return index;
        }

        private static int[] ExchangeArray(int[] arr, int index)
        {
            return arr.Skip(index).Concat(arr.Take(index)).ToArray();
        }
        

        private static string ConvertCToSpacesRegex(string value)
        {
            value = Regex.Replace(value, @"\s+", " ");
            return value;
        }
    }
}