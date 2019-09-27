using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Service.EpicorService.EpicorModel
{
    public class EpicorEmployeeModel
    {
        public string Company { get; set; }

        public string RoleCode { get; set; }
        public string SalesRepCode { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string CellPhoneNum { get; set; }
    }

    public class EpicorEmployeeModels
    {
        public EpicorEmployeeModel[] value { get; set; }
    }
}