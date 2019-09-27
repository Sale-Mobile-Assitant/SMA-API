using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Service.EpicorService.EpicorModel
{
    public class EpicorProductModel
    {
        public string Company { get; set; }
        public string ProdCode { get; set; }
        public string PartNum { get; set; }
        public string PartDescription { get; set; }
        public string UnitPrice { get; set; }
        public string IUM { get; set; }
    }

    public class EpicorProductModels
    {
        public EpicorProductModel[] value { get; set; }
    }
}