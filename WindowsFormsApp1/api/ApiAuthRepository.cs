using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WindowsFormsApp1.api
{
    public class ApiAuthRepository
    {
        private static ApiAuthRepository _instance;
        public static ApiAuthRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ApiAuthRepository();
                return _instance;
            }
        }

        private readonly HttpClient _httpClient;

        private ApiAuthRepository()
        {
            _httpClient = ApiHelper.Instance.Client;
        }

        // 업체 토큰 발급
        public async Task<string> GetCompanyToken(string brn)
        {
            var url = "http://test.smartqapis.com:5001/api/Customers/authenticate";
            var data = new { Brn = brn };
            var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);
            var json = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<ApiResponse<JsonElement>>(json);

            if (!response.IsSuccessStatusCode || result == null || result.Data.ValueKind == JsonValueKind.Undefined)
                throw new Exception($"업체 토큰 발급 실패: {json}");

            return result.Data.GetProperty("Token").GetString();
        }

        // 사원 토큰 발급
        public async Task<string> GetEmployeeToken(string loginId, string password, string companyToken)
        {
            var url = "http://test.smartqapis.com:5000/api/Login";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Authorization", $"Bearer {companyToken}");

            var data = new { loginId, password };
            request.Content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<ApiResponse<string>>(json);

            if (!response.IsSuccessStatusCode || result == null)
                throw new Exception($"사원 토큰 발급 실패: {json}");

            return result.Data;
        }
    }
}
