namespace _1_Reverse_String
{
    using System;
    using System.Linq;

    public class ReverseString
    {
        public static void Main()
        {
            Console.WriteLine(string.Join(string.Empty, Console.ReadLine().Reverse().ToArray()));
        }
    }
}
