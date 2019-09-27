using RestAPI.Service.EpicorService.EpicorModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPI.Service.EpicorService
{
    public interface IEpicorOrderDetailService
    {
        List<EpicorOrderDetailModel> Get();

        Task<bool> Post(EpicorOrderDetailModel order);
    }
}