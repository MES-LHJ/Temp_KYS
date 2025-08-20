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
using WindowsFormsApp1.helper;
using WindowsFormsApp1.sys_user_info;

namespace WindowsFormsApp1
{
    public partial class IndexForm : Form
    {
        public bool LoginSuccess { get; private set; } = false;

        private void InitEvents()
        {
            this.KeyDown += IndexForm_KeyDown;
            txtUserPass.KeyDown += TxtUserPass_KeyDown;
            btnLogin.Click += BtnLogin_Click;
            btnClose.Click += BtnClose_Click;
        }

        public IndexForm()
        {
            InitializeComponent();
            InitEvents();
        }

        private void IndexForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.SelectNextControl(this.ActiveControl, true, true, true, false);
                    break;

                // 닫기(ESC)
                case Keys.Escape:
                    IndexClose();
                    break;

                default:
                    break;
            }
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
            IndexClose();
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
                LoginSuccess = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("로그인 정보가 일치하지 않습니다.");
                txtUserLoginId.Focus();
            }
        }
        
        public void IndexClose()
        {
            LoginSuccess = false;
            this.Close();
        }
    }
}
