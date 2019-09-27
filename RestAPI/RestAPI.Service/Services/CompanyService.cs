using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using RestAPI.Data;

namespace RestAPI.Service.Services
{
    public class CompanyService : ICompanyService
    {
        private SaleMobileAssistantEntities DB = new SaleMobileAssistantEntities();

        public int Add(Company company)
        {
            DB.Companies.Add(company);
            return DB.SaveChanges();
        }

        public List<Company> GetCompanies()
        {
            return DB.Companies.ToList();
        }

        public Company GetCompany(string id)
        {
            return DB.Companies.Where(p => p.CompID == id).FirstOrDefault();
        }

        public int Put(Company _company)
        {
            var exitingCompany = DB.Companies.Where(p => p.CompID == _company.CompID).FirstOrDefault();
            if (exitingCompany != null)
            {
                exitingCompany.CompName = _company.CompName;
                exitingCompany.Address1 = _company.Address1;
                exitingCompany.Address2 = _company.Address2;
                exitingCompany.Address3 = _company.Address3;
                exitingCompany.City = _company.City;
                exitingCompany.PhoneNum = _company.PhoneNum;
                exitingCompany.Province = _company.Province;

                return DB.SaveChanges();
            }
            return -1;
        }

        public int Delete(string id)
        {
            var result = DB.Companies.Where(p => p.CompID == id).FirstOrDefault();
            if (result == null)
            {
                return -1;
            }
            DB.Entry(result).State = System.Data.Entity.EntityState.Deleted;
            return DB.SaveChanges();
        }
    }
}