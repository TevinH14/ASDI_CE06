using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TevinHamilton_CE07
{
    class Manger:Salaried
    {
        public Manger(string name, string address , decimal salary):base(name, address,salary)
        {
            Name = name;
            Address = address;
            Salary = salary;
            Bonus = 0;
            Console.WriteLine("Manger have been created");
        }
        public override decimal CalculatePay()
        {
            decimal total = Salary + Bonus;
            return total;
        }
        public override string ToString()
        {
            return $"Name: {Name}| Address: {Address}| Yearly pay: {CalculatePay().ToString("c")}";
        }
        public override string StringToSave()
        {
            return $"{Name},{Address},{Salary.ToString()},";
        }


    }
}
