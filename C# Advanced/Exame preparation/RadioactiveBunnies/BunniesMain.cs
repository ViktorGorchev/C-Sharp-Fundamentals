namespace RadioactiveBunnies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BunniesMain
    {
        public static void Main()
        {
            var mapData = Console.ReadLine().Split().Select(int.Parse).ToArray();

            char[,] map = new char[mapData[0], mapData[1]];
            int playerX = 0;
            int playerY = 0;
            for (int row = 0; row < mapData[0]; row++)
            {
                string lineInput = Console.ReadLine();
                for (int col = 0; col < mapData[1]; col++)
                {
                    if (lineInput[col] == 'P')
                    {
                        playerX = col;
                        playerY = row;
                    }

                    map[row, col] = lineInput[col];
                }
            }

            string commandLine = Console.ReadLine();

            int commandIndex = 0;
            bool gameActive = true;
            bool inMap = true;
            while (gameActive)
            {
                if (commandIndex > commandLine.Length - 1)
                {
                    Console.WriteLine("Command line ended!");
                    break;
                }

                char command = commandLine[commandIndex];
                bool collision = false;
                switch (command)
                {
                    case 'L':
                        inMap = PlayerInMap(playerX - 1, playerY, mapData);
                        if (!inMap)
                        {
                            map = UpdateMap(playerX, playerY, map, inMap);
                            gameActive = false;
                            break;
                        }

                        collision = CheckForColision(playerX - 1, playerY, map);
                        playerX -= 1;
                        if (collision)
                        {
                            gameActive = false;
                        }

                        map = UpdateMap(playerX, playerY, map, inMap);
                        collision = CheckForColision(playerX, playerY, map);
                        if (collision)
                        {
                            gameActive = false;
                        }

                        break;
                    case 'R':
                        inMap = PlayerInMap(playerX + 1, playerY, mapData);
                        if (!inMap)
                        {
                            map = UpdateMap(playerX, playerY, map, inMap);
                            gameActive = false;
                            break;
                        }

                        collision = CheckForColision(playerX + 1, playerY, map);
                        playerX += 1;
                        if (collision)
                        {
                            gameActive = false;
                        }

                        map = UpdateMap(playerX, playerY, map, inMap);
                        collision = CheckForColision(playerX, playerY, map);
                        if (collision)
                        {
                            gameActive = false;
                        }

                        break;
                    case 'U':
                        inMap = PlayerInMap(playerX, playerY - 1, mapData);
                        if (!inMap)
                        {
                            map = UpdateMap(playerX, playerY, map, inMap);
                            gameActive = false;
                            break;
                        }

                        collision = CheckForColision(playerX, playerY - 1, map);
                        playerY -= 1;
                        if (collision)
                        {
                            gameActive = false;
                        }

                        map = UpdateMap(playerX, playerY, map, inMap);
                        collision = CheckForColision(playerX, playerY, map);
                        if (collision)
                        {
                            gameActive = false;
                        }

                        break;
                    case 'D':
                        inMap = PlayerInMap(playerX, playerY + 1, mapData);
                        if (!inMap)
                        {
                            map = UpdateMap(playerX, playerY, map, inMap);
                            gameActive = false;
                            break;
                        }

                        collision = CheckForColision(playerX, playerY + 1, map);
                        playerY += 1;
                        if (collision)
                        {
                            gameActive = false;
                        }

                        map = UpdateMap(playerX, playerY, map, inMap);
                        collision = CheckForColision(playerX, playerY, map);
                        if (collision)
                        {
                            gameActive = false;
                        }

                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }

                commandIndex++;
            }

            if (!inMap)
            {
                PrintMap(map);
                Console.WriteLine("won: {0} {1}", playerY, playerX);
            }

            if (inMap)
            {
                PrintMap(map);
                Console.WriteLine("dead: {0} {1}", playerY, playerX);
            }
        }

        private static char[,] UpdateMap(int playerX, int playerY, char[,] map, bool platerInMap)
        {
            List<string> newBunnies = new List<string>();
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    if (map[row, col] == 'P')
                    {
                        map[row, col] = '.';
                    }

                    if (map[row, col] != 'B')
                    {
                        continue;
                    }

                    if (newBunnies.Contains(row.ToString() + col.ToString()))
                    {
                        continue;
                    }

                    if (col > 0)
                    {
                        map[row, col - 1] = 'B';
                        newBunnies.Add(row.ToString() + (col - 1).ToString());
                    }

                    if (col < map.GetLength(1) - 1)
                    {
                        map[row, col + 1] = 'B';
                        newBunnies.Add(row.ToString() + (col + 1).ToString());
                    }

                    if (row > 0)
                    {
                        map[row - 1, col] = 'B';
                        newBunnies.Add((row - 1).ToString() + col.ToString());
                    }

                    if (row < map.GetLength(0) - 1)
                    {
                        map[row + 1, col] = 'B';
                        newBunnies.Add((row + 1).ToString() + col.ToString());
                    }
                }
            }

            bool collision = CheckForColision(playerX, playerY, map);
            if (!collision && platerInMap)
            {
                map[playerY, playerX] = 'P';
            }

            return map;
        }

        private static bool CheckForColision(int playerX, int playerY, char[,] map)
        {
            if (map[playerY, playerX] == 'B')
            {
                return true;
            }

            return false;
        }

        private static bool PlayerInMap(int playerCol, int playerRow, int[] mapData)
        {
            int mapRow = mapData[0] - 1;
            int mapCol = mapData[1] - 1;
            if (playerRow > mapRow || playerRow < 0 || playerCol > mapCol || playerCol < 0)
            {
                return false;
            }

            return true;
        }

        private static void PrintMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
