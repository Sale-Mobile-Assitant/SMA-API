using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Service.EpicorService.EpicorModel
{
    public class EpicorSiteModel
    {
        public string Company { get; set; }
        public string Plant1 { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PhoneNum { get; set; }

    }
    public class EpicorSiteModels
    {
        public EpicorSiteModel[] value { get; set; }
    }
}