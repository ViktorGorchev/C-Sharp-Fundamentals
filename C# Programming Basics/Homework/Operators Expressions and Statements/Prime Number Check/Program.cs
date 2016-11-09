using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime_Number_Check
{
    class Program
    {
        static void Main()
        {

            do
            {
                int number = int.Parse(Console.ReadLine());
                int counter = 0;
                
                if (number <= 1)
                {
                    counter++;
                }
                
                for (int i = 2; i < number; i++)
			    {
                
                    if ((number % i) == 0)
                    {
                        counter++;
                    }
			    }
                bool prime = counter == 0;
                Console.WriteLine(prime);
            } while (true);
            











            //for (int i = 1; i <= number; i++)
            //{
            //    if (number == 1)
            //    {
            //        Console.WriteLine("false");
            //        return;
            //    }
            //    else if ((i != 1 || i != number) && (number % i == 0))
            //    {
            //        Console.WriteLine("false");
            //        return;
            //    }
            //}
            //Console.WriteLine("true");  
                       
        }
    }
}
