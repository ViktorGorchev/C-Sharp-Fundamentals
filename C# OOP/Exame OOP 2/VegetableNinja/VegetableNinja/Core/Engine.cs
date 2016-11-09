namespace VegetableNinja.Core
{
    using System;
    using System.Linq;

    using VegetableNinja.Contracts;

    public class Engine : IEngine
    {
        private const char EmptySpace = '-';
        private readonly IReader reader;
        private readonly IRenderer render;
        private readonly IFactory factory;
        private readonly IDatabase database;
        private char[,] gameBoard;
        private string firstNinjaName;
        private string secondNinjaName;
        
        public Engine(IReader reader, IRenderer render, IFactory factory, IDatabase database)
        {
            this.reader = reader;
            this.render = render;
            this.factory = factory;
            this.database = database;
        }

        public void Run()
        {
            this.firstNinjaName = this.reader.Reade();
            this.secondNinjaName = this.reader.Reade();
            var boardSize = this.reader.Reade().Split().Select(int.Parse).ToArray();
            int boardRows = boardSize[0];
            int boardCols = boardSize[1];

            this.gameBoard = new char[boardRows, boardCols];
            for (int row = 0; row < boardRows; row++)
            {
                string inputLine = this.reader.Reade();
                for (int col = 0; col < boardCols; col++)
                {
                    this.gameBoard[row, col] = inputLine[col];
                    if (inputLine[col] == this.firstNinjaName[0])
                    {
                        var firstNinja = this.factory.CreatePlayer(this.firstNinjaName, row, col);
                        this.database.AddPlayer(firstNinja);
                    }

                    if (inputLine[col] == this.secondNinjaName[0])
                    {
                        var secondNinja = this.factory.CreatePlayer(this.secondNinjaName, row, col);
                        this.database.AddPlayer(secondNinja);
                    }

                    var item = this.factory.CreateItem(inputLine[col], row, col);
                    this.database.AddItem(item);
                }
            }
            
            while (true)
            {
                string inputLineCommands = this.reader.Reade();
                this.ExecuteCommand(inputLineCommands);
            }
        }

        private void ExecuteCommand(string inputLineCommands)
        {
            var currentNinja = (IPlayer)this.database.Players.Where(x => x.IsOnTurn);
            int ninjaRow = (int)currentNinja.Position.Row;
            int ninjaCol = (int)currentNinja.Position.Col;
           
            foreach (char command in inputLineCommands)
            {
                bool inGameBoard;
                bool playerColision;

                switch (command)
                {
                    case 'L':
                        inGameBoard = this.CheckIfInGameBoard(ninjaRow - 1, ninjaCol);
                        if (!inGameBoard)
                        {
                            continue;
                        }

                        playerColision = this.CheckForPlaierColision(currentNinja.Name, ninjaRow - 1, ninjaCol);
                        this.database.ChagePlayerPsition(currentNinja.Name, ninjaRow - 1, ninjaCol);
                        break;
                    case 'R':
                        inGameBoard = this.CheckIfInGameBoard(ninjaRow + 1, ninjaCol);
                        if (!inGameBoard)
                        {
                            continue;
                        }

                        playerColision = this.CheckForPlaierColision(currentNinja.Name, ninjaRow + 1, ninjaCol);
                        this.database.ChagePlayerPsition(currentNinja.Name, ninjaRow + 1, ninjaCol);
                        break;
                    case 'U':
                        inGameBoard = this.CheckIfInGameBoard(ninjaRow, ninjaCol - 1);
                        if (!inGameBoard)
                        {
                            continue;
                        }

                        playerColision = this.CheckForPlaierColision(currentNinja.Name, ninjaRow, ninjaCol - 1);
                        this.database.ChagePlayerPsition(currentNinja.Name, ninjaRow, ninjaCol - 1);
                        break;
                    case 'D':
                        inGameBoard = this.CheckIfInGameBoard(ninjaRow, ninjaCol + 1);
                        if (!inGameBoard)
                        {
                            continue;
                        }

                        playerColision = this.CheckForPlaierColision(currentNinja.Name, ninjaRow, ninjaCol + 1);
                        this.database.ChagePlayerPsition(currentNinja.Name, ninjaRow, ninjaCol + 1);
                        break;
                    default:
                        throw new ArgumentException("Invalid move command!");
                }
            }
        }

        private bool CheckIfInGameBoard(int ninjaRow, int ninjaCol)
        {
            bool inRow = ninjaRow >= 0 && ninjaRow < this.gameBoard.GetLength(0);
            bool inCol = ninjaCol >= 0 && ninjaCol < this.gameBoard.GetLength(1);

            if (inRow && inCol)
            {
                return true;
            }

            return false;
        }

        private bool CheckForPlaierColision(string name, int ninjaRow, int ninjaCol)
        {
            return this.database.Players.Any(
                player => player.Name != name && player.Position.Row == ninjaRow && player.Position.Col == ninjaCol);
        }
    }
}
