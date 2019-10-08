using RestAPI.Data;
using System.Collections.Generic;

namespace RestAPI.Service.Services
{
    public interface IStatusTypeService
    {
        List<StatusType> GetStatusType();
    }
}