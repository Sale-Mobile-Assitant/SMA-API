using Newtonsoft.Json;
using RestAPI.Service.EpicorService.Epicor.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RestAPI.Service.EpicorService
{
    public class EpicorOrderService : IEpicorOrderService
    {
        public List<EpicorOrderModel> Get()
        {
            List<EpicorOrderModel> list = new List<EpicorOrderModel>();
            string json = OrderDataAccess.Ins.GetOrders();
            var result = JsonConvert.DeserializeObject<EpicorOrderModels>(json);
            foreach (var item in result.value)
            {
                list.Add(new EpicorOrderModel()
                {
                    Company = item.Company,
                    PONum = item.PONum,
                    OrderNum = item.OrderNum,
                    CustNum = item.CustNum,
                    SalesRepCode1 = item.SalesRepCode1,
                    OrderDate = item.OrderDate,
                    NeedByDate = item.NeedByDate,
                    RequestDate = item.RequestDate,
                });
            }
            return list;
        }

        public async Task<bool> Post(EpicorOrderModel order)
        {
            if (await OrderDataAccess.Ins.PostOrders(order) == true)
                return true;
            return false;
        }


        public async Task<bool> Patch(string Compamy, string id, EpicorOrderModel order)
        {
            var jsonOrder = JsonConvert.SerializeObject(order);

            if (await ProductDataAccess.Ins.PatchProduct(Compamy, id, jsonOrder) == true)
                return true;
            return false;
        }

        public async Task<string> Deletes(string Compamy, string id)
        {
            var result = await OrderDataAccess.Ins.DeleteOrder(Compamy, id);

            if (result == "true")
                return "true";
            return result;
        }
    }
}