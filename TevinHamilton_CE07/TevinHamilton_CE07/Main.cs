using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TevinHamilton_CE07
{
    class Main
    {
        List<Employee> _employees = new List<Employee>();
        private string _directory = @"..\..\output\";
        private string _fileName = @"Employees.txt";
        private Menu _menu;
        public Main()
        {
            _menu = new Menu("Add Employee","Remove Employee","Display Payroll","Save","Json Save","Exit");
            _menu.Title = "Employee Tracker";

            Directory.CreateDirectory(_directory);
            if (!File.Exists(_directory + _fileName))
            {
                File.Create(_directory + _fileName);
            }
            else
            {
                Console.WriteLine("File exist");
                Load();
            }
            Display();
        }
        private void Display()
        {
            Console.Clear();
            _menu.Display();
            SelectOption();
        }
        private void SelectOption()
        {
            switch (Utility.IntValidate("\nPlease make a selection"))
            {
                case 1:
                    AddEmployee();
                    break;
                case 2:
                    RemoveEmployee();
                    break;
                case 3:
                    DisplayPayRoll();
                    break;
                case 4:
                    save();
                    break;
                case 5:
                    SaveToJson();
                    break;
                case 6:
                    Exit();
                    break;
                
                default:
                    SelectOption();
                    break;
            }
        }
        private void Exit()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Exit\r\n\r\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.WriteLine("GOODBYE!!!!");
            Environment.Exit(0);
            Console.ReadKey();
        }
        private void AddEmployee()
        {
            switch (Utility.IntValidate("\nAdd Employee to Hourly or Salary\r\n[1] - ADD HOURLY EMPLOYEE\r\n[2] - ADD SALARY EMPLOYEE"))
            {
                case 1:
                    AddHourlyEmployee();
                    break;
                case 2:
                    AddSalaryEmployee();
                    break;

                default:
                    break;
            }
        }
        private void RemoveEmployee()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Remove Employee");
            Console.ForegroundColor = ConsoleColor.Gray;
            int counter = 1;
            _employees.Sort();
            foreach (var item in _employees)
            {
                Console.WriteLine($"[{counter}] {item.Name}");
                counter++;
            }
            int indexChoices = Utility.IntValidate("pick the employee you would like to remove");
            _employees.RemoveAt(indexChoices - 1);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Remove Employee\r\n\r\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Updated list of employees\r\n");
            counter = 1;
            _employees.Sort();
            foreach (var item in _employees)
            {
                Console.WriteLine($"[{counter}] {item.Name}");
                counter++;
            }
            Console.WriteLine("Press any key to return to menu!");
            Console.ReadKey();
            Display();
        }
        private void DisplayPayRoll()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Pay Roll Display\r\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            int counter = 1;
            _employees.Sort();
            foreach (var item in _employees)
            {
                Console.WriteLine($"[{counter}] {item.ToString()}");
                counter++;
            }
            Console.WriteLine("press any key to return to menu");
            Console.ReadKey();
            Display();
        }
        private void AddHourlyEmployee()
        {
            switch (Utility.IntValidate("\nAdd Employee to PartTime or FullTime\r\n[1] - ADD PART EMPLOYEE.\r\n[2] - ADD FULLTIME EMPLOYEE"))
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Add PartTime Employee\r\n\r\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    string pTName = Utility.StringValidate("what's employee name?");
                    string pTAddress = Utility.StringValidate("What's the employee address?");
                    decimal pTPayPerHour = Utility.DecimalValidate("enter the amount the employee will be getting paid hourly");
                    decimal pTHoursPerWeek = Utility.DecimalValidate("enter the amount of hours the employ will have");
                    PartTime partTime = new PartTime(pTName, pTAddress, pTPayPerHour, pTHoursPerWeek);
                    _employees.Add(partTime);
                    Console.WriteLine("\r\npress any key to return to menu");
                    Console.ReadKey();
                    Display();

                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Add FullTime Employee\r\n\r\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    string fTName = Utility.StringValidate("what's employee name?");
                    string fTAddress = Utility.StringValidate("What's the employee address?");
                    decimal fTPayPerHour = Utility.DecimalValidate("enter the amount the employee will be getting paid hourly");
                    FullTime fullTime = new FullTime(fTName, fTAddress, fTPayPerHour, 40);
                    _employees.Add(fullTime);
                    Console.WriteLine("\r\npress any key to return to menu");
                    Console.ReadKey();
                    Display();
                    break;

                default:
                    break;
            }
        }
        private void AddSalaryEmployee()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Add Manger Employee\r\n\r\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            string name = Utility.StringValidate("enter the manger name");
            string address = Utility.StringValidate("enter the manger address");
            decimal salary = Utility.DecimalValidate("enter the amount the manger will earn for a year");
            Manger manger = new Manger(name,address,salary);
            _employees.Add(manger);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
            //
            Console.WriteLine("[1] Add Bonus.\r\n[2] return to menu.");
            int userChoice = Utility.IntValidate("do you want to add a bonus to the manger salary?");
            if (userChoice == 1) { decimal bonus = Utility.DecimalValidate("How much is the bonus?"); manger.Bonus = bonus; Console.WriteLine("\r\npress enter to return to the menu"); Console.Clear(); Display();}
            else { Console.WriteLine("Press any key to return to the menu"); Console.ReadKey(); Display(); }
        }
        private void Load()
        {
            using (StreamReader inputStream = new StreamReader(_directory + _fileName))
            {
                string line;
                string[] textInfo;
                while ((line = inputStream.ReadLine()) != null)
                {
                    textInfo = line.Split(',');
                    decimal hours;
                    decimal pay;
                    decimal.TryParse(textInfo[2], out pay);
                    decimal.TryParse(textInfo[3], out hours);
                    FullTime employee = new FullTime(textInfo[0],textInfo[1],pay,hours);
                    _employees.Add(employee);
                }
            }
            Console.WriteLine("Employees have been loaded");
            foreach (var item in _employees)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("\r\nPress any key to continue");
            Console.ReadKey();
            Display();
        }
        private void save()
        {
            using (StreamWriter outputStream = new StreamWriter(_directory + _fileName))
            {
                foreach (Employee e in _employees)
                {
                    outputStream.WriteLine(e.StringToSave());
                }
            }
            Display();
        }
        private void SaveToJson()
        {
            Console.Clear();
            Console.WriteLine("saving Employees to Json");
            using (StreamWriter sw = new StreamWriter(_directory + "Employees.json"))
            {
                sw.WriteLine("[");
                int index = 0;
                foreach (Employee e in _employees)
                {
                   
                    sw.WriteLine("{");
                    sw.WriteLine($"\"name\": \"{e.Name}\",");
                    sw.WriteLine($"\"Address\": \"{e.Address}\",");                   
                    sw.WriteLine($"\"HoursPerWeek\": \"{e.CalculatePay()}\"");
                    if (index == _employees.Count - 1)
                    {
                        sw.WriteLine("}");
                    }
                    else
                    {
                        sw.WriteLine("},");
                    }
                    index++;
                }
                sw.WriteLine("]");
            }
            Console.WriteLine("Press any key to contiune");
            Console.ReadKey();
            Display();
        }
    }
   
}
