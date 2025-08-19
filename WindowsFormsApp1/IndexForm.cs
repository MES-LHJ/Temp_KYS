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
        private void InitEvents()
        {
            txtUserPass.KeyDown += TxtUserPass_KeyDown;

            btnLogin.Click += BtnLogin_Click;
            btnClose.Click += BtnClose_Click;
        }

        public IndexForm()
        {
            InitializeComponent();
            InitEvents();
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

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            LoginCheck();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginCheck()
        {
            User LoginUser = new User
            {
                UserLoginId = txtUserLoginId.Text,
                UserPass = txtUserPass.Text
            };

            User loginUser = ConnDatabase.Instance.LoginAct(LoginUser);

            if (loginUser != null)
            {
                FormManager.Instance.GetUserInfoForm().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("로그인 정보가 일치하지 않습니다.");
            }
        }
    }
}
