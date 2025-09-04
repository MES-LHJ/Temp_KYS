using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.helper;

namespace WindowsFormsApp2
{
    public partial class IndexForm : Form
    {
        public bool LoginSuccess { get; private set; } = false;

        // 이벤트 핸들러
        private void InitEvents()
        {
            btnLogin.Click += BtnLogin_Click;
            btnClose.Click += BtnClose_Click;
        }

        public IndexForm()
        {
            InitializeComponent();
            InitEvents();
        }

        // ------------
        // 이벤트 정의
        // ------------

        // 로그인 버튼 클릭 이벤트
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            LoginCheck();
        }

        // 닫기 버튼 클릭 이벤트
        private void BtnClose_Click(object sender, EventArgs e)
        {
            IndexClose();
        }

        // ------------
        // 메서드 정의
        // ------------

        // 로그인 정보 체크
        private void LoginCheck()
        {
            User LoginUser = new User
            {
                UserLoginId = txtUserLoginId.Text,
                UserPass = txtUserPass.Text
            };

            User loginUser = UserRepository.Instance.LoginAct(LoginUser);

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

        // 폼 닫기
        public void IndexClose()
        {
            LoginSuccess = false;
            this.Close();
        }
    }
}

