using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WindowsFormsApp1.helper
{
    public class Dept
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Code")]
        public string DeptCd { get; set; }
        [JsonPropertyName("Name")]
        public string DeptName { get; set; }
        [JsonPropertyName("Memo")]
        public string RemarkDc { get; set; }
    }
}
