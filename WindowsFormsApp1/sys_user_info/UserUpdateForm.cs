using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.helper;

namespace WindowsFormsApp1.sys_user_info
{
    public partial class UserUpdateForm : Form
    {
        private BindingList<Dept> deptComboList = new BindingList<Dept>();
        private User DataUserInfo = new User();

        public bool UserUpdateFg { get; private set; } = false;

        private bool imageUpdateFg = false;
        private string oldFileName = "";
        private string saveFileName = "";
        

        public void SetData(User user)
        {
            DataUserInfo = user;
            if (DataUserInfo != null)
            {
                txtUserId.Text = DataUserInfo.UserId;
                txtUserName.Text = DataUserInfo.UserName;
                txtUserRank.Text = DataUserInfo.UserRank;
                txtUserEmpType.Text = DataUserInfo.UserEmpType;
                chkUserGender1.Checked = DataUserInfo.UserGender == User.Gender.Male;
                chkUserGender2.Checked = DataUserInfo.UserGender == User.Gender.FeMale;
                txtUserTel.Text = DataUserInfo.UserTel;
                txtUserEmail.Text = DataUserInfo.UserEmail;
                txtUserMessengerId.Text = DataUserInfo.UserMessengerId;
                txtRemarkDc.Text = DataUserInfo.RemarkDc;

                oldFileName = DataUserInfo.UserImage;
            }

            this.ActiveControl = selectDeptCd;
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

            userImage.Paint += UserImage_Paint;
            userImage.Click += UserImage_Click;
            btnClearImage.Click += BtnClearImage_Click;
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
            selectDeptCd.DisplayMember = nameof(Dept.DeptCd);
            selectDeptCd.ValueMember = nameof(Dept.Id);
            selectDeptCd.SelectedValue = DataUserInfo.IdDept;
            txtDeptName.Text = DataUserInfo.DeptName;

            // 이미지 파일 체크
            if (!string.IsNullOrEmpty(DataUserInfo.UserImage))
            {
                string imagePath = DataUserInfo.UserImage.Trim();

                if (File.Exists(imagePath))  // 파일이 실제로 있는지 체크
                {
                    using (var img = Image.FromFile(imagePath))
                    {
                        userImage.Image = new Bitmap(img);
                    }
                }
                else
                {
                    Debug.WriteLine("이미지 파일이 존재하지 않음: " + imagePath);
                    userImage.Image = null;
                }
            }
            else
            {
                userImage.Image = null;
            }
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
                    UserUpdateCheck();
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

        private void TxtRemarkDc_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    UserUpdateCheck();
                    break;

                default:
                    break;
            }
        }

        private void BtnAct_Click(object sender, EventArgs e)
        {
            UserUpdateCheck();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            UserClose();
        }

        private void UserImage_Paint(object sender, PaintEventArgs e)
        {
            if (userImage.Image == null)
            {
                string text = "이미지 추가";
                Font font = new Font("굴림", 12, FontStyle.Bold);
                Brush brush = Brushes.Gray;

                SizeF textSize = e.Graphics.MeasureString(text, font);
                float x = (userImage.Width - textSize.Width) / 2;
                float y = (userImage.Height - textSize.Height) / 2;

                e.Graphics.DrawString(text, font, brush, x, y);
            }
        }

