using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.sys_user_info
{
    public partial class UserUpdateForm : Form
    {
        private List<CmnDeptCombo> comboList = new List<CmnDeptCombo>();

        public UserUpdateForm()
        {
            InitializeComponent();
        }

        private void BtnAct_Click(object sender, EventArgs e)
        {
            string userId = txtUserId.Text.ToString();
            string userName = txtUserName.Text.ToString();

            MessageBox.Show(userId + " " + userName);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            UserInfoForm userInfoForm = new UserInfoForm();

            this.Close();
            userInfoForm.Show();
        }

        private void UserUpdateForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // 저장(F4)
                case Keys.F4:
                    BtnAct_Click(sender, e);
                    break;

                // 닫기(ESC)
                case Keys.Escape:
                    BtnCancel_Click(sender, e);
                    break;

                default:
                    break;
            }
        }
    }
}
