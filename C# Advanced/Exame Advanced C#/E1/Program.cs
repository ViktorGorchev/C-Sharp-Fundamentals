namespace E1
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            List<string> data = new List<string>() { "stone", "gold", "wood", "food" };
            var feeld = ConvertCToSpacesRegex(Console.ReadLine()).Split();
            int commandsNumber = int.Parse(Console.ReadLine().Trim());

            int points = 0;
            int start = 0;
            for (int i = 0; i < commandsNumber; i++)
            {
                var command = ConvertCToSpacesRegex(Console.ReadLine()).Split();
                start = int.Parse(command[0]);
                int step = int.Parse(command[1]);

                int count = 0;
                int tempPoints = 0;
                List<string> stepedFeelds = new List<string>();
                while (true)
                {
                    
                    if (count == 0)
                    {
                        var startResource = feeld[start].Split('_');
                        if (data.Contains(startResource[0]))
                        {
                            if (startResource.Length < 2)
                            {
                                tempPoints += 1;
                            }
                            else
                            {
                                tempPoints += int.Parse(startResource[1]);
                            }

                            stepedFeelds.Add(feeld[start]);
                            count++; 
                        }
                    }
                    
                    int index = RotateIndexLeftOrRight(start, step, feeld.Length);
                    start = index;
                    var resources = feeld[index].Split('_');
                    
                    if (!data.Contains(resources[0]))
                    {
                        continue;
                    }

                    if (stepedFeelds.Contains(feeld[index]))
                    {
                        break;
                    }

                    if (resources.Length < 2) 
                    {
                        tempPoints += 1;
                    }
                    else
                    {
                        tempPoints += int.Parse(resources[1]);
                    }

                    stepedFeelds.Add(feeld[index]);
                }
                
                if (tempPoints > points)
                {
                    points = tempPoints;
                }
                
                tempPoints = 0;
                stepedFeelds = null;
            }

            Console.WriteLine(points);
        }

        private static int RotateIndexLeftOrRight(int currentIndex, int offset, int arrayCount)
        {
            int index = currentIndex;

            if (offset < 0)
            {               
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

        private static string ConvertCToSpacesRegex(string value)
        {
            value = Regex.Replace(value, @"\s+", " ");
            return value;
        }
    }
}
