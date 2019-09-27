using RestAPI.Service.EpicorService.EpicorModel;
using System.Collections.Generic;

namespace RestAPI.Service.EpicorService
{
    public interface IEpicorEmployeeService
    {
        List<EpicorEmployeeModel> Get();
    }
}