using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TevinHamilton_CE07
{
    class Hourly:Employee
    {
        public decimal PayPerHour { get; set; }
        public decimal HoursPerWeek { get; set; }

        public Hourly(string name , string address, decimal payPerHour, decimal hoursPerWeek):base(name,address)
        {

        }
        public override decimal CalculatePay()
        {
            return base.CalculatePay();
        }
    }
}
