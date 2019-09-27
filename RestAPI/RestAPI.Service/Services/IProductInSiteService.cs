using RestAPI.Data;
using System.Collections.Generic;

namespace RestAPI.Service.Services
{
    public interface IProductInSiteService
    {
        int Add(ProductInSite _item);
        List<ProductInSite> Get();
    }
}