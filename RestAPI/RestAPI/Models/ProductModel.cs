using System;
using System.Collections.Generic;

namespace RestAPI.Models
{
    public class ProductModel
    {
        public string CompID { get; set; }
        public string PGroupID { get; set; }
        public string ProdID { get; set; }
        public string ProdName { get; set; }
        public double? UnitPrice { get; set; }
        public string UOM { get; set; }
        public DateTime? DateUpdate { get; set; }

        public IEnumerable<ProductInSiteModel> ProductInSites { get; set; }

    }
}