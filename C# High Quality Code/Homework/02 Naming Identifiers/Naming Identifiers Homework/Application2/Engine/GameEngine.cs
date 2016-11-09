using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper.Engine
{
    using Contracts;

    public class GameEngine : IEngine
    {
        private const int ChampionsRankList = 6;
        private const int Max = 35;
        private string command = string.Empty;
        private char[,] gameField;
        private char[,] mines;
        private int counter;
        private bool mineEncountered;
        private readonly List<Ranking> champions = new List<Ranking>(ChampionsRankList);
        private int row;
        private int col;
        private bool showGameCommands;
        private bool playerIsWinner;
        private readonly IReader reader;
        private readonly IRenderer renderer;
        
        public GameEngine(IReader reader, IRenderer renderer)
        {
            this.gameField = CreateGameField();
            this.mines = SetMines();
            this.mineEncountered = false;
            this.showGameCommands = true;
            this.playerIsWinner = false;
            this.reader = reader;
            this.renderer = renderer;
        }

        public virtual void Run()
        {
            do
            {
                if (this.showGameCommands)
                {
                    this.renderer.RenderNewLine(
                        "Let’s play Minesweeper. Try to find the fields without mines. " +
                        "Command  ’top’ will show you the ranking, " +
                        "command ‘restart’ starts a new game and command ‘exit’ ends the game!");
                   this.CreateGameBorders(gameField);
                    this.showGameCommands = false;
                }

                this.renderer.Render("Enter numbers for row and column: ");
                this.command = this.reader.Reade();
                if (!string.IsNullOrWhiteSpace(command) && command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out this.row) && int.TryParse(command[2].ToString(), out this.col)
                        && this.row <= gameField.GetLength(0) && this.col <= gameField.GetLength(1))
                    {
                        this.command = "turn";
                    }

                }

                switch (this.command)
                {
                    case "top":
                        this.PlayersRanking();
                        break;
                    case "restart":
                        this.gameField = CreateGameField();
                        this.mines = SetMines();
                        this.CreateGameBorders(gameField);
                        break;
                    case "exit":
                        this.renderer.Render("See you soon!");
                        break;
                    case "turn":
                        this.CheckForMines();
                        break;
                    default:
                        this.renderer.Render(Environment.NewLine + "Unknown command!" + Environment.NewLine);
                        break;
                }

                if (this.mineEncountered)
                {
                    this.CreateGameBorders(mines);

                    StringBuilder mineEncounteredMessage = new StringBuilder();
                    mineEncounteredMessage.AppendFormat(
                        Environment.NewLine + "Mine encountered! You have {0} points. Please enter your name: ", counter);
                    this.renderer.Render(mineEncounteredMessage.ToString());

                    string name = Console.ReadLine();
                    Ranking player = new Ranking(name, counter);
                    if (this.champions.Count < ChampionsRankList - 1)
                    {
                        this.champions.Add(player);
                    }
                    else
                    {
                        for (int i = 0; i < this.champions.Count; i++)
                        {
                            if (this.champions[i].Points < player.Points)
                            {
                                this.champions.Insert(i, player);
                                this.champions.RemoveAt(champions.Count - 1);
                                break;
                            }

                        }

                    }

                    this.champions.Sort((Ranking r1, Ranking r2) => String.Compare(r2.Player, r1.Player, StringComparison.Ordinal));
                    this.champions.Sort((Ranking r1, Ranking r2) => r2.Points.CompareTo(r1.Points));
                    this.PlayersRanking();

                    this.gameField = CreateGameField();
                    this.mines = SetMines();
                    this.counter = 0;
                    this.mineEncountered = false;
                    this.showGameCommands = true;
                }

                if (this.playerIsWinner)
                {
                    this.renderer.RenderNewLine(Environment.NewLine + "You are a winner!");
                    this.CreateGameBorders(mines);
                    this.renderer.RenderNewLine("Please enter your name: ");
                    string name = Console.ReadLine();
                    Ranking player = new Ranking(name, counter);
                    this.champions.Add(player);
                    this.PlayersRanking();
                    this.gameField = CreateGameField();
                    this.mines = SetMines();
                    this.counter = 0;
                    this.playerIsWinner = false;
                    this.showGameCommands = true;
                }

            } while (this.command != "exit");

        }
    
        private void CheckForMines()
        {
            if (this.mines[row, col] != '*')
            {
                if (this.mines[row, col] == '-')
                {
                    this.NewGameTurn();
                    this.counter++;
                }

                if (Max == this.counter)
                {
                    this.playerIsWinner = true;
                }
                else
                {
                    this.CreateGameBorders(this.gameField);
                }

            }
            else
            {
                this.mineEncountered = true;
            }

        }

        private void PlayersRanking()
        {
            this.renderer.RenderNewLine(Environment.NewLine + "Points:");
            if (this.champions.Count > 0)
            {
                for (int i = 0; i < this.champions.Count; i++)
                {
                    StringBuilder ranking = new StringBuilder();
                    ranking.AppendFormat("{0}. {1} --> {2} boxes", i + 1, this.champions[i].Player,
                        this.champions[i].Points);
                    this.renderer.RenderNewLine(ranking.ToString());
                }

                this.renderer.Render(Environment.NewLine);
            }
            else
            {
                this.renderer.RenderNewLine("N/A" + Environment.NewLine);
            }

        }

        private void NewGameTurn()
        {
            char minesCount = this.MinesCount();
            this.mines[this.row, this.col] = minesCount;
            this.gameField[this.row, this.col] = minesCount;
        }

        private void CreateGameBorders(char[,] board)
        {
            int boardRows = board.GetLength(0);
            int boardCols = board.GetLength(1);
            this.renderer.RenderNewLine(Environment.NewLine + "    0 1 2 3 4 5 6 7 8 9");
            this.renderer.RenderNewLine("   ---------------------");
            for (int i = 0; i < boardRows; i++)
            {
                StringBuilder printRowBorders = new StringBuilder();
                printRowBorders.AppendFormat("{0} | ", i);
                this.renderer.Render(printRowBorders.ToString());
                for (int j = 0; j < boardCols; j++)
                {
                    StringBuilder printColBorders = new StringBuilder();
                    printColBorders.AppendFormat("{0} ", board[i, j]);
                    this.renderer.Render(printColBorders.ToString());
                }

                this.renderer.RenderNewLine("|");
            }

            this.renderer.RenderNewLine("   ---------------------" + Environment.NewLine);
        }

        private char[,] CreateGameField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }

            }

            return board;
        }

        private char[,] SetMines()
        {
            int rows = 5;
            int cols = 10;
            char[,] mineField = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    mineField[i, j] = '-';
                }

            }

            List<int> mines = new List<int>();
            while (mines.Count < 15)
            {
                Random random = new Random();
                int newMine = random.Next(50);
                if (!mines.Contains(newMine))
                {
                    mines.Add(newMine);
                }

            }

            foreach (int mine in mines)
            {
                int col = mine / cols;
                int row = mine % cols;
                if (row == 0 && mine != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                mineField[col, row - 1] = '*';
            }

            return mineField;
        }
        
        private char MinesCount()
        {
            int count = 0;
            int minesArrayRows = this.mines.GetLength(0);
            int minesArrayCols = this.mines.GetLength(1);

            if (this.row - 1 >= 0)
            {
                if (this.mines[this.row - 1, this.col] == '*')
                {
                    count++;
                }

            }

            if (this.row + 1 < minesArrayRows)
            {
                if (this.mines[this.row + 1, this.col] == '*')
                {
                    count++;
                }

            }

            if (this.col - 1 >= 0)
            {
                if (this.mines[this.row, this.col - 1] == '*')
                {
                    count++;
                }

            }

            if (this.col + 1 < minesArrayCols)
            {
                if (this.mines[this.row, this.col + 1] == '*')
                {
                    count++;
                }

            }

            if ((this.row - 1 >= 0) && (this.col - 1 >= 0))
            {
                if (this.mines[this.row - 1, this.col - 1] == '*')
                {
                    count++;
                }

            }

            if ((this.row - 1 >= 0) && (this.col + 1 < minesArrayCols))
            {
                if (this.mines[this.row - 1, this.col + 1] == '*')
                {
                    count++;
                }

            }

            if ((this.row + 1 < minesArrayRows) && (this.col - 1 >= 0))
            {
                if (this.mines[this.row + 1, this.col - 1] == '*')
                {
                    count++;
                }

            }

            if ((this.row + 1 < minesArrayRows) && (this.col + 1 < minesArrayCols))
            {
                if (this.mines[this.row + 1, this.col + 1] == '*')
                {
                    count++;
                }

            }

            return char.Parse(count.ToString());
        }
    }
}
