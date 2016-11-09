namespace _5_CollectTheCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CollectCoins
    {
        public static void Main()
        {
            var maze = new List<List<char>>();
            int maxSize = 0;
            for (int i = 0; i < 4; i++)
            {
                maze.Add(Console.ReadLine().ToList());
                int currSize = maze[i].Count;
                if (currSize > maxSize)
                {
                    maxSize = currSize;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                int currSize = maze[i].Count;
                if (currSize < maxSize)
                {
                    for (int j = 0; j < maxSize - currSize; j++)
                    {
                        maze[i].Add(' ');
                    }
                }
            }

            var directions = Console.ReadLine().ToList();
            int posX = 0;
            int posY = 0;
            int coins = 0;
            int walls = 0;
            foreach (var direction in directions)
            {
                switch (direction)
                {
                    case 'V':
                        posX++;
                        //// If going out of the jagged array - return,
                        //// empty space cosidered as barrier too;
                        if (posX > maze.Count - 1 || posX < 0
                            || maze[posX][posY].Equals(' '))
                        {
                            walls++;
                            posX--;
                        }

                        if (maze[posX][posY].Equals('$'))
                        {
                            coins++;
                            maze[posX][posY] = '?';
                        }

                        break;
                    case '^':
                        posX--;
                        if (posX > maze.Count - 1 || posX < 0
                            || maze[posX][posY].Equals(' '))
                        {
                            walls++;
                            posX++;
                        }

                        if (maze[posX][posY].Equals('$'))
                        {
                            coins++;
                            maze[posX][posY] = '?';
                        }

                        break;
                    case '<':
                        posY--;
                        if (posY > maze[posX].Count - 1 || posY < 0
                            || maze[posX][posY].Equals(' '))
                        {
                            walls++;
                            posY++;
                        }

                        if (maze[posX][posY].Equals('$'))
                        {
                            coins++;
                            maze[posX][posY] = '?';
                        }

                        break;
                    case '>':
                        posY++;
                        if (posY > maze[posX].Count - 1 || posY < 0
                            || maze[posX][posY].Equals(' '))
                        {
                            walls++;
                            posY--;
                        }

                        if (maze[posX][posY].Equals('$'))
                        {
                            coins++;
                            maze[posX][posY] = '?';
                        }

                        break;
                }
            }

            Console.WriteLine("Coins collected: {0}", coins);
            Console.WriteLine("Walls hit: {0}", walls);
        }
    }
}
