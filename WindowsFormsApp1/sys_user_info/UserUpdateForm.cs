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
        private BindingList<Dept> deptComboList = new BindingList<Dept>();
        private User DataUserInfo = new User();

        public void SetData(User user)
        {
            DataUserInfo = user;
            if (DataUserInfo != null)
            {
                txtUserId.Text = DataUserInfo.UserId;
                txtUserName.Text = DataUserInfo.UserName;
                txtUserRank.Text = DataUserInfo.UserRank;
                txtUserEmpType.Text = DataUserInfo.UserEmpType;
                chkUserGender1.Checked = DataUserInfo.UserGender == "M";
                chkUserGender2.Checked = DataUserInfo.UserGender == "F";
                txtUserTel.Text = DataUserInfo.UserTel;
                txtUserEmail.Text = DataUserInfo.UserEmail;
                txtUserMessengerId.Text = DataUserInfo.UserMessengerId;
                txtRemarkDc.Text = DataUserInfo.RemarkDc;
            }

            this.ActiveControl = txtUserId;
        }

        private void InitEvent()
        {
            this.Load += UserUpdate_Load;
            this.KeyDown += UserUpdateForm_KeyDown;
            selectDeptCd.SelectionChangeCommitted += SelectDeptCd_SelectionChangeCommitted;
            chkUserGender1.CheckedChanged += ChkUserGender1_CheckedChanged;
            chkUserGender2.CheckedChanged += ChkUserGender2_CheckedChanged;
            txtRemarkDc.KeyDown += TxtRemarkDc_KeyDown;
            btnAct.Click += BtnAct_Click;
            btnClose.Click += BtnClose_Click;
        }

        public UserUpdateForm(User user)
        {
            InitializeComponent();
            SetData(user);
            InitEvent();
        }

        private void UserUpdate_Load(object sender, EventArgs e)
        {
            deptComboList = ConnDatabase.Instance.GetDept();

            selectDeptCd.DataSource = deptComboList;
            selectDeptCd.DisplayMember = "DeptCd";
            selectDeptCd.ValueMember = "Id";
            selectDeptCd.SelectedValue = DataUserInfo.IdDept;
            txtDeptName.Text = DataUserInfo.DeptName;
        }

        private void UserUpdateForm_KeyDown(object sender, KeyEventArgs e)
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

        private void ChkUserGender1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUserGender1.Checked) chkUserGender2.Checked = false;
        }

        private void ChkUserGender2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUserGender2.Checked) chkUserGender1.Checked = false;
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

        private void BtnAct_Click(object sender, EventArgs e)
        {
            UserReg();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            UserClose();
        }

        private void UserReg()
        {
            if (DataUserInfo.IdDept == 0)
            {
                MessageBox.Show("부서코드가 입력되지 않았습니다.");
                selectDeptCd.Focus();
                return;
            }

            DataUserInfo.Id = DataUserInfo.Id;
            DataUserInfo.IdDept = DataUserInfo.IdDept;
            DataUserInfo.UserId = txtUserId.Text.Trim();
            DataUserInfo.UserName = txtUserName.Text.Trim();
            DataUserInfo.UserRank = txtUserRank.Text.Trim();
            DataUserInfo.UserEmpType = txtUserEmpType.Text.Trim();
            DataUserInfo.UserGender = chkUserGender1.Checked ? "M" : chkUserGender2.Checked ? "F" : "";
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

            // 이메일 유효성 검사
            if (!string.IsNullOrEmpty(DataUserInfo.UserEmail) && !Validator.ValidateEmail(DataUserInfo.UserEmail))
            {
                MessageBox.Show("올바른 이메일 형식이 아닙니다.");
                txtUserEmail.Focus();
                return;
            }

            int result = ConnDatabase.Instance.UpdateUser(DataUserInfo);

            switch (result)
            {
                case int n when n > 0:
                    MessageBox.Show("저장되었습니다.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;

                case -1:
                    MessageBox.Show("이미 존재하는 사원코드 입니다.");
                    txtUserId.Focus();
                    break;

                case -2:
                    MessageBox.Show("저장 중 오류가 발생했습니다.");
                    break;

                default:
                    MessageBox.Show("저장에 실패했습니다.");
                    break;
            }
        }

        private void UserClose()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
