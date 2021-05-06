using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportDALLibrary;

namespace TransportFEApplication
{
    class CompleteEmployee : Employee, IComparable<Employee>

    {
        const string INITIAL_PASSWORD = "1234";
        public int CompareTo( Employee other)
        {
            return this.id.CompareTo(other.id);
            
        }
        public CompleteEmployee()
        {

        }
        public CompleteEmployee(Employee employee)
        {
            this.id = employee.id;
            this.Name = employee.Name;
            this.Password = employee.Password;
            this.VehicleNumber = employee.VehicleNumber;
            this.Phone = employee.Phone;
            this.Location = employee.Location;

        }
        public void TakeEmployeeData()
        {
            Console.WriteLine("please enter employee name");
            Name=Console.ReadLine();
            Console.WriteLine("please enter location");
            Location = Console.ReadLine();
            Console.WriteLine("please enter phone number");
            Phone = Console.ReadLine();
            Password = INITIAL_PASSWORD;

        }
        public override string ToString()
        {
            string maskedPassword = GetMaskedPassword(Password);
            return "id:" + id + "name:" + Name + "location:" + Location + "Password:" + Password;
        }
        private string GetMaskedPassword(string password)
        {
            string result = password.Substring(0, 2);
            for(int i=2;i<password.Length;i++)
            {
                result += "+";

            }
            return result;
        }
    }
}
