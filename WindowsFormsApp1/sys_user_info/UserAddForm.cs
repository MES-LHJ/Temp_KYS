using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WindowsFormsApp1.api;
using WindowsFormsApp1.helper;

namespace WindowsFormsApp1.sys_user_info
{
    public partial class UserAddForm : Form
    {
        private User dataUserInfo = new User();
        private List<Dept> deptComboList = new List<Dept>();

        private int saveId = 0;
        private string saveFileName = "";

        public bool UserInsertFg { get; private set; } = false;

        //-----------
        // 속성 설정
        //-----------

        // 부서코드
        public int SelectedDeptCd
        {
            get => selectDeptCd.SelectedIndex >= 0 ? Convert.ToInt32(selectDeptCd.SelectedValue) : -1;
            set => selectDeptCd.SelectedValue = value;
        }

        // 부서명
        public string DeptNameText
        {
            get => txtDeptName.Text.Trim();
            set => txtDeptName.Text = value;
        }

        // 사원코드
        public string UserIdText
        {
            get => txtUserId.Text.Trim();
            set => txtUserId.Text = value;
        }

        // 사원명
        public string UserNameText
        {
            get => txtUserName.Text.Trim();
            set => txtUserName.Text = value;
        }
        
        // 로그인ID
        public string UserLoginIdText
        {
            get => txtUserLoginId.Text.Trim();
            set => txtUserLoginId.Text = value;
        }

        // 비밀번호
        public string UserPassText
        {
            get => txtUserPass.Text.Trim();
            set => txtUserPass.Text = value;
        }

        // 직위
        public string UserRankText
        {
            get => txtUserRank.Text.Trim();
            set => txtUserRank.Text = value;
        }

        // 고용형태
        public string UserEmpTypeText
        {
            get => txtUserEmpType.Text.Trim();
            set => txtUserEmpType.Text = value;
        }

        // 성별
        public User.Gender SelectedGender
        {
            get => chkUserGender1.Checked ? User.Gender.Male :
                   chkUserGender2.Checked ? User.Gender.Female : User.Gender.None;
            set
            {
                chkUserGender1.Checked = value == User.Gender.Male;
                chkUserGender2.Checked = value == User.Gender.Female;
            }
        }

        // 휴대전화
        public string UserTelText
        {
            get => txtUserTel.Text.Trim();
            set => txtUserTel.Text = value;
        }

        // 이메일
        public string UserEmailText
        {
            get => txtUserEmail.Text.Trim();
            set => txtUserEmail.Text = value;
        }

        // 메신저ID
        public string UserMessengerIdText
        {
            get => txtUserMessengerId.Text.Trim();
            set => txtUserMessengerId.Text = value;
        }

        // 메모
        public string RemarkDcText
        {
            get => txtRemarkDc.Text.Trim();
            set => txtRemarkDc.Text = value;
        }

        // 이미지
        public Image UserImage
        {
            get => userImage.Image;
            set
            {
                userImage.Image = value;
                userImage.Invalidate();  // 이미지 변경 후 새로 그리기
            }
        }

        // 이벤트 핸들러
        private void InitEvent()
        {
            this.Load += UserAdd_Load;
            this.KeyDown += UserAddForm_KeyDown;
            selectDeptCd.SelectionChangeCommitted += SelectDeptCd_SelectionChangeCommitted;
            chkUserGender1.CheckedChanged += ChkUserGender1_CheckedChanged;
            chkUserGender2.CheckedChanged += ChkUserGender2_CheckedChanged;
            txtRemarkDc.KeyDown += TxtRemarkDc_KeyDown;

            btnAct.Click += BtnAct_Click;
            btnCancel.Click += BtnCancel_Click;

            userImage.Paint += UserImage_Paint;
            userImage.Click += UserImage_Click;
            btnClearImage.Click += BtnClearImage_Click;
        }

        public UserAddForm()
        {
            InitializeComponent();
            InitEvent();
        }

        // ------------
        // 이벤트 정의
        // ------------

        // 폼 Load 이벤트
        private async void UserAdd_Load(object sender, EventArgs e)
        {
            try
            {
                var result = await ApiDeptRepository.Instance.GetDept(1);

                if (!string.IsNullOrEmpty(result.Error))
                {
                    MessageBox.Show($"부서 조회 실패: {result.Error}");
                    return;
                }
                deptComboList = result.Data;

                selectDeptCd.DataSource = deptComboList;
                selectDeptCd.DisplayMember = nameof(Dept.DeptCd);
                selectDeptCd.ValueMember = nameof(Dept.Id);
                selectDeptCd.SelectedIndex = -1;
                DeptNameText = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"부서 조회 중 오류가 발생했습니다.\n{ex.Message}");
            }

            // 콤보박스 리스트
            //deptComboList = DeptRepository.Instance.GetDept();

            //selectDeptCd.DataSource = deptComboList;
            //selectDeptCd.DisplayMember = nameof(Dept.DeptCd);
            //selectDeptCd.ValueMember = nameof(Dept.Id);
            //selectDeptCd.SelectedIndex = -1;
            //DeptNameText = "";
        }

        // 폼 KeyDown 이벤트
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

