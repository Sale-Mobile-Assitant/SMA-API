using Newtonsoft.Json;
using RestAPI.Service.EpicorService.Epicor.DataAccess;
using RestAPI.Service.EpicorService.EpicorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Service.EpicorService
{
    public class EpicorProductGroupService : IEpicorProductGroupService
    {
        public List<EpicorProductGroupModel> Get()
        {
            List<EpicorProductGroupModel> list = new List<EpicorProductGroupModel>();
            string json = ProductGroupDataAccess.Ins.Get();
            var result = JsonConvert.DeserializeObject<EpicorProductGroupModels>(json);
            foreach (var item in result.value)
            {
                list.Add(new EpicorProductGroupModel()
                {
                    Company = item.Company,
                    ProdCode = item.ProdCode,
                    Description = item.Description
                });
            }
            return list;
        }
    }
}