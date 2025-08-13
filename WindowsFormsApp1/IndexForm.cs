using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class IndexForm : Form
    {
        public IndexForm()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            LoginCheck();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtUserPass_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    LoginCheck();
                    break;

                default:
                    break;
            }
        }
        
        private void LoginCheck()
        {
            string userId = txtUserId.Text;
            string userPass = txtUserPass.Text;

            ConnDatabase db = new ConnDatabase();
            db.Open();

            string sql = "select * from sys_user_info where user_id = \'" + userId + "\'" +
                " and user_pass = \'" + userPass + "\'";

            DataSet ds = db.GetDataSet(sql);

            db.Close();

            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("로그인 정보가 일치하지 않습니다.");
                return;
            }

            UserInfoForm userInfoForm = new UserInfoForm();

            this.Hide();
            userInfoForm.Show();
        }
    }
}
