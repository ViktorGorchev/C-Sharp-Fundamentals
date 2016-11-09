namespace Methods
{
    using System;

    public class MethodsMain
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("Triangle area = {0}", Calculations.CalculateTriangleArea(3, 4, 5));
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }

            Console.WriteLine("The name of the digit is: {0}", Formatting.ConvertNumberToNumberAsWord(5));
            try
            {
                Console.WriteLine("The max element of the array is {0}", Calculations.FindMax(5, -1, 3, 2, 14, 2, 3));
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }

            Console.WriteLine(Formatting.FormatNumber(1.3, "f"));
            Console.WriteLine(Formatting.FormatNumber(0.75, "%"));
            Console.WriteLine(Formatting.FormatNumber(2.30, "r"));

            Console.WriteLine("The distance between the two pints is {0}", Calculations.CalculateDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + Calculations.IsHorizontalLine(3, 3));
            Console.WriteLine("Vertical? " + Calculations.IsVerticalLine(-1, 2.5));

            Student peter = new Student("Peter", "Ivanov");
            peter.AdditionalInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student("Stella", "Markova");
            stella.AdditionalInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            try
            {
                Console.WriteLine(
                    "{0} older than {1} -> {2}",
                    peter.FirstName,
                    stella.FirstName,
                    peter.IsOlderThan(stella));
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }
    }
}
