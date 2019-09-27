using Newtonsoft.Json;
using RestAPI.Service.EpicorService.Epicor.DataAccess;
using RestAPI.Service.EpicorService.EpicorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RestAPI.Service.EpicorService
{
    public class EpicorCustomerService : IEpicorCustomerService
    {
        public List<EpicorCustomerModel> Get()
        {
            List<EpicorCustomerModel> list = new List<EpicorCustomerModel>();
            string json = CustomerDataAccess.Ins.GetCustomers();
            var result = JsonConvert.DeserializeObject<EpicorCustomerModels>(json);
            foreach (var item in result.value)
            {
                list.Add(new EpicorCustomerModel()
                {
                    Company = item.Company,
                    SalesRepCode = item.SalesRepCode,
                    CustNum = item.CustNum,
                    Name = item.Name,
                    City = item.City,
                    Address1 = item.Address1,
                    Address2 = item.Address2,
                    Address3 = item.Address3,
                    Country = item.Country,
                    PhoneNum = item.PhoneNum,
                    DiscountPercent = item.DiscountPercent,                    
                });
            }
            return list;
        }

        public async Task<bool> Post(EpicorCustomerModel customer)
        {
            if (await CustomerDataAccess.Ins.PostCustomers(customer) == true)
                return true;
            return false;
        }


        public async Task<bool> Patch(string Compamy, int CustNum, EpicorCustomerModel customer)
        {
            var jsonCustomer = JsonConvert.SerializeObject(customer);

            if (await CustomerDataAccess.Ins.PatchCustomer(Compamy, CustNum, jsonCustomer) == true)
                return true;
            return false;
        }

    }
}