using System;
using System.Collections.Generic;

namespace RestAPI.Models
{
    public class EmployeeModel
    {
        public string CompID { get; set; }
        public string ETypeID { get; set; }
        public string EmplID { get; set; }
        public string EmplName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string PhoneNum { get; set; }
        public DateTime? DateIn { get; set; }
        public DateTime? DateOut { get; set; }

        public IEnumerable<AccountModel> Account { get; set; }
        public IEnumerable<CustomerModel> Customer { get; set; }
        public IEnumerable<OrderModel> Order { get; set; }
        public IEnumerable<RoutePlanModel> RoutePlan { get; set; }
        public IEnumerable<SaleTargetModel> SaleTarget { get; set; }
    }
}