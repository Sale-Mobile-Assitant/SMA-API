using RestAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RestAPI.Service.Services
{
    public interface ICompanyService
    {
        List<Company> GetCompanies();
        Company GetCompany(string id);

        int Add(Company company);


        int Put(Company company);

        int Delete(string id);

      
    }
}