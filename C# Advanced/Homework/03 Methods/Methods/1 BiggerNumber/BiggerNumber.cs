namespace _1_BiggerNumber
{
    using System;

    public class BiggerNumber
    {
        public static void Main()
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            int max = GetMax(firstNum, secondNum);
            Console.WriteLine(max);
        }

        private static int GetMax(int n, int m)
        {
            if (m > n)
            {
                return m;
            }
            
            return n;
        }
    }
}
