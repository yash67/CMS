using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Project_Layout_Demo
{
    public static class GlobalVariables
    {
        //string baseUrl = "http://localhost:49261/";

        public static HttpClient client = new HttpClient();

        static GlobalVariables()
        {
            string baseUrl = ConfigurationManager.AppSettings["APIUrl"];
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}