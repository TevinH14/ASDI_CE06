using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TevinHamilton_CE07
{
    class Employee: IComparable<Employee>
    {
        public string Name { get; set; }
        public string Address { get; set; }
       

        public Employee(string name, string address)
        {

        }
        public virtual decimal CalculatePay()
        {
            return 0;
        }
        public virtual string ToString()
        {
            return "";
        }

        public int CompareTo(Employee other)
        {
            return Name.CompareTo(other.Name);
        }
        public virtual string StringToSave()
        {
            return $"";
        }

    }
}
