using ClosedXML;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.api;
using WindowsFormsApp1.helper;
using WindowsFormsApp1.sys_dept_info;

namespace WindowsFormsApp1.sys_user_info
{
    public partial class UserInfoForm : Form
    {
        private List<User> userList;
        private string baseFolder;

        // 이벤트 핸들러
        private void InitEvents()
        {
            this.Load += UserInfoForm_Load;
            this.KeyDown += UserInfoForm_KeyDown;

            btnDept.Click += BtnDept_Click;
            btnSrch.Click += BtnSrch_Click;
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnLoginInfo.Click += BtnLoginInfo_Click;
            btnDelete.Click += BtnDelete_Click;
            btnChange.Click += BtnChange_Click;
            btnClose.Click += BtnClose_Click;

            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            dataGridView1.KeyDown += DataGridView1_KeyDown;
        }

        // 파일 저장 기본 경로 설정 (app.config)
        private void InitializeConfig()
        {
            baseFolder = ConfigurationManager.AppSettings["UserInfoPath"];

            if (string.IsNullOrEmpty(baseFolder))
            {
                Debug.WriteLine("UserInfoPath가 설정되지 않았습니다.");

                string projectName = Assembly.GetEntryAssembly().GetName().Name;
                string className = typeof(User).Name;

                baseFolder = $"D:\\Nas\\{projectName}\\{className}";
            }
        }

        public UserInfoForm()
        {
            InitializeComponent();
            InitEvents();
            InitializeConfig();
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

        // 폼 KeyDown 이벤트
        private void UserInfoForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // 추가(F1)
                case Keys.F1:
                    UserAddLoad();
                    break;

                // 조회(F2)
                case Keys.F2:
                    UserSrch();
                    break;

                // 삭제(F7)
                case Keys.F7:
                    UserDelete();
                    break;

                // 닫기(ESC)
                case Keys.Escape:
                    UserClose();
                    break;

                default:
                    break;
            }
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

        // 데이터 그리드 셀 포멧팅 이벤트
        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var data = sender as DataGridView;
            var columnName = data.Columns[e.ColumnIndex].Name;

            if (e.RowIndex < 0 || e.RowIndex >= data.Rows.Count) return;

            switch (columnName)
            {
                case nameof(User.UserPass):
                    e.Value = "**********";
                    e.FormattingApplied = true;
                    break;

                case nameof(User.UserGender):
                    var cellValue = data.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                    if (cellValue == nameof(User.Gender.Male))
                    {
                        e.Value = "남";
                    }
                    else if (cellValue == nameof(User.Gender.FeMale))
                    {
                        e.Value = "여";
                    }
                    else
                        e.Value = "";

                    e.FormattingApplied = true;
                    break;
            }
        }

        // 데이터 그리드 셀 더블클릭 이벤트
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UserUpdateLoad();
        }

        // 데이터 그리드 KeyDown 이벤트
        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    UserUpdateLoad();
                    e.SuppressKeyPress = true;
                    break;

                default:
                    break;
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

            if(deptInfoForm.DeptChangeFg)
            {
                UserSrch();
            }
        }

        // 사원 조회
        private async void UserSrch()
        {
            try
            {
                var result = await ApiUserRepository.Instance.GetUser(1);

                if (!string.IsNullOrEmpty(result.Error))
                {
                    MessageBox.Show($"사원 조회 실패: {result.Error}");
                    return;
                }

                userList = result.Data;
                dataGridView1.DataSource = userList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"사원 조회 중 오류가 발생했습니다.\n{ex.Message}");
            }

            //userList = UserRepository.Instance.GetUser();
            //dataGridView1.DataSource = userList;
        }

        // 사원추가 폼 Load
        public void UserAddLoad()
        {
            UserAddForm userAddForm = new UserAddForm();
            userAddForm.ShowDialog();

            if(userAddForm.UserInsertFg)
            {
                UserSrch();
            }
        }

        // 사원수정 폼 Load
        public void UserUpdateLoad()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("선택된 데이터가 없습니다.");
                return;
            }

            var user = dataGridView1.SelectedRows[0].DataBoundItem as User;

            UserUpdateForm userUpdateForm = new UserUpdateForm(user.Id);
            userUpdateForm.ShowDialog();

            if (userUpdateForm.UserUpdateFg)
            {
                UserSrch();
            }
        }

        // 사원 삭제
        public async void UserDelete()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("선택된 데이터가 없습니다.");
                return;
            }

            var user = dataGridView1.SelectedRows[0].DataBoundItem as User;

            if (MessageBox.Show($"사원코드: {user.UserId}\n사원명: {user.UserName}\n\n삭제하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    // API 호출
                    var result = await ApiUserRepository.Instance.DeleteUser(user.Id);

                    if (!string.IsNullOrEmpty(result.Error))
                    {
                        MessageBox.Show($"사원 삭제 실패: {result.Error}");
                        return;
                    }

                    MessageBox.Show($"사원코드: {user.UserId}\n사원명: {user.UserName}\n\n데이터가 삭제되었습니다.");
                    UserSrch();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"삭제 중 오류 발생: {ex.Message}");
                }

                //int result = UserRepository.Instance.DeleteUser(user.Id);

                //if (result > 0)
                //{
                //    if (!string.IsNullOrEmpty(user.UserImage))
                //    {
                //        UserImageDelete(user.Id);
                //    }

                //    MessageBox.Show($"사원코드: {user.UserId}\n사원명: {user.UserName}\n\n데이터가 삭제되었습니다.");
                //    UserSrch();
                //}
                //else if (result == -1)
                //{
                //    MessageBox.Show("삭제 중 오류가 발생했습니다.");
                //}
                //else
                //{
                //    MessageBox.Show("삭제에 실패했습니다");
                //}
            }
        }

        // 사원 삭제 후 이미지 삭제
        private void UserImageDelete(int id)
        {
            UserFileConfig.DeleteUserImage(id);
        }

        // 엑셀 다운로드
        public void ExcelDownLoad()
        {
            if (dataGridView1.Rows.Count == 0)
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
