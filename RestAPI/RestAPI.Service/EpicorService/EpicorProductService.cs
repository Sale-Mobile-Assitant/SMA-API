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
    public class EpicorProductService : IEpicorProductService
    {
        public List<EpicorProductModel> Get()
        {
            List<EpicorProductModel> list = new List<EpicorProductModel>();
            string json = ProductDataAccess.Ins.GetProducts();
            var result = JsonConvert.DeserializeObject<EpicorProductModels>(json);
            foreach (var item in result.value)
            {
                list.Add(new EpicorProductModel()
                {
                    Company = item.Company,
                    ProdCode = item.ProdCode,
                    PartNum = item.PartNum,
                    PartDescription = item.PartDescription,
                    UnitPrice = item.UnitPrice,
                    IUM = item.IUM
                });
            }
            return list;
        }

        public async Task<bool> Post(EpicorProductModel product)
        {
            if (await ProductDataAccess.Ins.PostProduct(product) == true)
                return true;
            return false;
        }


        public async Task<bool> Patch(string Compamy, string id, EpicorProductModel product)
        {
            var jsonCustomer = JsonConvert.SerializeObject(product);

            if (await ProductDataAccess.Ins.PatchProduct(Compamy, id, jsonCustomer) == true)
                return true;
            return false;
        }

        public async Task<string> DeleteCustomers(string Compamy, string id)
        {
            var result = await ProductDataAccess.Ins.DeleteProduct(Compamy, id);

            if (result == "true")
                return "true";
            return result;
        }
    }
}