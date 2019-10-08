using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class StatusTypeModel
    {
        public int STypeID { get; set; }

        public string STypeName { get; set; }

        public IEnumerable<OrderModel> Orders { get; set; }
    }
}