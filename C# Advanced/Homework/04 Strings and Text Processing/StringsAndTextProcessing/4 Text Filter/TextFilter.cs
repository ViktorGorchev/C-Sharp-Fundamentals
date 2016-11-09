namespace _4_Text_Filter
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class TextFilter
    {
        public static void Main()
        {
            var banList = Regex.Split(Console.ReadLine(), ", ").ToList();
            string text = Console.ReadLine();
            banList.ForEach(x =>
            {
                text = text.Replace(x, new string('*', x.Length));
            });

            Console.WriteLine(text);
        }
    }
}
