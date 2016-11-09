using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asscii_table
{
    class Program
    {
        static void Main()
        {
            for (int i = 0; i <= 255; i++)

            {

                System.Console.WriteLine("{0} = {1}", i, (char)i);

            }

            //Console.OutputEncoding = Encoding.ASCII;


            //char a = '\0';

            //for (int i = 0; i < 255; i++)
            //{
            //    int b = (int)a + i;

            //    Console.Write(Convert.ToChar(b));
            //}
        }
    }
}
