using RestAPI.Data;
using System.Collections.Generic;

namespace RestAPI.Service.Services
{
    public interface IEmployeeTypeService
    {
        int Add(EmployeeType _employee);

        int Delete(string id);

        EmployeeType GetEmployee(string id);

        List<EmployeeType> GetEmployees();

        int Put(EmployeeType _employee);
    }
}