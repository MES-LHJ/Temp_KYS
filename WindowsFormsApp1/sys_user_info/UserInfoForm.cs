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
            //btn_srch_Click(sender, e);
        }

        private void BtnDept_Click(object sender, EventArgs e)
        {
            DeptInfoForm show_dept_Info = new DeptInfoForm();
            show_dept_Info.Show();



        }

        private void btn_srch_Click(object sender, EventArgs e)
        {
            ConnDatabase db = new ConnDatabase();
            db.Open();

            string sql = "select dept_cd, dept_name, user_id, user_name, user_login_id, user_pass, " +
                "user_rank, user_emp_type, user_tel, user_email, user_messenger_id, t1.remark_dc " +
                "from sys_user_info t1 inner join sys_dept_info t2 on t1.id_dept = t2.id " +
                "where user_id <> \'master\' order by user_id, user_name";
            
            DataSet ds = db.GetDataSet(sql);
            dataGridView1.DataSource = ds.Tables[0];
            
            db.Close();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            UserAddForm show_user_add = new UserAddForm();
            show_user_add.Show();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.RowCount == 0) 
            {
                MessageBox.Show("선택된 데이터가 없습니다.");
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];

            string user_id = row.Cells[2].Value.ToString();
            string user_name = row.Cells[3].Value.ToString();

            UserUpdateForm show_user_update = new UserUpdateForm();

            show_user_update.input_user_id.Text = user_id;
            show_user_update.input_user_name.Text = user_name;
            
            show_user_update.Show();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.RowCount == 0)
            {
                MessageBox.Show("선택된 데이터가 없습니다.");
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];

            string user_id = row.Cells[2].Value.ToString();
            string user_name = row.Cells[3].Value.ToString();

            MessageBox.Show("사원코드: " + user_id + ", 사원명: " + user_name);
        }

        private void btn_change_Click(object sender, EventArgs e)
        {

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            IndexForm indexForm = new IndexForm();
            indexForm.Show();
            this.Visible = false;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                e.Value = "**********";
                e.FormattingApplied = true;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_update_Click(sender, e);
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // 추가(F1)
                case Keys.Enter:
                    btn_update_Click(sender, e);
                    e.SuppressKeyPress = true;
                    break;

                default:
                    break;
            }
        }
        private void user_info_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // 추가(F1)
                case Keys.F1:
                    btn_add_Click(sender, e);
                    break;

                // 조회(F2)
                case Keys.F2:
                    btn_srch_Click(sender, e);
                    break;

                // 삭제(F7)
                case Keys.F7:
                    btn_delete_Click(sender, e);
                    break;

                // 닫기(ESC)
                case Keys.Escape:
                    btn_close_Click(sender, e);
                    break;

                default:
                    break;
            }
        }
    }
}
