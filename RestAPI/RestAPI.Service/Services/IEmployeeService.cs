using RestAPI.Data;
using System.Collections.Generic;

namespace RestAPI.Service.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();

        Employee GetEmployee(string id);

        int Add(Employee _employee);

        int Put(Employee _employee);

        int Delete(string id);
    }
}