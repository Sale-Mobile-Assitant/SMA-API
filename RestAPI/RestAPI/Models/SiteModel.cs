using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class SiteModel
    {
        public string CompID { get; set; }
        public string SiteID { get; set; }
        public string SiteName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PhoneNum { get; set; }

        public IEnumerable<ProductInSiteModel> ProductInSites { get; set; }
    }
}