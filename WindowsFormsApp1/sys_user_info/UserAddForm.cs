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
using WindowsFormsApp1.helper;

namespace WindowsFormsApp1.sys_user_info
{
    public partial class UserAddForm : Form
    {
        private User DataUserInfo = new User();
        private BindingList<Dept> deptComboList = new BindingList<Dept>();

        public bool UserInsertFg { get; private set; } = false;

        private void InitEvent()
        {
            this.Load += UserAdd_Load;
            this.KeyDown += UserAddForm_KeyDown;
            selectDeptCd.SelectionChangeCommitted += SelectDeptCd_SelectionChangeCommitted;
            txtRemarkDc.KeyDown += TxtRemarkDc_KeyDown;
            chkUserGender1.CheckedChanged += ChkUserGender1_CheckedChanged;
            chkUserGender2.CheckedChanged += ChkUserGender2_CheckedChanged;

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
            selectDeptCd.DisplayMember = nameof(Dept.DeptCd);
            selectDeptCd.ValueMember = nameof(Dept.Id);
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
        }

        private void ChkUserGender1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUserGender1.Checked) chkUserGender2.Checked = false;
        }

        private void ChkUserGender2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUserGender2.Checked) chkUserGender1.Checked = false;
        }

        private void BtnAct_Click(object sender, EventArgs e)
        {
            UserReg();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            UserClose();
        }

        private void TxtRemarkDc_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    UserReg();
                    break;

                default:
                    break;
            }
        }

        //public void ResetForm()
        //{
        //    selectDeptCd.SelectedIndex = -1;
        //    txtDeptName.Text = string.Empty;

        //    txtUserId.Text = string.Empty;
        //    txtUserName.Text = string.Empty;
        //    txtUserLoginId.Text = string.Empty;
        //    txtUserPass.Text = string.Empty;
        //    txtUserRank.Text = string.Empty;
        //    txtUserEmpType.Text = string.Empty;
        //    txtUserTel.Text = string.Empty;
        //    txtUserEmail.Text = string.Empty;
        //    txtUserMessengerId.Text = string.Empty;
        //    txtRemarkDc.Text = string.Empty;

        //    chkUserGender1.Checked = false;
        //    chkUserGender2.Checked = false;

        //    DataUserInfo.IdDept = 0;

        //    this.ActiveControl = selectDeptCd;
        //}

        private void UserReg()
        {
            if (selectDeptCd.SelectedIndex < 0)
            {
                MessageBox.Show("부서코드가 입력되지 않았습니다.");
                selectDeptCd.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtUserId.Text.Trim()))
            {
                MessageBox.Show("사원코드가 입력되지 않았습니다.");
                txtUserId.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                MessageBox.Show("사원명이 입력되지 않았습니다.");
                txtUserName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtUserLoginId.Text.Trim()))
            {
                MessageBox.Show("로그인ID가 입력되지 않았습니다.");
                txtUserLoginId.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtUserPass.Text.Trim()))
            {
                MessageBox.Show("비밀번호가 입력되지 않았습니다.");
                txtUserPass.Focus();
                return;
            }

            // 비밀번호 유효성 검사
            if (!Validator.ValidatePassword(txtUserPass.Text.Trim()))
            {
                MessageBox.Show("비밀번호는 최소 8자리 이상이어야 하며, 영어와 숫자를 포함해야 합니다.");
                txtUserPass.Focus();
                return;
            }

            // 이메일 유효성 검사
            if (!string.IsNullOrEmpty(txtUserEmail.Text.Trim()) && !Validator.ValidateEmail(txtUserEmail.Text.Trim()))
            {
                MessageBox.Show("올바른 이메일 형식이 아닙니다.");
                txtUserEmail.Focus();
                return;
            }

            DataUserInfo.IdDept = Convert.ToInt32(selectDeptCd.SelectedValue);
            DataUserInfo.UserId = txtUserId.Text.Trim();
            DataUserInfo.UserName = txtUserName.Text.Trim();
            DataUserInfo.UserLoginId = txtUserLoginId.Text.Trim();
            DataUserInfo.UserPass = txtUserPass.Text.Trim();
            DataUserInfo.UserRank = txtUserRank.Text.Trim();
            DataUserInfo.UserEmpType = txtUserEmpType.Text.Trim();
            DataUserInfo.UserGender = chkUserGender1.Checked ? User.Gender.Male : chkUserGender2.Checked ? User.Gender.FeMale : User.Gender.None;
            DataUserInfo.UserTel = txtUserTel.Text.Trim();
            DataUserInfo.UserEmail = txtUserEmail.Text.Trim();
            DataUserInfo.UserMessengerId = txtUserMessengerId.Text.Trim();
            DataUserInfo.RemarkDc = txtRemarkDc.Text.Trim();

            int result = ConnDatabase.Instance.AddUser(DataUserInfo);

            switch (result)
            {
                case int n when n > 0:
                    UserInsertFg = true;
                    MessageBox.Show("저장되었습니다.");
                    this.Close();
                    break;

                case -1:
                    MessageBox.Show("이미 존재하는 사원코드 입니다.");
                    txtUserId.Focus();
                    break;

                case -2:
                    MessageBox.Show("이미 존재하는 로그인ID 입니다.");
                    txtUserLoginId.Focus();
                    break;

                case -3:
                    MessageBox.Show("저장 중 오류가 발생했습니다.");
                    break;

                default:
                    MessageBox.Show("저장에 실패했습니다.");
                    break;
            }
        }

        private void UserClose()
        {
            UserInsertFg = false;
            this.Close();
        }
    }
}
