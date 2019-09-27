using RestAPI.Service.EpicorService.EpicorModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPI.Service.EpicorService
{
    public interface IEpicorCustomerService
    {
        List<EpicorCustomerModel> Get();

        Task<bool> Post(EpicorCustomerModel customer);

        Task<bool> Patch(string Compamy, int CustNum, EpicorCustomerModel customer);

    }
}