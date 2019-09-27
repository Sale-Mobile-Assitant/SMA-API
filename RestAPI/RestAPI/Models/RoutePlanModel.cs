using System;

namespace RestAPI.Models
{
    public class RoutePlanModel
    {
        public string CompID { get; set; }
        public string EmplID { get; set; }
        public int? CustID { get; set; }
        public DateTime? DatePlan { get; set; }
        public int? Prioritize { get; set; }
        public bool? Visited { get; set; }
        public string Note { get; set; }
    }
}