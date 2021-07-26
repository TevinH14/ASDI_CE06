using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TevinHamilton_CE07
{
    class Salaried:Employee
    {
        public decimal Salary { get; set; }
        public decimal Bonus { get; set; }
        public Salaried(string name , string address,decimal salary):base(name,address)
        {

        }

        
    }
}
