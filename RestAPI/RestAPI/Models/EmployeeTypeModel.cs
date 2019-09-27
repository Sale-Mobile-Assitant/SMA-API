using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class EmployeeTypeModel
    {
        public string CompID { get; set; }
        public string ETypeID { get; set; }
        public string ETypeDescription { get; set; }
        public bool? Commissionable { get; set; }
  
        public IEnumerable<EmployeeModel> Employees { get; set; }
    }
}