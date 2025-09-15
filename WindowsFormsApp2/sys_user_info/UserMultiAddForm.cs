using DevExpress.Spreadsheet;
using DevExpress.Utils.Extensions;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.helper;
using DevExpress.XtraEditors;

namespace WindowsFormsApp2.sys_user_info
{
    public partial class UserMultiAddForm : XtraForm
    {
        private List<User> userList = new List<User>();
        private List<Dept> deptList = new List<Dept>();
        private List<string> errorList = new List<string>();

        public bool UserMultiInsertFg { get; private set; } = false;

        // 이벤트 핸들러
        private void InitEvent()
        {
            this.Load += UserMultiAddForm_Load;

            btnAct.Click += BtnAct_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        public UserMultiAddForm()
        {
            InitializeComponent();
            InitEvent();
        }

        // ------------
        // 이벤트 정의
        // ------------

        // 폼 Load 이벤트
        private void UserMultiAddForm_Load(object sender, EventArgs e)
        {
            SheetSet();
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

        // ------------
        // 메서드 정의
        // ------------

        // Sheet Set
        private void SheetSet()
        {
            var workbook = spreadsheetControl1.Document;
            var sheet = workbook.Worksheets[0];
            var headerDict = UserMultiAdd.ColumnInfo;
            int col = 0;

            sheet.Name = "사원추가";
            // 1. 컬럼헤더 입력 & 스타일 (각 셀별 적용)
            foreach (var kvp in headerDict)
            {
                var cell = sheet.Cells[0, col];
                cell.Value = kvp.Value;

                var style = workbook.Styles.Add("HeaderStyle_" + col);

                cell.ColumnWidthInCharacters = 10;
                
                switch (kvp.Key)
                {
                    case nameof(User.DeptCd):
                    case nameof(User.UserId):
                    case nameof(User.UserName):
                    case nameof(User.UserLoginId):
                    case nameof(User.UserPass):
                        style.Font.Color = System.Drawing.Color.OrangeRed;
                        break;

                    default:
                        style.Font.Color = System.Drawing.Color.Black;
                        break;
                }
                
                style.Fill.BackgroundColor = System.Drawing.Color.LightBlue;
                style.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
                style.Borders.SetAllBorders(System.Drawing.Color.Black, BorderLineStyle.Thin);
                cell.Style = style;
                
                col++;
            }
            sheet.FreezeRows(0);
        }

        // 사원 저장
        private void UserReg()
         {
            var sheet = spreadsheetControl1.Document.Worksheets[0];
            var column = UserMultiAdd.ColumnInfo;
            int rowCount = sheet.GetDataRange().RowCount;

            userList.Clear();
            errorList.Clear();

            // 부서 전체 목록
            deptList = DeptRepository.Instance.GetDept();

            for (int row=1; row<rowCount; row++)
            {
                var user = new User();
                bool isDataEmpty = true;
                int colIndex = 0;

                // 빈행인지 확인 (셀에 값이 하나라도 있으면 isDataEmpty = false)
                foreach (var kvp in column)
                {
                    var cell = sheet.Cells[row, colIndex];
                    string value = cell.Value == null ? "" : cell.Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(value))
                    {
                        isDataEmpty = false;
                        break;
                    }
                    colIndex++;
                }

                if (isDataEmpty)
                    continue;

                colIndex = 0;

                // 필수 필드 입력 확인, 유효성 검사, 값 할당
                foreach (var kvp in column)
                {
                    var cell = sheet.Cells[row, colIndex];
                    string value = cell.Value == null ? "" : cell.Value.ToString().Trim();

                    if ((kvp.Key == nameof(User.DeptCd) ||
                         kvp.Key == nameof(User.UserId) ||
                         kvp.Key == nameof(User.UserName) ||
                         kvp.Key == nameof(User.UserLoginId) ||
                         kvp.Key == nameof(User.UserPass)) && string.IsNullOrEmpty(value))
                    {
                        errorList.Add($"{row + 1}행 [{kvp.Value}] 필수 필드가 입력되지 않았습니다.");
                    }
                    
                    // 부서코드 존재여부 확인
                    if (kvp.Key == nameof(User.DeptCd) && !string.IsNullOrEmpty(value))
                    {
                        var dept = deptList.FirstOrDefault(d => d.DeptCd == value);
                        if (dept != null)
                        {
                            user.IdDept = dept.Id;
                        }
                        else
                        {
                            errorList.Add($"{row + 1}행 [부서코드] 해당하는 부서가 존재하지 않습니다.");
                        }
                    }

                    // 비밀번호 체크
                    if (kvp.Key == nameof(User.UserPass) && !string.IsNullOrEmpty(value) && !Validator.ValidatePassword(value))
                        errorList.Add($"{row + 1}행 [비밀번호] 최소 8자리 이상이어야 하며, 영어와 숫자를 포함해야 합니다.");

                    // 이메일 체크
                    if (kvp.Key == nameof(User.UserEmail) && !string.IsNullOrEmpty(value) && !Validator.ValidateEmail(value))
                        errorList.Add($"{row + 1}행 [이메일] 올바른 형식이 아닙니다.");

                    switch (kvp.Key)
                    {
                        case nameof(User.DeptCd): user.DeptCd = value; break;
                        case nameof(User.UserId): user.UserId = value; break;
                        case nameof(User.UserName): user.UserName = value; break;
                        case nameof(User.UserLoginId): user.UserLoginId = value; break;
                        case nameof(User.UserPass): user.UserPass = value; break;
                        case nameof(User.UserRank): user.UserRank = value; break;
                        case nameof(User.UserEmpType): user.UserEmpType = value; break;
                        case nameof(User.UserTel): user.UserTel = value; break;
                        case nameof(User.UserEmail): user.UserEmail = value; break;
                        case nameof(User.UserMessengerId): user.UserMessengerId = value; break;
                        case nameof(User.RemarkDc): user.RemarkDc = value; break;
                    }

                    colIndex++;

                }

                if (errorList.Count == 0)
                {
                    userList.Add(user);
                }
            }

            // errorList 하나라도 존재하면 저장 불가
            if (errorList.Count > 0)
            {
                int maxErrorCount = 20;
                string message;

                if (errorList.Count > maxErrorCount)
                {
                    var previewErrors = errorList.Take(maxErrorCount).ToList();
                    int remainCount = errorList.Count - maxErrorCount;

                    previewErrors.Add($"[ 그 외 {remainCount}건 ]");
                    message = string.Join("\n", previewErrors);
                }
                else
                {
                    message = string.Join("\n", errorList);
                }

                MessageBox.Show(message);
                return;
            }

            if (userList.Count == 0)
            {
                MessageBox.Show("입력된 데이터가 없습니다.");
                return;
            }

            // 저장 처리
            if (MessageBox.Show("저장하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int successCount = 0, userIdCount = 0, loginIdCount = 0, failCount = 0;

                foreach (var user in userList)
                {
                    int result = UserRepository.Instance.AddUser(user);
                    switch (result)
                    {
                        case int n when n > 0:
                            successCount++;
                            break;

                        case -1:
                            userIdCount++;
                            break;

                        case -2:
                            loginIdCount++;
                            break;

                        default:
                            failCount++;
                            break;
                    }
                }

                if (successCount > 0)
                {
                    UserMultiInsertFg = true;
                }

                MessageBox.Show($"저장: {successCount}건\n사원코드중복: {userIdCount}건\n로그인ID중복: {loginIdCount}건\n기타오류: {failCount}건");
                this.Close();
            }
        }
        
        // 폼 닫기
        private void UserClose()
        {
            UserMultiInsertFg = false;
            this.Close();
        }
    }
}
