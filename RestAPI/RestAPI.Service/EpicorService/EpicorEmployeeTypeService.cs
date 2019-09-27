using Newtonsoft.Json;
using RestAPI.Service.EpicorService.Epicor.DataAccess;
using RestAPI.Service.EpicorService.EpicorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Service.EpicorService
{
    public class EpicorEmployeeTypeService : IEpicorEmployeeTypeService
    {
        public List<EpicorEmployeeTypeModel> Get()
        {
            List<EpicorEmployeeTypeModel> list = new List<EpicorEmployeeTypeModel>();
            string json = EmployeeTypeDataAccess.Ins.GetEmployeesType();
            var result = JsonConvert.DeserializeObject<EpicorEmployeeTypeModels>(json);
            foreach (var item in result.value)
            {
                list.Add(new EpicorEmployeeTypeModel()
                {
                    Company = item.Company,
                    RoleCode = item.RoleCode,
                    RoleDescription = item.RoleDescription,
                    Commissionable = item.Commissionable
                });
            }
            return list;
        }
    }
}