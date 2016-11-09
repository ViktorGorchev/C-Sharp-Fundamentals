using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Square_Root
{
    class SquareRoot
    {
        static void Main()
        {
            string numberInput = Console.ReadLine();
            int number = 0;
            try
            {
                number = int.Parse(numberInput);
                if (number < 0)
                {
                    Console.Error.WriteLine("Invalid number");
                }
                else
                {
                    Console.WriteLine(Math.Sqrt(number));
                }               
            }           
            catch (FormatException)
            {
                Console.Error.WriteLine("Invalid number");             
            }
            catch (OverflowException)
            {
                Console.Error.WriteLine("Invalid number");                
            }           
            finally
            {
                Console.WriteLine("Good bye"); 
            }     
        }        
    }
}
