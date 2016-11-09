using System;

class Program
{
    static void Main()
    {
        String n = Console.ReadLine();
        int numLenght = n.Length;
        int binariInNum = 0;
        double singleNum = 0;
        double ziroOrOne = 0;
        double deci = 0;

        if (Int32.TryParse(n, out binariInNum))
        {
            for (int i = 0; i < numLenght; i++)
            {
                binariInNum = binariInNum % 10;
                singleNum = binariInNum % 10;
                ziroOrOne = singleNum * (Math.Pow(2, i));
                deci += ziroOrOne; 
            }
            Console.WriteLine(deci);
        }
       
    }
}
