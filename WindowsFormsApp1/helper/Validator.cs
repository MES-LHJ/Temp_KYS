using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.helper
{
    public class Validator
    {
        // 비밀번호: 최소 8자리, 영어+숫자 포함
        public static bool ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return false;
            var regex = new System.Text.RegularExpressions.Regex(@"^(?=.*[A-Za-z])(?=.*\d).{8,}$");
            return regex.IsMatch(password);
        }

        // 이메일: 일반 형식 체크
        public static bool ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;
            var regex = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

            return regex.IsMatch(email);
        }
    }
}
