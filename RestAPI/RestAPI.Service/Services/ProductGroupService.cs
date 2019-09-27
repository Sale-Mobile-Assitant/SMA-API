using RestAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Service.Services
{
    public class ProductGroupService : IProductGroupService
    {
        private SaleMobileAssistantEntities DB = new SaleMobileAssistantEntities();
        public int Add(ProductGroup _product)
        {
            DB.ProductGroups.Add(_product);
            return DB.SaveChanges();
        }

        public int Delete(string id)
        {
            var result = DB.ProductGroups.Where(p => p.PGroupID == id).FirstOrDefault();
            if (result == null)
            {
                return -1;
            }
            DB.Entry(result).State = System.Data.Entity.EntityState.Deleted;
            return DB.SaveChanges();
        }

        public ProductGroup GetProduct(string id)
        {
            return DB.ProductGroups.Where(p => p.PGroupID == id).FirstOrDefault();
        }

        public List<ProductGroup> GetProducts()
        {
            return DB.ProductGroups.ToList();
        }

        public int Put(ProductGroup _product)
        {
            var exitingProduct = DB.ProductGroups.Where(p => p.PGroupID == _product.PGroupID).FirstOrDefault();
            if (exitingProduct != null)
            {
                exitingProduct.CompID = _product.CompID;
                exitingProduct.PGroupID = _product.PGroupID;
                exitingProduct.PGdescription = _product.PGdescription;

                return DB.SaveChanges();
            }
            return -1;
        }
    }
}