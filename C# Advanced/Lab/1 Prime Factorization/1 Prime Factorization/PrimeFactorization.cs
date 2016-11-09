namespace _1_Prime_Factorization
{
    using System;
    using System.Collections.Generic;
    
    public class PrimeFactorization
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            List<int> primeFactorization = new List<int>();
           
            if (IsPrime(number) || number == 1)
            {
                Console.WriteLine(number);
                Environment.Exit(0);
            }

            int devidor = 2;
            int devidedNumber = number;
            while (true)
            {
                bool devidorIsNotPrime = !IsPrime(devidor);
                bool numberNotDevidedToHoleNumber = devidedNumber % devidor != 0; 
                
                if (devidorIsNotPrime || numberNotDevidedToHoleNumber)
                {
                    devidor++;
                    continue;
                }

                primeFactorization.Add(devidor);
                int tempNumber = devidedNumber / devidor;
                devidedNumber = tempNumber;
                if (IsPrime(tempNumber))
                {
                    primeFactorization.Add(tempNumber);
                    break;
                }
            }
            
            Console.WriteLine("{0} = {1}", number, string.Join(" * ", primeFactorization));
        }
        
        private static bool IsPrime(int candidate)
        {
            if ((candidate & 1) == 0)
            {
                if (candidate == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
  
            for (int i = 3; (i * i) <= candidate; i += 2)
            {
                if ((candidate % i) == 0)
                {
                    return false;
                }
            }

            return candidate != 1;
        }
    }
}