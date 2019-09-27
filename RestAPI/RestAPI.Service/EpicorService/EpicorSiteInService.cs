using Newtonsoft.Json;
using RestAPI.Service.EpicorService.Epicor.DataAccess;
using RestAPI.Service.EpicorService.EpicorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Service.EpicorService
{
    public class EpicorSiteInService : IEpicorSiteInService
    {
        public List<EpicorInSiteModel> Get()
        {
            List<EpicorInSiteModel> list = new List<EpicorInSiteModel>();
            string json = ProdductInSiteDataAccess.Ins.GetProductInSites();
            var result = JsonConvert.DeserializeObject<EpicorInSiteModels>(json);
            foreach (var item in result.value)
            {
                list.Add(new EpicorInSiteModel()
                {
                    Company = item.Company,
                    Plant = item.Plant,
                    PartNum = item.PartNum
                });
            }
            return list;
        }
    }
}