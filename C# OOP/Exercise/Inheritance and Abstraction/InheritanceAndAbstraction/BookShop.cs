using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndAbstraction
{
    class BookShop
    {
        static void Main()
        {
            Book book = new Book("Pod Igoto", "Ivan Vazov", 15.90m);
            Console.WriteLine(book);
            Console.WriteLine();

            GoldenEditionBook goldenBook = new GoldenEditionBook("Tutun", "Dimitur Dimov", 22.90m);
            Console.WriteLine(goldenBook);
        }
    }
}
