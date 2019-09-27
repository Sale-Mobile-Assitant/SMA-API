using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Service.EpicorService.EpicorModel
{
    public class EpicorProductGroupModel
    {
        public string Company { get; set; }
        public string ProdCode { get; set; }
        public string Description { get; set; }
    }
    public class EpicorProductGroupModels
    {
        public EpicorProductGroupModel[] value { get; set; }
    }
}