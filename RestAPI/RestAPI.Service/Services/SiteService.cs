using RestAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Service.Services
{
    public class SiteService : ISiteService
    {
        private SaleMobileAssistantEntities DB = new SaleMobileAssistantEntities();
        public int Add(Site _item)
        {
            DB.Sites.Add(_item);
            return DB.SaveChanges();
        }

       

        public List<Site> Get()
        {
            return DB.Sites.ToList();
        }

    }
}