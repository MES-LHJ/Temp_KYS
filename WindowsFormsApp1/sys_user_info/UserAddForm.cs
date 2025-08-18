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
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class UserAddForm : Form
    {
        private User DataUserInfo = new User();
        private BindingList<Dept> deptComboList = new BindingList<Dept>();


        private void InitEvent()
        {
            this.Load += UserAdd_Load;
            this.KeyDown += UserAddForm_KeyDown;
            selectDeptCd.SelectionChangeCommitted += SelectDeptCd_SelectionChangeCommitted;

            btnAct.Click += BtnAct_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        public UserAddForm()
        {
            InitializeComponent();
            InitEvent();
        }

        private void UserAdd_Load(object sender, EventArgs e)
        {
            deptComboList = ConnDatabase.Instance.GetDept();

            selectDeptCd.DataSource = deptComboList;
            selectDeptCd.DisplayMember = "DeptCd";
            selectDeptCd.ValueMember = "Id";
            selectDeptCd.SelectedIndex = -1;
            txtDeptName.Text = "";
        }

        private void UserAddForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // 엔터키
                case Keys.Enter:
                    this.SelectNextControl(this.ActiveControl, true, true, true, false);
                    break;

                // 저장(F4)
                case Keys.F4:
                    UserReg();
                    break;

                // 닫기(ESC)
                case Keys.Escape:
                    UserClose();
                    break;

                default:
                    break;
            }
        }

        private void SelectDeptCd_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Dept selectedDept = (Dept)selectDeptCd.SelectedItem;
            txtDeptName.Text = selectedDept.DeptName;

            DataUserInfo.IdDept = selectedDept.Id;
        }

        private void BtnAct_Click(object sender, EventArgs e)
        {
            UserReg();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            UserClose();
        }

        public void ResetForm()
        {
            selectDeptCd.SelectedIndex = -1;
            txtDeptName.Text = string.Empty;

            txtUserId.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtUserLoginId.Text = string.Empty;
            txtUserPass.Text = string.Empty;
            txtUserRank.Text = string.Empty;
            txtUserEmpType.Text = string.Empty;
            txtUserTel.Text = string.Empty;
            txtUserEmail.Text = string.Empty;
            txtUserMessengerId.Text = string.Empty;
            txtRemarkDc.Text = string.Empty;

            DataUserInfo.IdDept = 0;

            this.ActiveControl = selectDeptCd;
        }

        private void UserReg()
        {
            if (DataUserInfo.IdDept == 0)
            {
                MessageBox.Show("부서코드가 입력되지 않았습니다.");
                selectDeptCd.Focus();
                return;
            }

            DataUserInfo.UserId = txtUserId.Text.Trim();
            DataUserInfo.UserName = txtUserName.Text.Trim();
            DataUserInfo.UserLoginId = txtUserLoginId.Text.Trim();
            DataUserInfo.UserPass = txtUserPass.Text.Trim();
            DataUserInfo.UserRank = txtUserRank.Text.Trim();
            DataUserInfo.UserEmpType = txtUserEmpType.Text.Trim();
            DataUserInfo.UserTel = txtUserTel.Text.Trim();
            DataUserInfo.UserEmail = txtUserEmail.Text.Trim();
            DataUserInfo.UserMessengerId = txtUserMessengerId.Text.Trim();
            DataUserInfo.RemarkDc = txtRemarkDc.Text.Trim();

            if (string.IsNullOrEmpty(DataUserInfo.UserId))
            {
                MessageBox.Show("사원코드가 입력되지 않았습니다.");
                txtUserId.Focus();
                return;
            }

            if (string.IsNullOrEmpty(DataUserInfo.UserName))
            {
                MessageBox.Show("사원명이 입력되지 않았습니다.");
                txtUserName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(DataUserInfo.UserLoginId))
            {
                MessageBox.Show("로그인ID가 입력되지 않았습니다.");
                txtUserLoginId.Focus();
                return;
            }

            if (string.IsNullOrEmpty(DataUserInfo.UserPass))
            {
                MessageBox.Show("비밀번호가 입력되지 않았습니다.");
                txtUserPass.Focus();
                return;
            }

            int result = ConnDatabase.Instance.AddUser(DataUserInfo);

            if (result > 0)
            {
                MessageBox.Show("저장되었습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (result == -1)
            {
                MessageBox.Show("이미 존재하는 사원코드 입니다.");
                txtUserId.Focus();
            }
            else if (result == -2)
            {
                MessageBox.Show("이미 존재하는 로그인ID 입니다.");
                txtUserLoginId.Focus();
            }
            else if (result == -3)
            {
                MessageBox.Show("저장 중 오류가 발생했습니다.");
            }
            else
            {
                MessageBox.Show("저장에 실패했습니다.");
            }
        }

        private void UserClose()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
