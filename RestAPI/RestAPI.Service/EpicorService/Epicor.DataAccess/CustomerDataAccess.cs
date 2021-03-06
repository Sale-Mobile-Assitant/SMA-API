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
    public class CustomerDataAccess
    {
        private static CustomerDataAccess _ins;

        public static CustomerDataAccess Ins
        {
            get
            {
                if (_ins == null)
                    _ins = new CustomerDataAccess();
                return CustomerDataAccess._ins;
            }
            private set
            {
                CustomerDataAccess._ins = value;
            }
        }

        public string GetCustomers()
        {
            string strResponseValue = "";
            string url = "https://portal.3ssoft.com.vn:7443/SRV03Epicor10Test/api/v1/Erp.BO.CustomerSvc/Customers";
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

        public async Task<bool> PostCustomers(EpicorCustomerModel customer)
        {
            string url = "https://portal.3ssoft.com.vn:7443/SRV03Epicor10Test/api/v1/Erp.BO.CustomerSvc/Customers";


            var json = JsonConvert.SerializeObject(customer);

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

        public async Task<bool> PatchCustomer(string Compamy, int custNum, string jsonCustomer)
        {
            string url = string.Format("https://portal.3ssoft.com.vn:7443/SRV03Epicor10Test/api/v1/Erp.BO.CustomerSvc/Customers({0},{1})", Compamy, custNum);


            HttpContent content = new StringContent(jsonCustomer, Encoding.UTF8, "application/json");


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

      
    }
}