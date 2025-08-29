using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.api
{
    public class ApiHelper
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static ApiHelper _instance;
        public static ApiHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ApiHelper();
                return _instance;
            }
        }

        public HttpClient Client => _httpClient;

        private string _employeeToken;

        public void SetToken(string token)
        {
            _employeeToken = token;
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }
    }
}
