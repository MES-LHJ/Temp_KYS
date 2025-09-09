using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.helper
{
    public static class DeptExcelConfig
    {
        public static readonly Dictionary<string, string> ColumnInfo = new Dictionary<string, string>()
        {
            { nameof(UpperDept.UpperDeptCd), "부서코드" },
            { nameof(UpperDept.UpperDeptName), "부서명" },
            { nameof(UpperDept.UpperRemarkDc), "비고" }
        };
    }
}
