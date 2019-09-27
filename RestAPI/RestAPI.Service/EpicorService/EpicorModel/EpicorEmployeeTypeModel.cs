using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Service.EpicorService.EpicorModel
{
    public class EpicorEmployeeTypeModel
    {
        public string Company { get; set; }

        public string RoleCode { get; set; }

        public string RoleDescription { get; set; }

        public string Commissionable { get; set; }
    }

    public class EpicorEmployeeTypeModels
    {
        public EpicorEmployeeTypeModel[] value { get; set; }
    }
}