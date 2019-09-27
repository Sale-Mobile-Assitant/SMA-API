using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class ProductGroupModel
    {
        public string CompID { get; set; }
        public string PGroupID { get; set; }
        public string PGdescription { get; set; }

        public IEnumerable<ProductModel> Products { get; set; }
    }
}