using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestAPI.Service.EpicorService.EpicorModel
{
    public class EpicorCompanyModel
    {
        [Key]
        public string Company1 { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNum { get; set; }
    }

}