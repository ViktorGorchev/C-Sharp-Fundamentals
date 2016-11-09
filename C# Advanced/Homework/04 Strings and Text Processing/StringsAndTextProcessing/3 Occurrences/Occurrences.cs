namespace _3_Occurrences
{
    using System;

    public class Occurrences
    {
        public static void Main()
        {
            string text = Console.ReadLine().ToLower();
            string key = Console.ReadLine();

            int occurrences = 0;
            int index = text.IndexOf(key);
            while (index != -1)
            {
                occurrences++;
                index = text.IndexOf(key, index + 1);
            }

            Console.WriteLine(occurrences);
        }
    }
}
