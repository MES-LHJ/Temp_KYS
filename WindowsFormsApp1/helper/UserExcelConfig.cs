using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.helper
{
    public static class UserExcelConfig
    {
        public static readonly Dictionary<string, string> ColumnInfo = new Dictionary<string, string>()
        {
            { nameof(User.DeptCd), "부서코드" },
            { nameof(User.DeptName), "부서명" },
            { nameof(User.UserId), "사원코드" },
            { nameof(User.UserName), "사원명" },
            { nameof(User.UserLoginId), "로그인ID" },
            { nameof(User.UserPass), "비밀번호" },
            { nameof(User.UserRank), "직위" },
            { nameof(User.UserEmpType), "고용형태" },
            { nameof(User.UserTel), "휴대전화" },
            { nameof(User.UserEmail), "이메일" },
            { nameof(User.UserMessengerId), "메신저ID" },
            { nameof(User.RemarkDc), "메모" }
        };
    }
}
