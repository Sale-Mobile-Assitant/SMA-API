using Newtonsoft.Json;
using RestAPI.Service.EpicorService.Epicor.DataAccess;
using RestAPI.Service.EpicorService.EpicorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Service.EpicorService
{
    public class EpicorSiteService : IEpicorSiteService
    {
        public List<EpicorSiteModel> Get()
        {
            List<EpicorSiteModel> list = new List<EpicorSiteModel>();
            string json = SiteDataAccess.Ins.GetSites();
            var result = JsonConvert.DeserializeObject<EpicorSiteModels>(json);
            foreach (var item in result.value)
            {
                list.Add(new EpicorSiteModel()
                {
                    Company = item.Company,
                    Plant1 = item.Plant1,
                    Name = item.Name,                   
                    Address1 = item.Address1,
                    Address2 = item.Address2,
                    Address3 = item.Address3,
                    City = item.City,
                    State = item.State,
                    PhoneNum = item.PhoneNum
                });
            }
            return list;
        }
    }
}