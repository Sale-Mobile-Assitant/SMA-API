using RestAPI.Service.EpicorService.EpicorModel;
using System.Collections.Generic;

namespace RestAPI.Service.EpicorService
{
    public interface IEpicorCompanySeervice
    {
        EpicorCompanyModel Get(string ID);
    }
}