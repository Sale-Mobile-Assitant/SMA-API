using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Service.EpicorService.EpicorModel
{
    public class EpicorOrderDetail
    {
        public string Company { get; set; }
        public string POLine { get; set; }
        public string PartNum { get; set; }
        public string SellingQuantity { get; set; }
        public string DocDspUnitPrice { get; set; }
    }
    public class EpicorOrderDetails
    {
        public EpicorOrderDetail[] value { get; set; }
    }
}