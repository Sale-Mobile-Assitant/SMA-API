using RestAPI.Data;
using System.Collections.Generic;

namespace RestAPI.Service.Services
{
    public interface IRoutePlanService
    {
        int Add(RoutePlan _routePlan);

        int Delete(string id);

        RoutePlan GetRoutePlan(string id);

        List<RoutePlan> GetRoutePlans();

        int Put(RoutePlan _routePlan);
    }
}