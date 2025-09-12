using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.helper
{
    public static class DeptExcelConfig
    {
        public static readonly Dictionary<string, string> ColumnInfo = new  Dictionary<string, string>()
        {
            { nameof(Dept.DeptCd), "부서코드" },
            { nameof(Dept.DeptName), "부서명" },
            { nameof(Dept.RemarkDc), "메모" }
        };
    }
}
