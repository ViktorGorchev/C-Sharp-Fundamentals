namespace _02_LineNumbers
{
    using System;
    using System.IO;

    public class LineNumbers
    {
        private static void Main()
        {
            using (var reader = new StreamReader("../../LineNumbers.cs"))
            {
                using (var writer = new StreamWriter("../../GenFile.txt"))
                {
                    int rowCounter = 1;
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        writer.WriteLine("{0,3}. {1}", rowCounter, line);
                        rowCounter++;
                        line = reader.ReadLine();
                    }
                }
            }

            Console.WriteLine("File done");
        }
    }
}
