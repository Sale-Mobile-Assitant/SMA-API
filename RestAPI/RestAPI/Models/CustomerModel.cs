using System.Collections.Generic;

namespace RestAPI.Models
{
    public class CustomerModel
    {
        public string CompID { get; set; }
        public string EmplID { get; set; }
        public string CustID { get; set; }
        public string CustName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNum { get; set; }
        public string Discount { get; set; }

        public IEnumerable<OrderModel> Order { get; set; }
        public IEnumerable<RoutePlanModel> RoutePlan { get; set; }
    }
}