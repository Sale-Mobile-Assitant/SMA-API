using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace RestAPI.Service.EpicorService.Epicor.DataAccess
{
    public class SiteDataAccess
    {
        private static SiteDataAccess _ins;

        public static SiteDataAccess Ins
        {
            get
            {
                if (_ins == null)
                    _ins = new SiteDataAccess();
                return SiteDataAccess._ins;
            }
            private set
            {
                SiteDataAccess._ins = value;
            }
        }

        public string GetSites()
        {
            string strResponseValue = "";
            string url = "https://portal.3ssoft.com.vn:7443/SRV03Epicor10Test/api/v1/Erp.BO.PlantSvc/Plants?$select=Company%2C%20Plant1%2C%20Name%2C%20Address1%2C%20Address2%2C%20Address3%2C%20City%2C%20State%2C%20PhoneNum";
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