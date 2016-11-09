namespace Exceptions_Homework
{
    using System;
    
    public class PrimeChecker
    {
        public bool CheckPrime(int number)
        {
            bool isPrime = true;
            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    isPrime = false;
                }
            }

            return isPrime;
        }
    }
}
