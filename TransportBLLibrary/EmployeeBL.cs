using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using TransportDALLibrary;


namespace TransportBLLibrary
{
    public class EmployeeBL : IRepo<Employee>,IUserLogin<Employee>
    {
        EmployeeDAL dal;
        public EmployeeBL()
        {
            dal = new EmployeeDAL();

        }
       

        public bool Add(Employee t)
        {
            try
            {
                return dal.AddEmployee(t);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        

        public ICollection<Employee> GetAll()
        {
            List<Employee> employees;
            try
            {
                employees = dal.SelectAllEmployees().ToList();
                return employees;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool Login(Employee t)
        {
            bool result = false;
            try
            {
                List<Employee> employees = GetAll().ToList();
                Employee employee = employees.Find(e => e.id == t.id && e.Password == t.Password);
                if (employee != null)
                    result = true;
            }
            catch(Exception exception)
            {
                throw exception;
            }
            return result;
        }

        public bool Update(Employee t)
        {
            try
            {
                return dal.UpdatePassword(t);
            }
            catch(Exception exception)
            {
                throw exception;
            }
            
        }
    }
}
