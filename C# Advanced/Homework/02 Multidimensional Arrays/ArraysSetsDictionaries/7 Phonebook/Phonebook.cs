namespace _7_Phonebook
{
    using System;
    using System.Collections.Generic;

    public class Phonebook
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            var book = new Dictionary<string, List<string>>();

            while (!input.Equals("search"))
            {
                string[] data = input.Split('-');
                if (!book.ContainsKey(data[0]))
                {
                    book[data[0]] = new List<string>();
                }

                book[data[0]].Add(data[1]);
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (!input.Equals(string.Empty))
            {
                if (book.ContainsKey(input))
                {
                    Console.WriteLine("{0} -> {1}", input, string.Join(", ", book[input]));
                }
                else
                {
                    Console.WriteLine("Contact {0} does not exist.", input);
                }

                input = Console.ReadLine();
            }
        }
    }
}
