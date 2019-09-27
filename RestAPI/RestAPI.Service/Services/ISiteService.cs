using RestAPI.Data;
using System.Collections.Generic;
namespace RestAPI.Service.Services
{
    public interface ISiteService
    {
        int Add(Site _item);

        List<Site> Get();
    }
}