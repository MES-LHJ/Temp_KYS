using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WindowsFormsApp1.helper;

namespace WindowsFormsApp1.api
{
    public class ApiDeptRepository
    {
        private static ApiDeptRepository _instance;
        public static ApiDeptRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ApiDeptRepository();
                return _instance;
            }
        }

        private readonly HttpClient _httpClient;

        private ApiDeptRepository()
        {
            _httpClient = ApiHelper.Instance.Client;
        }

        // 부서 조회
        public async Task<ApiResponse<List<Dept>>> GetDept(int factoryId)
        {
            var url = $"http://test.smartqapis.com:5000/api/Department?factoryId={factoryId}";
            var response = await _httpClient.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<ApiResponse<List<Dept>>>(json);
            if (!response.IsSuccessStatusCode || result == null)
                throw new Exception($"부서 목록 조회 실패: {json}");

            return result;
        }

        // 부서 추가
        public async Task<ApiResponse<long>> AddDept(Dept dept)
        {
            var url = "http://test.smartqapis.com:5000/api/Department";
            var data = new
            {
                Name = dept.DeptName,
                Code = dept.DeptCd,
                Memo = dept.RemarkDc,
                FactoryId = 1,
                UpperDepartmentId = ""
            };

            var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            var json = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<ApiResponse<long>>(json);
            if (!response.IsSuccessStatusCode || result == null)
                throw new Exception($"부서 추가 실패: {json}");

            return result;
        }

        // 부서 수정
        public async Task<ApiResult> UpdateDept(Dept dept)
        {
            var url = $"http://test.smartqapis.com:5000/api/Department/{dept.Id}";
            var data = new
            {
                Name = dept.DeptName,
                Code = dept.DeptCd,
                Memo = dept.RemarkDc,
                FactoryId = 1,
                UpperDepartmentId = ""
            };

            var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, content);
            var json = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<ApiResult>(json);
            if (!response.IsSuccessStatusCode || result == null || !result.IsSuccess)
                throw new Exception($"부서 수정 실패: {json}");

            return result;
        }

        // 부서 삭제
        public async Task<ApiResult> DeleteDept(long departmentId)
        {
            var url = $"http://test.smartqapis.com:5000/api/Department/{departmentId}";
            var response = await _httpClient.DeleteAsync(url);
            var json = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<ApiResult>(json);
            if (!response.IsSuccessStatusCode || result == null || !result.IsSuccess)
                throw new Exception($"부서 삭제 실패: {json}");

            return result;
        }
    }
}
