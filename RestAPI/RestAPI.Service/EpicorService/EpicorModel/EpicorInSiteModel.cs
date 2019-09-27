using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Service.EpicorService.EpicorModel
{
    public class EpicorInSiteModel
    {
        public string Company { get; set; }
        public string Plant { get; set; }
        public string PartNum { get; set; }
    }

    public class EpicorInSiteModels
    {
        public EpicorInSiteModel[] value { get; set; }
    }
}