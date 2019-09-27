using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Service.EpicorService
{
    public class EpicorOrderModel
    {
        public string Company { get; set; }
        public string PONum { get; set; }
        public int OrderNum { get; set; }
        public string CustNum { get; set; }
        public string SalesRepCode1 { get; set; }
        public string OrderDate { get; set; }
        public string NeedByDate { get; set; }

        public string RequestDate { get; set; }
    }

    public class EpicorOrderModels
    {
        public EpicorOrderModel[] value { get; set; }
    }
}