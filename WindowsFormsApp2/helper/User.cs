using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.helper
{
    public class User
    {
        public enum Gender
        {
            None = 0, Male = 1, FeMale = 2
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string UserPass { get; set; }

        public string UserLoginId { get; set; }

        public string UserRank { get; set; }

        public string UserEmpType { get; set; }

        public Gender UserGender { get; set; } = Gender.None;

        public string UserTel { get; set; }

        public string UserEmail { get; set; }

        public string UserMessengerId { get; set; }

        public string RemarkDc { get; set; }

        public string UserImage { get; set; } = "";

        public int IdDept { get; set; }

        public string DeptCd { get; set; }

        public string DeptName { get; set; }
    }
}
