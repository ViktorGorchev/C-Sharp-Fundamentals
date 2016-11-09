namespace _2_TheSieveOfEratosthenes
{
    using System;
    using System.Collections.Generic;

    public class TheSieveOfEratosthenes 
    {
        public static void Main()
        {
            int range = int.Parse(Console.ReadLine());

            if (range == 2)
            {
                Console.WriteLine(range);
                Environment.Exit(0);
            }

            List<int> primes = new List<int>();
            for (int i = 2; i <= range; i++)
            {
                primes.Add(i);
            }

            for (int stepIndex = 0; stepIndex < primes.Count; stepIndex++)
            {
                int step = primes[stepIndex];
                bool allPrimesNotChecked = false;
                for (int i = stepIndex; i < primes.Count; i++)
                {
                    i += step;
                    if (i >= primes.Count)
                    {
                        continue;
                    }

                    if (primes[i] != 0)
                    {
                        primes[i] = 0;
                        allPrimesNotChecked = true;
                    }

                    i--;
                }

                if (!allPrimesNotChecked)
                {
                    break;
                }
            }

            ////int primesCount = primes.Count;
            for (int i = 0; i < primes.Count; i++)
            {
                if (primes[i] == 0)
                {
                    primes.RemoveAt(i);
                }
            }

            Console.WriteLine(string.Join(", ", primes));
        }
    }
}
