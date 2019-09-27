using RestAPI.Service.EpicorService.EpicorModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPI.Service.EpicorService
{
    public interface IEpicorProductService
    {
        List<EpicorProductModel> Get();

        Task<bool> Post(EpicorProductModel product);

        Task<bool> Patch(string Compamy, string id, EpicorProductModel product);

        Task<string> DeleteCustomers(string Compamy, string id);
    }
}