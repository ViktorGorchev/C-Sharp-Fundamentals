namespace _5_Unicode_Characters
{
    using System;
    using System.Linq;

    public class UnicodeCharacters
    {
        public static void Main()
        {
            var chars = Console.ReadLine().ToList();
            chars.ForEach(x =>
            {
                Console.Write("\\u" + ((int)x).ToString("X4"));
            });
        }
    }
}
