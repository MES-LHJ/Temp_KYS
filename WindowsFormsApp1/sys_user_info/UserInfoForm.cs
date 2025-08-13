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
        public UserInfoForm()
        {
            InitializeComponent();
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            //UserSrch();
        }

        private void BtnDept_Click(object sender, EventArgs e)
        {
            DeptInfoForm deptInfoForm = new DeptInfoForm();
            this.Close();
            deptInfoForm.Show();
        }

        private void BtnSrch_Click(object sender, EventArgs e)
        {
            UserSrch();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            UserAddForm userAddForm = new UserAddForm();
            this.Close();
            userAddForm.Show();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.RowCount == 0) 
            {
                MessageBox.Show("선택된 데이터가 없습니다.");
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];

            string userId = row.Cells["user_id"].Value?.ToString();
            string userName = row.Cells["user_name"].Value?.ToString();

            UserUpdateForm userUpdateForm = new UserUpdateForm();

            userUpdateForm.txtUserId.Text = userId;
            userUpdateForm.txtUserName.Text = userName;

            this.Close();
            userUpdateForm.Show();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.RowCount == 0)
            {
                MessageBox.Show("선택된 데이터가 없습니다.");
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];

            string userId = row.Cells["user_id"].Value?.ToString();
            string userName = row.Cells["user_name"].Value?.ToString();

            MessageBox.Show("사원코드: " + userId + ", 사원명: " + userName);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            IndexForm indexForm = new IndexForm();
            this.Close();
            indexForm.Show();
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                e.Value = "**********";
                e.FormattingApplied = true;
            }
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnUpdate_Click(sender, e);
        }

        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // 추가(F1)
                case Keys.Enter:
                    BtnUpdate_Click(sender, e);
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
                    BtnAdd_Click(sender, e);
                    break;

                // 조회(F2)
                case Keys.F2:
                    UserSrch();
                    break;

                // 삭제(F7)
                case Keys.F7:
                    BtnDelete_Click(sender, e);
                    break;

                // 닫기(ESC)
                case Keys.Escape:
                    BtnClose_Click(sender, e);
                    break;

                default:
                    break;
            }
        }

        private void UserSrch()
        {
            ConnDatabase db = new ConnDatabase();
            db.Open();

            string sql = "select dept_cd, dept_name, user_id, user_name, user_login_id, user_pass, " +
                "user_rank, user_emp_type, user_tel, user_email, user_messenger_id, t1.remark_dc " +
                "from sys_user_info t1 inner join sys_dept_info t2 on t1.id_dept = t2.id " +
                "where user_id <> 'master' order by user_id, user_name";
            Debug.WriteLine(sql);
            DataSet ds = db.GetDataSet(sql);
            dataGridView1.DataSource = ds.Tables[0];

            db.Close();
        }
    }
}
