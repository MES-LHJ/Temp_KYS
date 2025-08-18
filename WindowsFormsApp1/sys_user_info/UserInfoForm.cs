using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.sys_user_info;

namespace WindowsFormsApp1
{
    public partial class UserInfoForm : Form
    {
        private BindingList<User> userList;

        private void InitEvents()
        {
            this.KeyDown += UserInfoForm_KeyDown;

            btnDept.Click += BtnDept_Click;
            btnSrch.Click += BtnSrch_Click;
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnLoginInfo.Click += BtnLoginInfo_Click;
            btnDelete.Click += BtnDelete_Click;
            btnChange.Click += BtnChange_Click;
            btnClose.Click += BtnClose_Click;

            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            dataGridView1.KeyDown += DataGridView1_KeyDown;
        }

        public UserInfoForm()
        {
            InitializeComponent();
            InitEvents();
        }

        private void BtnDept_Click(object sender, EventArgs e)
        {
            DeptInfoLoad();
        }

        private void BtnSrch_Click(object sender, EventArgs e)
        {
            UserSrch();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            UserAddLoad();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            UserUpdateLoad();
        }

        private void BtnLoginInfo_Click(object sender, EventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            UserDelete();
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            UserClose();
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var data = sender as DataGridView;

            var cell = data.Rows[e.RowIndex].Cells["UserPass"];
            cell.Value = "**********";
            e.FormattingApplied = true;
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UserUpdateLoad();
        }

        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // 추가(F1)
                case Keys.Enter:
                    UserAddLoad();
                    e.SuppressKeyPress = true;
                    break;

                default:
                    break;
            }
        }

        private void UserInfoForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // 추가(F1)
                case Keys.F1:
                    UserAddLoad();
                    break;

                // 조회(F2)
                case Keys.F2:
                    UserSrch();
                    break;

                // 삭제(F7)
                case Keys.F7:
                    UserDelete();
                    break;

                // 닫기(ESC)
                case Keys.Escape:
                    UserClose();
                    break;

                default:
                    break;
            }
        }

        public void DeptInfoLoad()
        {
            var deptInfoForm = FormManager.Instance.GetDeptInfoForm();
            deptInfoForm.ShowDialog();
            UserSrch();
        }

        private void UserSrch()
        {
            userList = ConnDatabase.Instance.GetUser();
            dataGridView1.DataSource = userList;
        }

        public void UserAddLoad()
        {
            var userAddForm = FormManager.Instance.GetUserAddForm();
            if (userAddForm.ShowDialog() == DialogResult.OK)
            {
                UserSrch();
            }
        }

        public void UserUpdateLoad()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("선택된 데이터가 없습니다.");
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];

            var user = new User
            {
                Id = Convert.ToInt32(row.Cells["Id"].Value),
                UserId = row.Cells["UserId"].Value?.ToString(),
                UserName = row.Cells["UserName"].Value?.ToString(),
                UserRank = row.Cells["UserRank"].Value?.ToString(),
                UserEmpType = row.Cells["UserEmpType"].Value?.ToString(),
                UserTel = row.Cells["UserTel"].Value?.ToString(),
                UserEmail = row.Cells["UserEmail"].Value?.ToString(),
                UserMessengerId = row.Cells["UserMessengerId"].Value?.ToString(),
                RemarkDc = row.Cells["RemarkDc"].Value?.ToString(),
                IdDept = Convert.ToInt32(row.Cells["IdDept"].Value),
                DeptCd = row.Cells["DeptCd"].Value?.ToString(),
                DeptName = row.Cells["DeptName"].Value?.ToString()
            };

            var userUpdateForm = FormManager.Instance.GetUserUpdateForm(user);
            if (userUpdateForm.ShowDialog() == DialogResult.OK)
            {
                UserSrch();
            }
        }

        public void UserDelete()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("선택된 데이터가 없습니다.");
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];

            var user = new User
            {
                Id = Convert.ToInt32(row.Cells["Id"].Value),
                UserId = row.Cells["UserId"].Value?.ToString(),
                UserName = row.Cells["UserName"].Value?.ToString()
            };

            if (MessageBox.Show($"사원코드: {user.UserId}\n사원명: {user.UserName}\n\n삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int result = ConnDatabase.Instance.DeleteUser(user.Id);

                if (result > 0)
                {
                    MessageBox.Show($"사원코드: {user.UserId}\n사원명: {user.UserName}\n\n데이터가 삭제되었습니다.");
                    UserSrch();
                }
                else if (result == -2)
                {
                    MessageBox.Show("삭제 중 오류가 발생했습니다.");
                }
                else
                {
                    MessageBox.Show("삭제에 실패했습니다");
                }
            }
        }

        public void UserClose()
        {
            this.Close();
            FormManager.Instance.GetIndexForm().Show();
        }
    }
}
