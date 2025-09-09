using DevExpress.XtraEditors;
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
using WindowsFormsApp2.helper;

namespace WindowsFormsApp2.sys_user_info
{
    public partial class UserAddForm : Form
    {
        private User dataUserInfo = new User();
        private List<UpperDept> upperDeptComboList = new List<UpperDept>();
        private List<Dept> deptComboList = new List<Dept>();

        private int saveId = 0;
        private string saveFileName = "";

        public bool UserInsertFg { get; private set; } = false;

        //-----------
        // 속성 설정
        //-----------

        // 상위부서코드
        public int SelectedUpperDeptCd
        {
            get => selectUpperDeptCd.ItemIndex >= 0 ? Convert.ToInt32(selectUpperDeptCd.EditValue) : -1;
            set => selectUpperDeptCd.EditValue = value;
        }

        // 상위부서명
        public string UpperDeptNameText
        {
            get => txtUpperDeptName.Text.Trim();
            set => txtUpperDeptName.Text = value;
        }

        // 부서코드
        public int SelectedDeptCd
        {
            get => selectDeptCd.ItemIndex >= 0 ? Convert.ToInt32(selectDeptCd.EditValue) : -1;
            set => selectDeptCd.EditValue = value;
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
            selectUpperDeptCd.EditValueChanged += SelectUpperDeptCd_EditValueChanged;
            selectDeptCd.EditValueChanged += SelectDeptCd_EditValueChanged;
            chkUserGender1.CheckedChanged += ChkUserGender1_CheckedChanged;
            chkUserGender2.CheckedChanged += ChkUserGender2_CheckedChanged;

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
        private void UserAdd_Load(object sender, EventArgs e)
        {
            SelectUpperDeptList();
        }

        // 상위부서코드 EditValueChange 이벤트
        private void SelectUpperDeptCd_EditValueChanged(object sender, EventArgs e)
        {
            int selectedId = Convert.ToInt32(selectUpperDeptCd.EditValue);
            var selectedUpperDept = upperDeptComboList.FirstOrDefault(x => x.Id.Equals(selectedId));

            txtUpperDeptName.Text = selectedUpperDept != null ? selectedUpperDept.UpperDeptName : "";


            SelectDeptList(selectedId);
        }

        // 부서코드 EditValueChange 이벤트
        private void SelectDeptCd_EditValueChanged(object sender, EventArgs e)
        {
            int selectedId = Convert.ToInt32(selectDeptCd.EditValue);
            var selectedDept = deptComboList.FirstOrDefault(x => x.Id.Equals(selectedId));

            txtDeptName.Text = selectedDept != null ? selectedDept.DeptName : "";
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
                Font font = new Font("Tahoma", 12, FontStyle.Bold);
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

        // 상위부서 리스트
        private void SelectUpperDeptList()
        {
            upperDeptComboList = UpperDeptRepository.Instance.GetUpperDept();

            selectUpperDeptCd.Properties.DataSource = upperDeptComboList;
            selectUpperDeptCd.Properties.DisplayMember = nameof(UpperDept.UpperDeptCd);
            selectUpperDeptCd.Properties.ValueMember = nameof(UpperDept.Id);

            selectUpperDeptCd.Properties.Columns.Clear();
            selectUpperDeptCd.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(nameof(UpperDept.UpperDeptCd), "상위부서코드", 70));
            selectUpperDeptCd.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(nameof(UpperDept.UpperDeptName), "상위부서명", 120));
            selectUpperDeptCd.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(nameof(UpperDept.Id)) { Visible = false });

            selectUpperDeptCd.EditValue = null;
            DeptNameText = "";
        }

        // 하위부서 리스트
        private void SelectDeptList(int selectedId)
        {
            List<Dept> allDeptList = DeptRepository.Instance.GetDept();

            deptComboList = allDeptList
                .Where(d => d.IdUpperDept == selectedId)
                .OrderBy(d => d.DeptCd)
                .ToList();

            selectDeptCd.Properties.DataSource = deptComboList;
            selectDeptCd.Properties.DisplayMember = nameof(Dept.DeptCd);
            selectDeptCd.Properties.ValueMember = nameof(Dept.Id);

            selectDeptCd.Properties.Columns.Clear();
            selectDeptCd.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(nameof(Dept.DeptCd), "부서코드", 70));
            selectDeptCd.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(nameof(Dept.DeptName), "부서명", 120));
            selectDeptCd.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(nameof(Dept.Id)) { Visible = false });

            selectDeptCd.EditValue = null; // 선택 초기화
        }

        // 사원 저장
        private void UserReg()
        {
            if (SelectedUpperDeptCd < 0)
            {
                MessageBox.Show("상위부서코드가 입력되지 않았습니다.");
                selectUpperDeptCd.Focus();
                return;
            }

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

                int result = UserRepository.Instance.AddUser(dataUserInfo);

                switch (result)
                {
                    case int n when n > 0:
                        saveId = result;
                        UserInsertFg = true;
                        UserImageUpdate();

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
    }
}
