namespace _2_StringLength
{
    using System;

    public class StringLength
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            try
            {
                text = text.Substring(0, 20);
            }
            catch (ArgumentException)
            {
                int padding = 20 - text.Length;
                text += new string('*', padding);
            }

            Console.WriteLine(text);
        }
    }
}
