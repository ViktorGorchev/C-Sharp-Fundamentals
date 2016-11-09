using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Number_as_Words
{
    class Program
    {
        static void Main()
        {
            do
            {
                
            
            try
            {
                int num = int.Parse(Console.ReadLine());
                if (num < 0 || num > 999)
                {
                    Console.WriteLine("Number must be from 0 to 999!");
                }

                string[] ones = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
                string[] elevenToNinteen = { "", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen", "", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};
                string[] tens = { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety", "", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
               
                int hundreds = 0;
                int tenToNinety = 0;
                int oneToNine = 0;
                
                if (num == 0)                               //0
                {
                    Console.WriteLine("Zero");
                }
                else if (num < 10)                          //1-9
                {
                    Console.WriteLine(ones[num + 10]);
                }              
                else if (num > 10 && num < 20)              //11-19
                {
                    num %= 10;
                    Console.WriteLine(elevenToNinteen[num + 10]);
                }
                else if (num == 10 || (num > 19 && num < 100))             //10, 20-99
                {
                    oneToNine = num % 10;
                    tenToNinety = (num / 10) % 10;
                    if (oneToNine == 0)
                    {
                        Console.WriteLine(tens[tenToNinety + 10]);
                    }
                    else
                    {
                        Console.WriteLine(tens[tenToNinety + 10] + " " + ones[oneToNine]);
                    }
                }
                else if (num > 99 && num < 1000)                //100-999
                {
                    oneToNine = num % 10;
                    tenToNinety = (num / 10) % 10;
                    hundreds = (num / 100) % 10;
                    if (oneToNine == 0 && tenToNinety == 0)     //100, 200 , 300 .....
                    {
                        Console.WriteLine(ones[hundreds + 10] + " hundred");
                    }
                    else if (tenToNinety == 0)                  //101,102...203
                    {
                        Console.WriteLine(ones[hundreds + 10] + " hundred and " + ones[oneToNine]);
                    }
                    else if (oneToNine == 0)                    //110, 120 .. 230....
                    {
                        Console.WriteLine(ones[hundreds + 10] + " hundred and " + tens[tenToNinety]);
                    }
                    else if (tenToNinety == 1 && oneToNine != 0)    //111 - 119, 112...213...
                    {
                        Console.WriteLine(ones[hundreds + 10] + " hundred and " + elevenToNinteen[oneToNine]);
                    }
                    else                                            //121,122....
                    {
                        Console.WriteLine(ones[hundreds + 10] + " hundred and " + tens[tenToNinety] + " " + ones[oneToNine]);
                    }
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("Not a number!");
            }

        } while (true);

        }

        private static string UppercaseFirst(string p)
        {
            throw new NotImplementedException();
        }
    }
}
