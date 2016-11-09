namespace E2
{
    using System;
    using System.Linq;

    public class Program
    {
        private const int HotelProfit = 10;
        private static char[,] board;
        private static int gameSteps = 0;
        private static int playerMoney = 50;
        private static int hotelsCount = 0;
        

        public static void Main()
        {
            var boardData = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int boardRows = boardData[0];
            int boardCols = boardData[1];

            board = new char[boardRows, boardCols];
            for (int row = 0; row < boardRows; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < boardCols; col++)
                {
                    board[row, col] = input[col];
                }
            }

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    gameSteps++;
                    //playerMoney += hotelsCount * HotelProfit;
                    if (row % 2 != 0)
                    {
                        if (board[row, col] == 'F')
                        {
                            playerMoney += hotelsCount * HotelProfit;
                            continue;
                        }

                        if (board[row, col] == 'J')
                        {
                            Console.WriteLine("Gone to jail at turn {0}.", gameSteps - 1); ///can be negative
                            gameSteps += 2;
                            playerMoney += (hotelsCount * HotelProfit) * 2;
                            continue;
                        }

                        ExecuteCommand(board[row, (board.GetLength(1) - 1) - col], row, (board.GetLength(1) - 1) - col);
                        continue;
                    }

                    if (board[row, col] == 'F')
                    {
                        playerMoney += hotelsCount * HotelProfit;
                        continue;
                    }

                    if (board[row, col] == 'J')
                    {
                        Console.WriteLine("Gone to jail at turn {0}.", gameSteps - 1); ///can be negative
                        gameSteps += 2;
                        playerMoney += (hotelsCount * HotelProfit) * 2;
                        continue;
                    }

                    ExecuteCommand(board[row, col], row, col);
                }
            }

            Console.WriteLine("Turns " + gameSteps);
            Console.WriteLine("Money " + playerMoney);
        }

        private static void ExecuteCommand(char symbol, int row, int col)
        {
            switch (symbol)
            {
                case 'H':
                    hotelsCount++;
                    Console.WriteLine("Bought a hotel for {0}. Total hotels: {1}.", playerMoney, hotelsCount);
                    playerMoney = 10;
                    playerMoney += hotelsCount * HotelProfit;
                    break;
                case 'S':
                    playerMoney += hotelsCount * HotelProfit;
                    int amountToSpend = (row + 1) * (col + 1);
                    int spendMoney = amountToSpend;
                    if (playerMoney - amountToSpend < 0)
                    {
                        spendMoney = playerMoney;
                    }

                    Console.WriteLine("Spent {0} money at the shop.", spendMoney);
                    playerMoney -= amountToSpend;
                    break;
                default:
                    break;
            }

            if (playerMoney < 0)
            {
                playerMoney = 0;
            }
        }

        private static void PrintBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
