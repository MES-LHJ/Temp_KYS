using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.helper
{
    public class UserTree
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int IdDept { get; set; }
        public string DeptCd { get; set; }
        public string DeptName { get; set; }
        public int IdUpperDept { get; set; }
        public string UpperDeptCd { get; set; }
        public string UpperDeptName { get; set; }

        public string ID { get; set; }
        public string ParentID { get; set; }
    }
}
