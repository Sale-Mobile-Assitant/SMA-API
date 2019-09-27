using Newtonsoft.Json;
using RestAPI.Service.EpicorService.Epicor.DataAccess;
using RestAPI.Service.EpicorService.EpicorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Service.EpicorService
{
    public class EpicorEmployeeService : IEpicorEmployeeService
    {
        public List<EpicorEmployeeModel> Get()
        {
            List<EpicorEmployeeModel> list = new List<EpicorEmployeeModel>();
            string json = EmployeeDataAccess.Ins.GetEmployees();
            var result = JsonConvert.DeserializeObject<EpicorEmployeeModels>(json);
            foreach (var item in result.value)
            {
                list.Add(new EpicorEmployeeModel()
                {
                    Company = item.Company,
                    RoleCode = item.RoleCode,
                    SalesRepCode = item.SalesRepCode,
                    Name = item.Name,
                    Address1 = item.Address1,
                    Address2 = item.Address2,
                    Address3 = item.Address3,
                    CellPhoneNum = item.CellPhoneNum
                });
            }
            return list;
        }
    }
}