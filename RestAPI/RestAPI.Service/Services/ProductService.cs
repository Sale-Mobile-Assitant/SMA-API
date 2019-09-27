using RestAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Service.Services
{
    public class ProductService : IProductService
    {
        private SaleMobileAssistantEntities DB = new SaleMobileAssistantEntities();
        public int Add(Product _product)
        {
            DB.Products.Add(_product);
            return DB.SaveChanges();
        }

        public int Delete(string id)
        {
            var result = DB.Products.Where(p => p.ProdID == id).FirstOrDefault();
            if (result == null)
            {
                return -1;
            }
            DB.Entry(result).State = System.Data.Entity.EntityState.Deleted;
            return DB.SaveChanges();
        }

        public Product GetProduct(string id)
        {
            return DB.Products.Where(p => p.ProdID == id).FirstOrDefault();
        }

        public List<Product> GetProducts()
        {
            return DB.Products.ToList();
        }

        public int Put(Product _product)
        {
            var exitingProduct = DB.Products.Where(p => p.ProdID == _product.ProdID).FirstOrDefault();
            if (exitingProduct != null)
            {
                exitingProduct.CompID = _product.CompID;
                exitingProduct.PGroupID = _product.PGroupID;
                exitingProduct.ProdName = _product.ProdName;
                exitingProduct.UnitPrice = _product.UnitPrice;
                exitingProduct.UOM = _product.UOM;
                exitingProduct.DateUpdate = _product.DateUpdate;

                return DB.SaveChanges();
            }
            return -1;
        }
    }
}