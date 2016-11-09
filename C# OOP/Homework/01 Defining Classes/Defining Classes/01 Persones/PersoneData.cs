using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Persones
{
   
    class PersoneData
    {
        static void Main()
        {
            Persone nameAgeEmail = new Persone();
            nameAgeEmail.Name = "Sasho";
            nameAgeEmail.Age = 25;
            nameAgeEmail.Email = "sasho@gmail.com";
            Console.WriteLine(nameAgeEmail);

            Persone nameAge = new Persone();
            nameAge.Name = "Ivan";
            nameAge.Age = 30;
            Console.WriteLine(nameAge);
            
        }
    }
}
