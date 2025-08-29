using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.helper;

namespace WindowsFormsApp1.sys_user_info
{
    public partial class UserUpdateForm : Form
    {
        private List<Dept> deptComboList = new List<Dept>();
        private User dataUserInfo = new User();

        public bool UserUpdateFg { get; private set; } = false;

        private readonly int id;
        private string oldFileName = "";
        private string saveFileName = "";
        private bool imageUpdateFg = false;

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
                   chkUserGender2.Checked ? User.Gender.FeMale : User.Gender.None;
            set
            {
                chkUserGender1.Checked = value == User.Gender.Male;
                chkUserGender2.Checked = value == User.Gender.FeMale;
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

        public UserUpdateForm(int id)
        {
            this.id = id;
            InitializeComponent();
            InitEvent();
        }

        // ------------
        // 이벤트 정의
        // ------------

        // 폼 Load 이벤트
        private void UserUpdate_Load(object sender, EventArgs e)
        {
            UserSetData();
        }

        // 폼 KeyDown 이벤트
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
                    UserUpdateCheck();
                    break;

                default:
                    break;
            }
        }

        // 저장 버튼 클릭 이벤트
        private void BtnAct_Click(object sender, EventArgs e)
        {
            UserUpdateCheck();
        }

        // 닫기 버튼 클릭 이벤트
        private void BtnClose_Click(object sender, EventArgs e)
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
                    imageUpdateFg = true;
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
                    imageUpdateFg = true;
                }
            }
        }

        // ------------
        // 메서드 정의
        // ------------

        // 사원 데이터 SET
        private void UserSetData()
        {

            dataUserInfo = UserRepository.Instance.GetUserById(id);

            if (dataUserInfo == null)
            {
                MessageBox.Show("해당 사원 정보를 찾을 수 없습니다.");
                this.Close();
            }
            else
            {
                UserIdText = dataUserInfo.UserId;
                UserNameText = dataUserInfo.UserName;
                UserRankText = dataUserInfo.UserRank;
                UserEmpTypeText = dataUserInfo.UserEmpType;
                SelectedGender = dataUserInfo.UserGender;
                UserTelText = dataUserInfo.UserTel;
                UserEmailText = dataUserInfo.UserEmail;
                UserMessengerIdText = dataUserInfo.UserMessengerId;
                RemarkDcText = dataUserInfo.RemarkDc;

                oldFileName = dataUserInfo.UserImage;
                saveFileName = dataUserInfo.UserImage;
            }

            // 콤보박스 리스트
            deptComboList = DeptRepository.Instance.GetDept();

            selectDeptCd.DataSource = deptComboList;
            selectDeptCd.DisplayMember = nameof(Dept.DeptCd);
            selectDeptCd.ValueMember = nameof(Dept.Id);

            SelectedDeptCd = dataUserInfo.IdDept;
            DeptNameText = dataUserInfo.DeptName;

            // 이미지 파일 체크
            if (!string.IsNullOrEmpty(dataUserInfo.UserImage))
            {
                string imagePath = dataUserInfo.UserImage;

                if (File.Exists(imagePath))  // 파일이 실제로 있는지 체크
                {
                    using (var img = Image.FromFile(imagePath))
                    {
                        UserImage = new Bitmap(img);
                    }
                }
                else
                {
                    Debug.WriteLine("이미지 파일이 존재하지 않음: " + imagePath);
                    UserImage = null;
                }
            }
            else
            {
                UserImage = null;
            }
        }

        // 수정된 데이터 존재 여부 체크
        private void UserUpdateCheck()
        {
            bool fieldUpdateFg = false;

            if (SelectedDeptCd != dataUserInfo.IdDept) fieldUpdateFg = true;
            if (!fieldUpdateFg && UserIdText != dataUserInfo.UserId) fieldUpdateFg = true;
            if (!fieldUpdateFg && UserNameText != dataUserInfo.UserName) fieldUpdateFg = true;
            if (!fieldUpdateFg && UserRankText != dataUserInfo.UserRank) fieldUpdateFg = true;
            if (!fieldUpdateFg && UserEmpTypeText != dataUserInfo.UserEmpType) fieldUpdateFg = true;
            if (!fieldUpdateFg && SelectedGender != dataUserInfo.UserGender) fieldUpdateFg = true;
            if (!fieldUpdateFg && UserTelText != dataUserInfo.UserTel) fieldUpdateFg = true;
            if (!fieldUpdateFg && UserEmailText != dataUserInfo.UserEmail) fieldUpdateFg = true;
            if (!fieldUpdateFg && UserMessengerIdText != dataUserInfo.UserMessengerId) fieldUpdateFg = true;
            if (!fieldUpdateFg && RemarkDcText != dataUserInfo.RemarkDc) fieldUpdateFg = true;

            // 이미지 변경 여부 체크
            if (!fieldUpdateFg && imageUpdateFg) fieldUpdateFg = true;

            if (!fieldUpdateFg)
            {
                MessageBox.Show("수정된 데이터가 없습니다.");
                return;
            }

            UserReg();
        }

        // 사원 저장
        private void UserReg()
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

            // 이메일 유효성 검사
            if (!string.IsNullOrEmpty(UserEmailText) && !Validator.ValidateEmail(UserEmailText))
            {
                MessageBox.Show("올바른 이메일 형식이 아닙니다.");
                txtUserEmail.Focus();
                return;
            }

            if (MessageBox.Show("저장하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string savePath = UserFileConfig.GetUserImagePath(id, saveFileName);

                dataUserInfo.IdDept = SelectedDeptCd;
                dataUserInfo.UserId = UserIdText;
                dataUserInfo.UserName = UserNameText;
                dataUserInfo.UserRank = UserRankText;
                dataUserInfo.UserEmpType = UserEmpTypeText;
                dataUserInfo.UserGender = SelectedGender;
                dataUserInfo.UserTel = UserTelText;
                dataUserInfo.UserEmail = UserEmailText;
                dataUserInfo.UserMessengerId = UserMessengerIdText;
                dataUserInfo.RemarkDc = RemarkDcText;
                dataUserInfo.UserImage = (UserImage != null) ? savePath : "";

                int result = UserRepository.Instance.UpdateUser(dataUserInfo);

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

        // 사원 이미지 업데이트
        private void UserImageUpdate()
        {
            // 기존 등록된 이미지가 존재하는 경우 삭제
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
                    Debug.WriteLine($"기존 파일 삭제 중 예기치 않은 오류 발생: {deleteEx.Message}");
                }
            }

            // 이미지 업로드
            if (UserImage != null)
            {
                try
                {
                    string savePath = UserFileConfig.SaveUserImage(UserImage, id, saveFileName);

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
            UserUpdateFg = false;
            this.Close();
        }
    }
}
