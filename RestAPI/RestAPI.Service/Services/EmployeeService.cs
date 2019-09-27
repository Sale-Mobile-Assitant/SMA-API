using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestAPI.Data;

namespace RestAPI.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private SaleMobileAssistantEntities DB = new SaleMobileAssistantEntities();
        public int Add(Employee _employee)
        {
            DB.Employees.Add(_employee);
            return DB.SaveChanges();
        }

        public int Delete(string id)
        {
            var result = DB.Employees.Where(p => p.EmplID == id).FirstOrDefault();
            if (result == null)
            {
                return -1;
            }
            DB.Entry(result).State = System.Data.Entity.EntityState.Deleted;
            return DB.SaveChanges();
        }

        public Employee GetEmployee(string id)
        {
            return DB.Employees.Where(p => p.EmplID == id).FirstOrDefault();
        }

        public List<Employee> GetEmployees()
        {
            return DB.Employees.ToList();
        }

        public int Put(Employee _employee)
        {
            var exitingEmployee = DB.Employees.Where(p => p.EmplID == _employee.EmplID).FirstOrDefault();
            if (exitingEmployee != null)
            {
                exitingEmployee.CompID = _employee.CompID;
                exitingEmployee.ETypeID = _employee.ETypeID;
                exitingEmployee.EmplName = _employee.EmplName;
                exitingEmployee.Address1 = _employee.Address1;
                exitingEmployee.Address2 = _employee.Address2;
                exitingEmployee.Address3 = _employee.Address3;
                exitingEmployee.PhoneNum = _employee.PhoneNum;
                exitingEmployee.DateIn = _employee.DateIn;
                exitingEmployee.DateOut = _employee.DateOut;

                return DB.SaveChanges();
            }
            return -1;
        }
    }


}