using RestAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Service.Services
{
    public class ProductInSiteService : IProductInSiteService
    {
        private SaleMobileAssistantEntities DB = new SaleMobileAssistantEntities();
        public int Add(ProductInSite _item)
        {
            DB.ProductInSites.Add(_item);
            return DB.SaveChanges();
        }

        public List<ProductInSite> Get()
        {
            return DB.ProductInSites.ToList();
        }

      
    }
}