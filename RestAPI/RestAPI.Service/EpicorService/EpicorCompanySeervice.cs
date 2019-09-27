using Newtonsoft.Json;
using RestAPI.Service.EpicorService.Epicor.DataAccess;
using RestAPI.Service.EpicorService.EpicorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Service.EpicorService
{
    public class EpicorCompanySeervice : IEpicorCompanySeervice
    {
        public EpicorCompanyModel Get(string ID)
        {
            string json = CompanyDataAccess.Ins.GetCompany(ID);
            var result = JsonConvert.DeserializeObject<EpicorCompanyModel>(json);

            EpicorCompanyModel company = new EpicorCompanyModel()
            {
                Company1 = result.Company1,
                Name = result.Name,
                Address1 = result.Address1,
                Address2 = result.Address2,
                Address3 = result.Address3,
                City = result.City,
                PhoneNum = result.PhoneNum,
                Country = result.Country,
            };
            return company;
        }
    }
}