using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace RestAPI.Service.EpicorService.Epicor.DataAccess
{
    public class ProductGroupDataAccess
    {
        private static ProductGroupDataAccess _ins;

        public static ProductGroupDataAccess Ins
        {
            get
            {
                if (_ins == null)
                    _ins = new ProductGroupDataAccess();
                return ProductGroupDataAccess._ins;
            }
            private set
            {
                ProductGroupDataAccess._ins = value;
            }
        }

        public string Get()
        {
            string strResponseValue = "";
            string url = "https://portal.3ssoft.com.vn:7443/SRV03Epicor10Test/api/v1/Erp.BO.ProdGrupSvc/ProdGrups?$select=Company%2CProdCode%2CDescription";

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