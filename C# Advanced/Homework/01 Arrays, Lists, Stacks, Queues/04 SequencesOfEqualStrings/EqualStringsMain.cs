namespace _04_SequencesOfEqualStrings
{
    using System;

    internal class EqualStringsMain
    {
        private static void Main()
        {
            string[] inputString = Console.ReadLine().Split(' ');
            string temp = null;
            for (int i = 0; i < inputString.Length; i++)
            {
                if (i == 0)
                {
                    temp = inputString[0];
                    Console.Write(inputString[0]);
                }
                else if (inputString[i] == temp)
                {
                    Console.Write(" " + inputString[i]);
                }
                else
                {
                    Console.WriteLine();
                    temp = inputString[i];
                    Console.Write(inputString[i]);
                }
            }

            Console.WriteLine();
        }
    }
}