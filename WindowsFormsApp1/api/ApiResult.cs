using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WindowsFormsApp1.api
{
    public class ApiResult
    {
        [JsonPropertyName("IsSuccess")]
        public bool IsSuccess { get; set; }

        [JsonPropertyName("Error")]
        public string Error { get; set; }
    }
}
