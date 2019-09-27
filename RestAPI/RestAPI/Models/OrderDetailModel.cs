namespace RestAPI.Models
{
    public class OrderDetailModel
    {
        public string CompID { get; set; }
        public string SiteID { get; set; }
        public string MyOrderID { get; set; }
        public string ProdID { get; set; }
        public decimal? SellingQuantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? OrderNum { get; set; }
        public int? OrderLine { get; set; }
        public string LineType { get; set; }


    }
}