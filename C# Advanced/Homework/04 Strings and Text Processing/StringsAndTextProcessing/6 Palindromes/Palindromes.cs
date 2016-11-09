namespace _6_Palindromes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Palindromes
    {
        public static void Main()
        {
            var text = Regex.Split(Console.ReadLine(), @"\W+").ToList();
            var palindromes = new SortedSet<string>();
            text.ForEach(word =>
            {
                if (IsPalidrome(word))
                {
                    palindromes.Add(word);
                }
            });

            Console.WriteLine(string.Join(", ", palindromes));
        }

        private static bool IsPalidrome(string word)
        {
            int wordLen = word.Length;
            for (int i = 0; i < wordLen; i++)
            {
                if (!word[i].Equals(word[wordLen - 1 - i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
