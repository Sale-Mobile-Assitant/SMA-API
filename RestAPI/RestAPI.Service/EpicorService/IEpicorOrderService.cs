using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPI.Service.EpicorService
{
    public interface IEpicorOrderService
    {
        List<EpicorOrderModel> Get();

        Task<bool> Post(EpicorOrderModel order);

        Task<bool> Patch(string Compamy, string id, EpicorOrderModel order);

        Task<string> Deletes(string Compamy, string id);
    }
}