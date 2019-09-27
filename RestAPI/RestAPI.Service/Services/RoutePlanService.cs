﻿using RestAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Service.Services
{
    public class RoutePlanService : IRoutePlanService
    {
        private SaleMobileAssistantEntities DB = new SaleMobileAssistantEntities();
        public int Add(RoutePlan _routePlan)
        {
            DB.RoutePlans.Add(_routePlan);
            return DB.SaveChanges();
        }

        public int Delete(string id)
        {
            var result = DB.RoutePlans.Where(p => p.EmplID == id).FirstOrDefault();
            if (result == null)
            {
                return -1;
            }
            DB.Entry(result).State = System.Data.Entity.EntityState.Deleted;
            return DB.SaveChanges();
        }

        public RoutePlan GetRoutePlan(string id)
        {
            return DB.RoutePlans.Where(p => p.EmplID == id).FirstOrDefault();
        }

        public List<RoutePlan> GetRoutePlans()
        {
            return DB.RoutePlans.ToList();
        }

        public int Put(RoutePlan _routePlan)
        {
            var exitingRoutePlan = DB.RoutePlans.Where(p => p.EmplID == _routePlan.EmplID).FirstOrDefault();
            if (exitingRoutePlan != null)
            {
                exitingRoutePlan.CompID = _routePlan.CompID;
                exitingRoutePlan.EmplID = _routePlan.EmplID;
                exitingRoutePlan.CustID = _routePlan.CustID;
                exitingRoutePlan.DatePlan = _routePlan.DatePlan;
                exitingRoutePlan.Prioritize = _routePlan.Prioritize;
                exitingRoutePlan.Visited = _routePlan.Visited;
                exitingRoutePlan.Note = _routePlan.Note;

                return DB.SaveChanges();
            }
            return -1;
        }
    }
}