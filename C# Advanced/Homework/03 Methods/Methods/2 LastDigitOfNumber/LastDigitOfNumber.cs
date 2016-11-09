namespace _2_LastDigitOfNumber
{
    using System;

    public class LastDigitOfNumber
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            string lastDigit = GetLastDigitAsWord(num);
            Console.WriteLine(lastDigit);
        }

        private static string GetLastDigitAsWord(int number)
        {
            int lastDigit = number % 10;
            string inWord = string.Empty;
            switch (lastDigit)
            {
                case 0:
                    inWord = "zero";
                    break;
                case 1:
                    inWord = "one";
                    break;
                case 2:
                    inWord = "two";
                    break;
                case 3:
                    inWord = "three";
                    break;
                case 4:
                    inWord = "four";
                    break;
                case 5:
                    inWord = "five";
                    break;
                case 6:
                    inWord = "six";
                    break;
                case 7:
                    inWord = "seven";
                    break;
                case 8:
                    inWord = "eight";
                    break;
                case 9:
                    inWord = "nine";
                    break;
            }

            return inWord;
        }
    }
}