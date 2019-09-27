using Newtonsoft.Json;
using RestAPI.Service.EpicorService.APIHelper;
using RestAPI.Service.EpicorService.EpicorModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RestAPI.Service.EpicorService.Epicor.DataAccess
{
    public class ProductDataAccess
    {
        private static ProductDataAccess _ins;

        public static ProductDataAccess Ins
        {
            get
            {
                if (_ins == null)
                    _ins = new ProductDataAccess();
                return ProductDataAccess._ins;
            }
            private set
            {
                ProductDataAccess._ins = value;
            }
        }

        public string GetProducts()
        {
            string strResponseValue = "";
            string url = "https://portal.3ssoft.com.vn:7443/SRV03Epicor10Test/api/v1/Erp.BO.PartSvc/Parts?$select=Company%2CProdCode%2CPartNum%2CPartDescription%2CUnitPrice%2CIUM";
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

        public async Task<bool> PostProduct(EpicorProductModel product)
        {
            string url = "https://portal.3ssoft.com.vn:7443/SRV03Epicor10Test/api/v1/Erp.BO.PartSvc/Parts";


            var json = JsonConvert.SerializeObject(product);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");



            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = content
            };
            message.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "epicor", "epicor"))));


            using (HttpResponseMessage response = await ApiHelper.Instance.apiClient.SendAsync(message))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<bool> PatchProduct(string Compamy, string id, string jsonProduct)
        {
            string url = string.Format("https://portal.3ssoft.com.vn:7443/SRV03Epicor10Test/api/v1/Erp.BO.PartSvc/Parts({0},{1})", Compamy, id);


            HttpContent content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");


            HttpRequestMessage message = new HttpRequestMessage(new HttpMethod("PATCH"), url)
            {
                Content = content
            };
            message.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "epicor", "epicor"))));


            using (HttpResponseMessage response = await ApiHelper.Instance.apiClient.SendAsync(message))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public async Task<string> DeleteProduct(string Compamy, string id)
        {
            string url = string.Format("https://portal.3ssoft.com.vn:7443/SRV03Epicor10Test/api/v1/Erp.BO.PartSvc/Parts({0},{1})", Compamy, id);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, url);

            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "epicor", "epicor"))));


            using (HttpResponseMessage response = await ApiHelper.Instance.apiClient.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    return "true";
                }
                else
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }
    }
}