using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace RestAPI.Service.EpicorService.APIHelper
{
    public class ApiHelper
    {
        private static ApiHelper instance;

        public static ApiHelper Instance
        {
            get
            {
                if (instance == null)
                    instance = new ApiHelper();
                return ApiHelper.instance;
            }
            private set
            {
                ApiHelper.instance = value;
            }
        }
        public HttpClient apiClient { get; set; }

        private ApiHelper()
        {
            InitializeClient();
        }

        private void InitializeClient()
        {
            apiClient = new HttpClient();
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}