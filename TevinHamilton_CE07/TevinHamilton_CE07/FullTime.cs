using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TevinHamilton_CE07
{
    class FullTime:Hourly
    {
        public FullTime(string name, string address, decimal payPerHour, decimal hoursPerWeek) : base(name, address,payPerHour,hoursPerWeek)
        {
            Name = name;
            Address = address;
            PayPerHour = payPerHour;
            HoursPerWeek = hoursPerWeek;
            Console.WriteLine("fulltime employee created!");
        }
        public override decimal CalculatePay()
        {
            decimal total = PayPerHour * HoursPerWeek * 52;
            return total;
        }
        public override string ToString()
        {
            return $"Name: {Name}| Address: {Address}| Yearly pay: {CalculatePay().ToString("c")}";
        }
        public override string StringToSave()
        {
            return $"{Name},{Address},{PayPerHour.ToString()},{HoursPerWeek.ToString()}";
        }
    }
}
