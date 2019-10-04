using System.Collections.Generic;

namespace RestAPI.Models
{
    public class ProductInSiteModel
    {
        public string CompID { get; set; }
        public string SiteID { get; set; }
        public string ProdID { get; set; }
        public double? Quantity { get; set; }
        public string UOM { get; set; }
        public IEnumerable<OrderDetailModel> OrderDetails { get; set; }

    }
}