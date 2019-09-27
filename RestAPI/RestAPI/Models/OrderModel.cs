using System;
using System.Collections.Generic;

namespace RestAPI.Models
{
    public class OrderModel
    {
        public string CompID { get; set; }
        public string MyOrderID { get; set; }
        public int? OrdeID { get; set; }
        public int? CustID { get; set; }
        public string EmplID { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? NeedByDate { get; set; }
        public DateTime? RequestDate { get; set; }
        public int? OrderStatus { get; set; }

        public IEnumerable<OrderDetailModel> OrderDetail { get; set; }
    }
}