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
    public class EpicorOrderDetailService : IEpicorOrderDetailService
    {
        public List<EpicorOrderDetailModel> Get()
        {
            List<EpicorOrderDetailModel> list = new List<EpicorOrderDetailModel>();
            string json = OrderDetailDataAccess.Ins.GetOrders();
            var result = JsonConvert.DeserializeObject<EpicorOrderDetailModels>(json);
            foreach (var item in result.value)
            {
                list.Add(new EpicorOrderDetailModel()
                {
                    Company = item.Company,
                    POLine   = item.POLine,
                    OrderNum = item.OrderNum,
                    LineType = item.LineType,
                    OrderLine = item.OrderLine,
                    PartNum  = item.PartNum,
                    SellingQuantity = item.SellingQuantity,
                    DocDspUnitPrice = item.DocDspUnitPrice,
                });
            }
            return list;
        }

        public async Task<bool> Post(EpicorOrderDetailModel order)
        {
            if (await OrderDetailDataAccess.Ins.PostOrders(order) == true)
                return true;
            return false;
        }


    }
}