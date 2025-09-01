using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.helper;

namespace WindowsFormsApp1.api
{
    public class ApiUserRepository
    {
        private static ApiUserRepository _instance;
        public static ApiUserRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ApiUserRepository();
                return _instance;
            }
        }
        private readonly HttpClient _httpClient;

        private ApiUserRepository() {
            _httpClient = ApiHelper.Instance.Client;
        }

        // 사원 목록 조회
        public async Task<ApiResponse<List<User>>> GetUser(int factoryId)
        {
            var url = $"http://test.smartqapis.com:5000/api/Employee?factoryId={factoryId}";
            var response = await _httpClient.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<ApiResponse<List<User>>>(json);
            if (!response.IsSuccessStatusCode || result == null)
                throw new Exception($"사원 목록 조회 실패: {json}");

            return result;
        }

        // 사원 추가
        public async Task<ApiResponse<long?>> AddUser(User user)
        {
            var url = "http://test.smartqapis.com:5000/api/Employee";
            var data = new
            {
                Code = user.UserId,
                Name = user.UserName,
                Position = user.UserRank,
                ContractType = user.UserEmpType,
                LoginId = user.UserLoginId,
                LoginPassword = user.UserPass,
                LoginTag = "",
                PhoneNumber = user.UserTel,
                Email = user.UserEmail,
                MessengerId = user.UserMessengerId,
                Memo = user.RemarkDc,
                DepartmentId = user.IdDept,
                IsAdmin = false
            };

            var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            var json = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<ApiResponse<long?>>(json);
            if (!response.IsSuccessStatusCode || result == null)
                throw new Exception($"사원 추가 실패: {json}");

            return result;
        }

        // 사원 수정
        public async Task<ApiResponse<object>> UpdateUser(User user)
        {
            var url = $"http://test.smartqapis.com:5000/api/Employee/{user.Id}";
            var data = new
            {
                Code = user.UserId,
                Name = user.UserName,
                Position = user.UserRank,
                ContractType = user.UserEmpType,
                PhoneNumber = user.UserTel,
                Email = user.UserEmail,
                MessengerId = user.UserMessengerId,
                Memo = user.RemarkDc,
                DepartmentId = user.IdDept
            };

            var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, content);
            var json = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<ApiResponse<object>>(json);
            if (!response.IsSuccessStatusCode || result == null)
                throw new Exception($"사원 수정 실패: {json}");

            return result;
        }

        // 사원 삭제
        public async Task<ApiResponse<object>> DeleteUser(long employeeId)
        {
            var url = $"http://test.smartqapis.com:5000/api/Employee/{employeeId}";
            var response = await _httpClient.DeleteAsync(url);
            var json = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<ApiResponse<object>>(json);
            if (!response.IsSuccessStatusCode || result == null)
                throw new Exception($"사원 삭제 실패: {json}");

            return result;
        }
    }
}
