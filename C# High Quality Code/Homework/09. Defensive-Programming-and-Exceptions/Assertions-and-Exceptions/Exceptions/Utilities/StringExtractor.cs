namespace Exceptions_Homework
{
    using System;
    using System.Text;

    public class StringExtractor
    {
        public string ExtractEnding(string str, int count)
        {
            if (count > str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Count cannot be more than the length of the string!");
            }

            StringBuilder result = new StringBuilder();
            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }
    }
}
