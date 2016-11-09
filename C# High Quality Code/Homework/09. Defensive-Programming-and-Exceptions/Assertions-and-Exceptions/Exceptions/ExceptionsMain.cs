namespace Exceptions_Homework
{
    using System;
    using System.Collections.Generic;
    
    public class ExceptionsMain
    {
        public static void Main()
        {
            ArraySubsequencer subsequencer = new ArraySubsequencer();
            StringExtractor extractor = new StringExtractor();
            PrimeChecker primeChecker = new PrimeChecker();

            var substr = subsequencer.Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = subsequencer.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(string.Join(" ", subarr));

            var allarr = subsequencer.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(string.Join(" ", allarr));

            var emptyarr = subsequencer.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(string.Join(" ", emptyarr));

            Console.WriteLine(extractor.ExtractEnding("I love C#", 2));
            Console.WriteLine(extractor.ExtractEnding("Nakov", 4));
            Console.WriteLine(extractor.ExtractEnding("beer", 4));
            Console.WriteLine(extractor.ExtractEnding("Hi", 2)); 

            int number1 = 23;
            Console.WriteLine(primeChecker.CheckPrime(number1) ? "{0} is prime." : "{0} is not prime", number1);

            int number2 = 33;
            Console.WriteLine(primeChecker.CheckPrime(number2) ? "{0} is prime." : "{0} is not prime", number2);

            List<Exam> peterExams = new List<Exam>()
            {
                new SimpleMathExam(2),
                new CSharpExam(55),
                new CSharpExam(100),
                new SimpleMathExam(1),
                new CSharpExam(0),
            };
            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
    }
}
