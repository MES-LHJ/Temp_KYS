using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WindowsFormsApp1.api
{
    public class ApiResponse<T>
    {
        [JsonPropertyName("Data")]
        public T Data { get; set; }

        [JsonPropertyName("Error")]
        public String Error { get; set; }
    }
}
