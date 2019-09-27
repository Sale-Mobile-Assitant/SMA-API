using RestAPI.Data;
using System.Collections.Generic;

namespace RestAPI.Service.Services
{
    public interface IProductService
    {
        int Add(Product _product);

        int Delete(string id);

        Product GetProduct(string id);

        List<Product> GetProducts();

        int Put(Product _product);
    }
}