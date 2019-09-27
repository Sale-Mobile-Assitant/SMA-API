namespace RestAPI.Models
{
    public class SaleTargetModel
    {
        public string CompID { get; set; }
        public int ID { get; set; }
        public string EmplID { get; set; }
        public int? PeriodTarget { get; set; }
        public int? YearTarget { get; set; }
        public int? TargetQty { get; set; }
        public string Note { get; set; }
    }
}