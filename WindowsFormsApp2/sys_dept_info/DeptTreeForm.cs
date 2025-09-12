using DevExpress.Spreadsheet;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.helper;

namespace WindowsFormsApp2.sys_dept_info
{
    public partial class DeptTreeForm : XtraForm
    {
        private List<User> userList = new List<User>();
        private List<Dept> deptList = new List<Dept>();
        private List<UpperDept> upperDeptList = new List<UpperDept>();
        private List<UserTree> treeData = new List<UserTree>();

        // 이벤트 핸들러
        private void InitEvent()
        {
            this.Load += DeptTreeForm_Load;
        }

        public DeptTreeForm()
        {
            InitializeComponent();
            InitEvent();
        }

        // ------------
        // 이벤트 정의
        // ------------

        // 폼 Load 이벤트
        private void DeptTreeForm_Load(object sender, EventArgs e)
        {
            TreeSetData();
        }

        // ------------
        // 메서드 정의
        // ------------

        // Tree Set
        private void TreeSetData()
        {
            upperDeptList = UpperDeptRepository.Instance.GetUpperDept();
            deptList = DeptRepository.Instance.GetDept();
            userList = UserRepository.Instance.GetUser();

            string upperDeptChar = "UD";
            string deptChar = "D";
            string userChar = "U";

            // 상위부서
            foreach (var upperDept in upperDeptList)
            {
                treeData.Add(new UserTree
                {
                    Id = 0,
                    UserId = "",
                    UserName = "",
                    IdDept = 0,
                    DeptCd = "",
                    DeptName = "",
                    IdUpperDept = upperDept.Id,
                    UpperDeptCd = upperDept.UpperDeptCd,
                    UpperDeptName = upperDept.UpperDeptName,
                    ID = upperDeptChar + upperDept.Id,
                    ParentID = ""
                });
            }

            // 하위부서
            foreach (var dept in deptList)
            {
                treeData.Add(new UserTree
                {
                    Id = 0,
                    UserId = "",
                    UserName = "",
                    IdDept = dept.Id,
                    DeptCd = dept.DeptCd,
                    DeptName = dept.DeptName,
                    IdUpperDept = 0,
                    UpperDeptCd = "",
                    UpperDeptName = "",
                    ID = deptChar + dept.Id,
                    ParentID = upperDeptChar + dept.IdUpperDept
                });
            }

            // 사원
            foreach (var user in userList)
            {
                treeData.Add(new UserTree
                {
                    Id = user.Id,
                    UserId = user.UserId,
                    UserName = user.UserName,
                    IdDept = 0,
                    DeptCd = "",
                    DeptName = "",
                    IdUpperDept = 0,
                    UpperDeptCd = "",
                    UpperDeptName = "",
                    ID = userChar + user.Id,
                    ParentID = deptChar + user.IdDept
                });
            }

            treeList1.DataSource = treeData;
            treeList1.KeyFieldName = "ID";
            treeList1.ParentFieldName = "ParentID";
        }
    }
}