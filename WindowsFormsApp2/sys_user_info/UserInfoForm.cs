using DevExpress.ClipboardSource.SpreadsheetML;
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
using WindowsFormsApp2.helper;
using WindowsFormsApp2.sys_dept_info;
using ClosedXML;
using ClosedXML.Excel;

namespace WindowsFormsApp2.sys_user_info
{
    public partial class UserInfoForm : Form
    {
        private List<User> userList;

        // 이벤트 핸들러
        private void InitEvents()
        {
            this.Load += UserInfoForm_Load;

            btnDept.Click += BtnDept_Click;
            btnSrch.Click += BtnSrch_Click;
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnLoginInfo.Click += BtnLoginInfo_Click;
            btnDelete.Click += BtnDelete_Click;
            btnChange.Click += BtnChange_Click;
            btnClose.Click += BtnClose_Click;

            masterGridView.CustomColumnDisplayText += MasterGridView_CustomColumnDisplayText;
        }

        public UserInfoForm()
        {
            InitializeComponent();
            InitEvents();
        }

        // ------------
        // 이벤트 정의
        // ------------

        // 폼 Load 이벤트
        public void UserInfoForm_Load(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                IndexForm indexForm = new IndexForm();
                indexForm.ShowDialog();

                if (!indexForm.LoginSuccess)
                {
                    this.Close();
                }
            });
        }

        // 부서 버튼 클릭 이벤트
        private void BtnDept_Click(object sender, EventArgs e)
        {
            DeptInfoLoad();
        }

        // 조회 버튼 클릭 이벤트
        private void BtnSrch_Click(object sender, EventArgs e)
        {
            UserSrch();
        }

        // 추가 버튼 클릭 이벤트
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            UserAddLoad();
        }

        // 수정 버튼 클릭 이벤트
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            UserUpdateLoad();
        }

        // 로그인정보 클릭 이벤트
        private void BtnLoginInfo_Click(object sender, EventArgs e)
        {

        }

        // 삭제 버튼 클릭 이벤트
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            UserDelete();
        }

        // 자료변환 버튼 클릭 이벤트 (엑셀 다운로드)
        private void BtnChange_Click(object sender, EventArgs e)
        {
            ExcelDownLoad();
        }

        // 닫기 버튼 클릭 이벤트
        private void BtnClose_Click(object sender, EventArgs e)
        {
            UserClose();
        }

        private void MasterGridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == nameof(User.UserPass))
            {
                // 비밀번호 컬럼은 실제 값 대신 *로 표시
                e.DisplayText = "**********";
            }

            if (e.Column.FieldName == nameof(User.UserGender)) {
                if (e.Value != null && e.Value.ToString() == nameof(User.Gender.Male))
                {
                    e.DisplayText = "남";
                }
                else if (e.Value != null && e.Value.ToString() == nameof(User.Gender.Female))
                {
                    e.DisplayText = "여";
                }
                else
                    e.DisplayText = "";
            }
        }

        // ------------
        // 메서드 정의
        // ------------

        // 부서정보 폼 Load
        public void DeptInfoLoad()
        {
            DeptInfoForm deptInfoForm = new DeptInfoForm();
            deptInfoForm.ShowDialog();

            if (deptInfoForm.DeptChangeFg)
            {
                UserSrch();
            }
        }

        // 사원 조회
        private void UserSrch()
        {
            userList = UserRepository.Instance.GetUser();
            masterGrid.DataSource = userList;
        }

        // 사원추가 폼 Load
        public void UserAddLoad()
        {
            UserAddForm userAddForm = new UserAddForm();
            userAddForm.ShowDialog();

            if (userAddForm.UserInsertFg)
            {
                UserSrch();
            }
        }

        // 사원수정 폼 Load
        public void UserUpdateLoad()
        {
            // 선택된 행이 있는지 확인
            if (masterGridView.FocusedRowHandle < 0)
            {
                MessageBox.Show("선택된 데이터가 없습니다.");
                return;
            }

            // 선택된 행의 데이터 얻기
            var user = masterGridView.GetRow(masterGridView.FocusedRowHandle) as User;
            if (user == null)
            {
                MessageBox.Show("데이터를 불러올 수 없습니다.");
                return;
            }

            UserUpdateForm userUpdateForm = new UserUpdateForm(user.Id);
            userUpdateForm.ShowDialog();

            if (userUpdateForm.UserUpdateFg)
            {
                UserSrch();
            }
        }

        // 사원 삭제
        public void UserDelete()
        {
            if (masterGridView.FocusedRowHandle < 0)
            {
                MessageBox.Show("선택된 데이터가 없습니다.");
                return;
            }

            var user = masterGridView.GetRow(masterGridView.FocusedRowHandle) as User;

            if (MessageBox.Show($"사원코드: {user.UserId}\n사원명: {user.UserName}\n\n삭제하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int result = UserRepository.Instance.DeleteUser(user.Id);

                if (result > 0)
                {
                    if (!string.IsNullOrEmpty(user.UserImage))
                    {
                        UserImageDelete(user.Id);
                    }

                    MessageBox.Show($"사원코드: {user.UserId}\n사원명: {user.UserName}\n\n데이터가 삭제되었습니다.");
                    UserSrch();
                }
                else if (result == -1)
                {
                    MessageBox.Show("삭제 중 오류가 발생했습니다.");
                }
                else
                {
                    MessageBox.Show("삭제에 실패했습니다");
                }
            }
        }

        // 사원 삭제 후 이미지 삭제
        private void UserImageDelete(int id)
        {
            UserFileConfig.Instance.DeleteUserImage(id);
        }

        // 엑셀 다운로드
        public void ExcelDownLoad()
        {
            if (masterGridView.FocusedRowHandle < 0)
            {
                MessageBox.Show("조회된 데이터가 없습니다.");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel 파일|*.xlsx";
                sfd.Title = "파일 경로를 선택하세요";
                sfd.FileName = $"사원목록_{DateTime.Now:yyyyMMdd}.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var workBook = new ClosedXML.Excel.XLWorkbook())
                    {
                        var workSheet = workBook.Worksheets.Add("사원정보");

                        var dataTable = new DataTable();

                        // 엑셀 column 추가
                        foreach (var header in UserExcelConfig.ColumnInfo.Values)
                        {
                            dataTable.Columns.Add(header);
                        }

                        // userList 안에 있는 각 User 객체를 반복
                        foreach (var user in userList)
                        {
                            // DataTable에 추가할 새로운 행(Row) 생성
                            var row = dataTable.NewRow();

                            // ColumnInfo에 정의된 컬럼만큼 반복
                            // kvp.Key = User 클래스 속성 이름 (예: "UserId")
                            // kvp.Value = Excel/Datatable 컬럼 이름 (예: "사원코드")
                            foreach (var kvp in UserExcelConfig.ColumnInfo)
                            {
                                // User 클래스에서 속성 정보를 가져옴
                                // typeof(User).GetProperty(kvp.Key) → "UserId" 속성 정보
                                var prop = typeof(User).GetProperty(kvp.Key);

                                // 속성이 존재하면 해당 User 객체에서 값 가져오기
                                // prop.GetValue(user) → user.UserId 값
                                // 값이 null이면 DBNull.Value로 처리 (Excel/Datatable에서 빈 셀 처리)
                                var value = prop != null ? prop.GetValue(user) ?? DBNull.Value : DBNull.Value;

                                // UserPass 컬럼이면 formatting 적용
                                if (kvp.Key == nameof(User.UserPass))
                                {
                                    value = "**********";
                                }

                                // DataRow에 값을 할당
                                // row["사원코드"] = user.UserId
                                row[kvp.Value] = value;
                            }

                            // DataTable에 완성된 행 추가
                            dataTable.Rows.Add(row);
                        }

                        var table = workSheet.Cell(1, 1).InsertTable(dataTable, "사원정보", true);

                        workSheet.Columns().Width = 15;

                        workBook.SaveAs(sfd.FileName);
                    }
                }
            }
        }
        
        // 폼 닫기
        public void UserClose()
        {
            this.Close();
        }
    }
}