        private void UserImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "이미지 파일|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "이미지 선택";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    userImage.Image = Image.FromFile(ofd.FileName);
                    saveFileName = Path.GetFileName(ofd.FileName);
                    userImage.Invalidate();
                    imageUpdateFg = true;
                }
            }
        }

        private void BtnClearImage_Click(object sender, EventArgs e)
        {
            if (userImage.Image != null)
            {
                if (MessageBox.Show("이미지를 비우시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    userImage.Image.Dispose();
                    userImage.Image = null;
                    userImage.Invalidate();
                    imageUpdateFg = true;
                }
            }
        }

        private void UserUpdateCheck()
        {
            bool fieldUpdateFg = false;

            if (Convert.ToInt32(selectDeptCd.SelectedValue) != DataUserInfo.IdDept) fieldUpdateFg = true;
            if (!fieldUpdateFg && txtUserId.Text.Trim() != DataUserInfo.UserId) fieldUpdateFg = true;
            if (!fieldUpdateFg && txtUserName.Text.Trim() != DataUserInfo.UserName) fieldUpdateFg = true;
            if (!fieldUpdateFg && txtUserRank.Text.Trim() != DataUserInfo.UserRank) fieldUpdateFg = true;
            if (!fieldUpdateFg && txtUserEmpType.Text.Trim() != DataUserInfo.UserEmpType) fieldUpdateFg = true;

            User.Gender currentGender = chkUserGender1.Checked ? User.Gender.Male : chkUserGender2.Checked ? User.Gender.FeMale : User.Gender.None;
            if (!fieldUpdateFg && currentGender != DataUserInfo.UserGender) fieldUpdateFg = true;
            if (!fieldUpdateFg && txtUserTel.Text.Trim() != DataUserInfo.UserTel) fieldUpdateFg = true;
            if (!fieldUpdateFg && txtUserEmail.Text.Trim() != DataUserInfo.UserEmail) fieldUpdateFg = true;
            if (!fieldUpdateFg && txtUserMessengerId.Text.Trim() != DataUserInfo.UserMessengerId) fieldUpdateFg = true;
            if (!fieldUpdateFg && txtRemarkDc.Text.Trim() != DataUserInfo.RemarkDc) fieldUpdateFg = true;

            // 이미지 변경 여부 체크
            if (!fieldUpdateFg && imageUpdateFg) fieldUpdateFg = true;

            if (!fieldUpdateFg)
            {
                MessageBox.Show("수정된 데이터가 없습니다.");
                return;
            }

            UserReg();
        }

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

            // 이메일 유효성 검사
            if (!string.IsNullOrEmpty(txtUserEmail.Text.Trim()) && !Validator.ValidateEmail(txtUserEmail.Text.Trim()))
            {
                MessageBox.Show("올바른 이메일 형식이 아닙니다.");
                txtUserEmail.Focus();
                return;
            }

            if (MessageBox.Show("저장하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string targetFolder = $"D:\\Nas\\UserInfo\\{DataUserInfo.Id}";
                string savePath = Path.Combine(targetFolder, saveFileName);

                DataUserInfo.IdDept = Convert.ToInt32(selectDeptCd.SelectedValue);
                DataUserInfo.UserId = txtUserId.Text.Trim();
                DataUserInfo.UserName = txtUserName.Text.Trim();
                DataUserInfo.UserRank = txtUserRank.Text.Trim();
                DataUserInfo.UserEmpType = txtUserEmpType.Text.Trim();
                DataUserInfo.UserGender = chkUserGender1.Checked ? User.Gender.Male : chkUserGender2.Checked ? User.Gender.FeMale : User.Gender.None;
                DataUserInfo.UserTel = txtUserTel.Text.Trim();
                DataUserInfo.UserEmail = txtUserEmail.Text.Trim();
                DataUserInfo.UserMessengerId = txtUserMessengerId.Text.Trim();
                DataUserInfo.RemarkDc = txtRemarkDc.Text.Trim();
                DataUserInfo.UserImage = (userImage.Image != null) ? savePath : "";

                int result = ConnDatabase.Instance.UpdateUser(DataUserInfo);

                switch (result)
                {
                    case int n when n > 0:
                        UserUpdateFg = true;

                        if (imageUpdateFg)
                        {
                            UserImageUpdate();
                        }

                        MessageBox.Show("저장되었습니다.");
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
        }

        private void UserImageUpdate()
        {
            if (!string.IsNullOrEmpty(oldFileName) && File.Exists(oldFileName))
            {
                try
                {
                    File.Delete(oldFileName);
                }
                catch (IOException ioEx)
                {
                    Debug.WriteLine($"기존 파일 삭제 중 오류 (다른 프로그램에서 사용 중일 수 있습니다): {ioEx.Message}");
                }
                catch (Exception deleteEx)
                {
                    MessageBox.Show($"기존 파일 삭제 중 예기치 않은 오류 발생: {deleteEx.Message}");
                }
            }

            if (userImage.Image != null)
            {
                try
                {
                    string targetFolder = $"D:\\Nas\\UserInfo\\{DataUserInfo.Id}";
                    string savePath = Path.Combine(targetFolder, saveFileName);

                    if (!Directory.Exists(targetFolder))
                    {
                        Directory.CreateDirectory(targetFolder);
                    }

                    using (var bmp = new Bitmap(userImage.Image))
                    {
                        bmp.Save(savePath);
                    }

                    //MessageBox.Show("이미지가 저장되었습니다: " + savePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("이미지 저장 중 오류가 발생했습니다: " + ex.Message);
                }
            }
        }

        private void UserClose()
        {
            UserUpdateFg = false;
            this.Close();
        }
    }
}
