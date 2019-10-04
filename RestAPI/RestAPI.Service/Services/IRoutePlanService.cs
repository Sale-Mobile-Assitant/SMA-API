using RestAPI.Data;
using System;
using System.Collections.Generic;

namespace RestAPI.Service.Services
{
    public interface IRoutePlanService
    {
        int Add(RoutePlan _routePlan);

        int Delete(string CompID, string EmplID, int CustID, DateTime DatePlan);

        RoutePlan GetRoutePlan(string id);

        List<RoutePlan> GetRoutePlans();

        int Put(RoutePlan _routePlan, string CompID, string EmplID, int CustID, DateTime DatePlan);
    }
}