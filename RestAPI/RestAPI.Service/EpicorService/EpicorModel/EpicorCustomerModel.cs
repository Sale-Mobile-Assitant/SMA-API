using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestAPI.Service.EpicorService.EpicorModel
{
    public class EpicorCustomerModel
    {
        public string Company { get; set; }
        
        public string SalesRepCode { get; set; }
        [Key]
        public int CustNum { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNum { get; set; }
        public string DiscountPercent { get; set; }    
    }

    public class EpicorCustomerModels
    {
        public EpicorCustomerModel[] value { get; set; }
    }
}