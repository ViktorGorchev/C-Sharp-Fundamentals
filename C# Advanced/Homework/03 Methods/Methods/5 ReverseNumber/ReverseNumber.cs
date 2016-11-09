namespace _5_ReverseNumber
{
    using System;
    using System.Globalization;
    using System.Linq;

    public class ReverseNumber
    {
        public static void Main()
        {
            double reversed = GetReversedNumber(double.Parse(Console.ReadLine()));
            Console.WriteLine(reversed);
        }

        private static double GetReversedNumber(double num)
        {
            string revNum = string.Join(string.Empty, num.ToString(CultureInfo.InvariantCulture).Reverse().ToArray());
            return double.Parse(revNum);
        }
    }
}
