using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportBLLibrary;
using TransportDALLibrary;


namespace TransportFEApplication
{
    class EmployeeLogin
    {
        public IUserLogin<Employee> _login;
        public EmployeeLogin()
        {

        }
        public EmployeeLogin(IUserLogin<Employee> login)
        {                    
            _login = login;
        }
        public void UserLogin()
        {
            Console.WriteLine("please enter the employee id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("please enter password");
            string password = Console.ReadLine();
            Employee employee = new Employee();
            employee.id = id;
            employee.Password = password;
            try
            {
                if (_login.Login(employee))
                    Console.WriteLine("welcome");
                else
                    Console.WriteLine("Incoorect id or password");
            }
            catch (Exception e)
            {
                Console.WriteLine("login exception");
                Console.WriteLine(e.Message);
            }
        }
        public void RegisterEmployee()
        {
            CompleteEmployee employee = new CompleteEmployee();
            employee.TakeEmployeeData();
            try
            {
                if (_login.Add(employee))
                    Console.WriteLine("employee created");
                else
                    Console.WriteLine("sorry could not complete creating");
            }
            catch (Exception e)
            {
                Console.WriteLine("could not add employee");
                Console.WriteLine("e.Message");

            }
        }
    }
}

            
        
    

