using RestAPI.Data;
using System.Collections.Generic;

namespace RestAPI.Service.Services
{
    public interface IProductGroupService
    {
        int Add(ProductGroup _product);

        int Delete(string id);

        ProductGroup GetProduct(string id);

        List<ProductGroup> GetProducts();

        int Put(ProductGroup _product);
    }
}