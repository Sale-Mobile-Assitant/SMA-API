using RestAPI.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class CompanyModel
    {
        
        public string CompID { get; set; }
        public string CompName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
       
        public string City { get; set; }
        public string Province { get; set; }
        public string PhoneNum { get; set; }

        public IEnumerable<EmployeeTypeModel> EmployeeType { get; set; }
        public IEnumerable<ProductGroupModel> ProductGroup { get; set; }
        public IEnumerable<SiteModel> Site { get; set; }
    }
}