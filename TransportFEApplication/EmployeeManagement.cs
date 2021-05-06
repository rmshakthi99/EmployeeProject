using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using TransportBLLibrary;
using TransportDALLibrary;




namespace TransportFEApplication
{
    class EmployeeManagement
    {
        public IRepo<Employee> _repo;
        public EmployeeManagement()
        {

        }
        public EmployeeManagement(IRepo<Employee> repo)
        {
            _repo = repo;

        }
        public void CreateEmployee()
        {
            CompleteEmployee employee = new CompleteEmployee();
            employee.TakeEmployeeData();
            try
            {
                if (_repo.Add(employee))
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
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = _repo.GetAll().ToList();
            return employees;
        }
        public void PrintAllEmployees()
        {
            var employees = GetAllEmployees();
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
        public List<CompleteEmployee> SortEmployees()
        {
            List<CompleteEmployee> employees = new List<CompleteEmployee>();
            foreach(var item in GetAllEmployees())
            {
                employees.Add(new CompleteEmployee(item));

            }
           
            return employees;
        }
        public void PrintEmployeesSortedById()
        {
            var employees = SortEmployees();
            employees.Sort();
            foreach (Employee employee in employees)

            {
                Console.WriteLine(employee);
            }
        }
        public void ResetPassword()
        {
            Console.WriteLine("please enter employee id ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("please enter old password ");
            string Password = Console.ReadLine();
            Employee employee = GetAllEmployees().Find(e => e.id == id && e.Password == Password);
            try
            {
                if (employee != null)
                {
                    Console.WriteLine("please enter new password");
                    var newPassword = Console.ReadLine();
                    Console.WriteLine("please retype password");
                    var repeatPassword = Console.ReadLine();
                    if (newPassword == repeatPassword)
                    {
                        employee.Password = newPassword;
                        if (_repo.Update(employee))
                            Console.WriteLine("password updated");
                        else
                            Console.WriteLine("please try again");
                    }
                    else
                        Console.WriteLine("password mismatch");
                }
                else
                {
                    Console.WriteLine("incorrect username or password");

                }
            }    

            catch (Exception e)
            {
                Console.WriteLine("couldn't update password at this moment");
                Console.WriteLine("e.Message");

            }
        }
    }
}



        
    

       






    
