//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestAPI.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductInSite
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductInSite()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public string CompID { get; set; }
        public string SiteID { get; set; }
        public string ProdID { get; set; }
        public Nullable<double> Quatity { get; set; }
        public string UOM { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Product Product { get; set; }
        public virtual Site Site { get; set; }
    }
}
