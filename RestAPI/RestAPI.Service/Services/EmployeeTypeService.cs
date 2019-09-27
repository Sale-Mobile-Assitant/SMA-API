using RestAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Service.Services
{
    public class EmployeeTypeService : IEmployeeTypeService
    {
        private SaleMobileAssistantEntities DB = new SaleMobileAssistantEntities();
        public int Add(EmployeeType _employee)
        {
            DB.EmployeeTypes.Add(_employee);
            return DB.SaveChanges();
        }

        public int Delete(string id)
        {
            var result = DB.EmployeeTypes.Where(p => p.ETypeID == id).FirstOrDefault();
            if (result == null)
            {
                return -1;
            }
            DB.Entry(result).State = System.Data.Entity.EntityState.Deleted;
            return DB.SaveChanges();
        }

        public EmployeeType GetEmployee(string id)
        {
            return DB.EmployeeTypes.Where(p => p.ETypeID == id).FirstOrDefault();
        }

        public List<EmployeeType> GetEmployees()
        {
            return DB.EmployeeTypes.ToList();
        }

        public int Put(EmployeeType _employee)
        {
            var exitingEmployee = DB.EmployeeTypes.Where(p => p.ETypeID == _employee.ETypeID).FirstOrDefault();
            if (exitingEmployee != null)
            {
                exitingEmployee.ETypeDescription = _employee.ETypeDescription;
                exitingEmployee.Commissionable = _employee.Commissionable;
                return DB.SaveChanges();
            }
            return -1;
        }
    }
}