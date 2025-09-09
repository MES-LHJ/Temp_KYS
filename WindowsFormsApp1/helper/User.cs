using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WindowsFormsApp1.helper
{
    public class User
    {
        public enum Gender
        {
            None = 0, Male = 1, Female = 2
        }

        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Code")]
        public string UserId { get; set; }
        [JsonPropertyName("Name")]
        public string UserName { get; set; }
        [JsonPropertyName("LoginPassword")]
        public string UserPass { get; set; }
        [JsonPropertyName("LoginId")]
        public string UserLoginId { get; set; }
        [JsonPropertyName("Position")]
        public string UserRank { get; set; }
        [JsonPropertyName("ContractType")]
        public string UserEmpType { get; set; }
        public Gender UserGender { get; set; } = Gender.None;
        [JsonPropertyName("PhoneNumber")]
        public string UserTel { get; set; }
        [JsonPropertyName("Email")]
        public string UserEmail { get; set; }
        [JsonPropertyName("MessengerId")]
        public string UserMessengerId { get; set; }
        [JsonPropertyName("Memo")]
        public string RemarkDc { get; set; }
        public string UserImage { get; set; } = "";
        [JsonPropertyName("DepartmentId")]
        public int IdDept { get; set; }
        [JsonPropertyName("DepartmentCode")]
        public string DeptCd { get; set; }
        [JsonPropertyName("DepartmentName")]
        public string DeptName { get; set; }
    }
}
