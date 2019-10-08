using RestAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Service.Services
{
    public class StatusTypeService : IStatusTypeService
    {
        private SaleMobileAssistantEntities DB = new SaleMobileAssistantEntities();

        public List<StatusType> GetStatusType()
        {
            return DB.StatusTypes.ToList();
        }
    }
}