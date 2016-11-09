using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace TestCapitalism
{
    public class Ceo : Employes
    {
      
       public Ceo(string companyName, string firstName, string lastName, decimal salary) 
            : base(companyName, firstName, lastName, salary)
       {
           
       }
        
    }
}