using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace RestAPI.Service.EpicorService.Epicor.DataAccess
{
    public class CompanyDataAccess
    {
        private static CompanyDataAccess _ins;

        public static CompanyDataAccess Ins
        {
            get
            {
                if (_ins == null)
                    _ins = new CompanyDataAccess();
                return CompanyDataAccess._ins;
            }
            private set
            {
                CompanyDataAccess._ins = value;
            }
        }

        public string GetCompany(string id)
        {
            string strResponseValue = "";
            string url = string.Format("https://portal.3ssoft.com.vn:7443/SRV03Epicor10Test/api/v1/Erp.BO.CompanySvc/Companies({0})?$select=Company1%2CName%2CAddress1%2CAddress2%2CAddress3%2CCity%2CCountry%2CPhoneNum",id);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);



            String authHeaer = System.Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes("epicor" + ":" + "epicor"));
            request.Headers.Add("Authorization", "basic" + " " + authHeaer);

            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();

                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
            }
            finally
            {
                if (response != null)
                {
                    ((IDisposable)response).Dispose();
                }
            }

            return strResponseValue;
        }
    }
}