        // 부서코드 combobox selectChange 이벤트
        private void SelectDeptCd_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Dept selectedDept = (Dept)selectDeptCd.SelectedItem;
            DeptNameText = selectedDept.DeptName;
        }

        // 성별 체크박스 남자 체크 이벤트
        private void ChkUserGender1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUserGender1.Checked) chkUserGender2.Checked = false;
        }

        // 성별 체크박스 여자 체크 이벤트
        private void ChkUserGender2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUserGender2.Checked) chkUserGender1.Checked = false;
        }

        // input 비고 KeyDown 이벤트
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

        // 저장 버튼 클릭 이벤트
        private void BtnAct_Click(object sender, EventArgs e)
        {
            UserReg();
        }

        // 취소 버튼 클릭 이벤트
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            UserClose();
        }

        // 이미지 추가 Paint 이벤트
        private void UserImage_Paint(object sender, PaintEventArgs e)
        {
            if (UserImage == null)
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

        // 이미지 추가 클릭 이벤트
        private void UserImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "이미지 파일|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "이미지 선택";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    UserImage = Image.FromFile(ofd.FileName);
                    saveFileName = Path.GetFileName(ofd.FileName);
                }
            }
        }

        // 이미지 비우기 버튼 클릭 이벤트
        private void BtnClearImage_Click(object sender, EventArgs e)
        {
            if (UserImage != null)
            {
                if (MessageBox.Show("이미지를 비우시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    UserImage.Dispose();
                    UserImage = null;
                }
            }
        }

        // ------------
        // 메서드 정의
        // ------------

        // 사원 저장
        private async void UserReg()
        {
            if (SelectedDeptCd < 0)
            {
                MessageBox.Show("부서코드가 입력되지 않았습니다.");
                selectDeptCd.Focus();
                return;
            }

            if (string.IsNullOrEmpty(UserIdText))
            {
                MessageBox.Show("사원코드가 입력되지 않았습니다.");
                txtUserId.Focus();
                return;
            }

            if (string.IsNullOrEmpty(UserNameText))
            {
                MessageBox.Show("사원명이 입력되지 않았습니다.");
                txtUserName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(UserLoginIdText))
            {
                MessageBox.Show("로그인ID가 입력되지 않았습니다.");
                txtUserLoginId.Focus();
                return;
            }

            if (string.IsNullOrEmpty(UserPassText))
            {
                MessageBox.Show("비밀번호가 입력되지 않았습니다.");
                txtUserPass.Focus();
                return;
            }

            // 비밀번호 유효성 검사
            if (!Validator.ValidatePassword(UserPassText))
            {
                MessageBox.Show("비밀번호는 최소 8자리 이상이어야 하며, 영어와 숫자를 포함해야 합니다.");
                txtUserPass.Focus();
                return;
            }

            // 이메일 유효성 검사
            if (!string.IsNullOrEmpty(UserEmailText) && !Validator.ValidateEmail(UserEmailText))
            {
                MessageBox.Show("올바른 이메일 형식이 아닙니다.");
                txtUserEmail.Focus();
                return;
            }

            if (MessageBox.Show("저장하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dataUserInfo.IdDept = SelectedDeptCd;
                dataUserInfo.UserId = UserIdText;
                dataUserInfo.UserName = UserNameText;
                dataUserInfo.UserLoginId = UserLoginIdText;
                dataUserInfo.UserPass = UserPassText;
                dataUserInfo.UserRank = UserRankText;
                dataUserInfo.UserEmpType = UserEmpTypeText;
                dataUserInfo.UserGender = SelectedGender;
                dataUserInfo.UserTel = UserTelText;
                dataUserInfo.UserEmail = UserEmailText;
                dataUserInfo.UserMessengerId = UserMessengerIdText;
                dataUserInfo.RemarkDc = RemarkDcText;

                try
                {
                    var result = await ApiUserRepository.Instance.AddUser(dataUserInfo);

                    if (!string.IsNullOrEmpty(result.Error))
                    {
                        
                        MessageBox.Show($"사원 추가 실패: {result.Error}");
                        return;
                    }

                    UserInsertFg = true;
                    MessageBox.Show("저장되었습니다.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"사원 추가 중 오류가 발생했습니다.\n{ex.Message}");
                    txtUserId.Focus();
                }

                //int result = UserRepository.Instance.AddUser(dataUserInfo);

                //switch (result)
                //{
                //    case int n when n > 0:
                //        saveId = result;
                //        UserInsertFg = true;
                //        UserImageUpdate();

                //        MessageBox.Show("저장되었습니다.");
                //        this.Close();
                //        break;

                //    case -1:
                //        MessageBox.Show("이미 존재하는 사원코드 입니다.");
                //        txtUserId.Focus();
                //        break;

                //    case -2:
                //        MessageBox.Show("이미 존재하는 로그인ID 입니다.");
                //        txtUserLoginId.Focus();
                //        break;

                //    case -3:
                //        MessageBox.Show("저장 중 오류가 발생했습니다.");
                //        break;

                //    default:
                //        MessageBox.Show("저장에 실패했습니다.");
                //        break;
                //}
            }
        }

        // 사원 이미지 업로드
        private void UserImageUpdate()
        {
            if (UserImage != null)
            {
                try
                {
                    string savePath = UserFileConfig.Instance.SaveUserImage(UserImage, saveId, saveFileName);

                    UserRepository.Instance.UpdateUserImage(saveId, savePath);

                    Debug.WriteLine("이미지가 저장되었습니다: " + savePath);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("이미지 저장 중 오류: " + ex.Message);
                }
            }
        }

        // 폼 닫기
        private void UserClose()
        {
            UserInsertFg = false;
            this.Close();
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
    }
}
