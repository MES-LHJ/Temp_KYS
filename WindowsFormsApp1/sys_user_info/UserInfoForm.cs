using ClosedXML;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.helper;
using WindowsFormsApp1.sys_dept_info;

namespace WindowsFormsApp1.sys_user_info
{
    public partial class UserInfoForm : Form
    {
        private BindingList<User> userList;

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

        public UserInfoForm()
        {
            InitializeComponent();
            InitEvents();
        }

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

        private void BtnDept_Click(object sender, EventArgs e)
        {
            DeptInfoLoad();
        }

        private void BtnSrch_Click(object sender, EventArgs e)
        {
            UserSrch();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            UserAddLoad();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            UserUpdateLoad();
        }

        private void BtnLoginInfo_Click(object sender, EventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            UserDelete();
        }

        private void BtnChange_Click(object sender, EventArgs e)
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
                sfd.FileName = $"사원목록_{DateTime.Now.ToString("yyyyMMdd")}.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var workBook = new ClosedXML.Excel.XLWorkbook())
                    {
                        var workSheet = workBook.Worksheets.Add("사원정보");

                        var visibleColumns = dataGridView1.Columns
                            .Cast<DataGridViewColumn>()
                            .Where(c => c.Visible)
                            .OrderBy(c => c.DisplayIndex)
                            .ToList();

                        var dataTable = new DataTable();
                        for (int i=0; i<visibleColumns.Count; i++)
                        {
                            dataTable.Columns.Add(visibleColumns[i].HeaderText);
                        }

                        for (int j=0; j<dataGridView1.Rows.Count; j++)
                        {
                            var row = dataGridView1.Rows[j];
                            if (row.IsNewRow) continue;

                            var dataRow = dataTable.NewRow();

                            for (int k=0; k<visibleColumns.Count; k++)
                            {
                                dataRow[k] = row.Cells[visibleColumns[k].Index].FormattedValue ?? "";
                            }

                            dataTable.Rows.Add(dataRow);
                        }

                        var table = workSheet.Cell(1, 1).InsertTable(dataTable, "사원정보", true);

                        workSheet.Columns().Width = 15;

                        workBook.SaveAs(sfd.FileName);
                    }
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            UserClose();
        }

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

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UserUpdateLoad();
        }

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

        public void DeptInfoLoad()
        {
            DeptInfoForm deptInfoForm = new DeptInfoForm();
            deptInfoForm.ShowDialog();

            if(deptInfoForm.DeptChangeFg)
            {
                UserSrch();
            }
        }

        private void UserSrch()
        {
            userList = ConnDatabase.Instance.GetUser();
            dataGridView1.DataSource = userList;
        }

        public void UserAddLoad()
        {
            UserAddForm userAddForm = new UserAddForm();
            userAddForm.ShowDialog();

            if(userAddForm.UserInsertFg)
            {
                UserSrch();
            }
        }

        public void UserUpdateLoad()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("선택된 데이터가 없습니다.");
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];

            var user = new User
            {
                Id = Convert.ToInt32(row.Cells[nameof(User.Id)].Value),
                UserId = row.Cells[nameof(User.UserId)].Value?.ToString(),
                UserName = row.Cells[nameof(User.UserName)].Value?.ToString(),
                UserRank = row.Cells[nameof(User.UserRank)].Value?.ToString(),
                UserEmpType = row.Cells[nameof(User.UserEmpType)].Value?.ToString(),
                UserGender = (User.Gender)Convert.ToInt32(row.Cells[nameof(User.UserGender)].Value),
                UserTel = row.Cells[nameof(User.UserTel)].Value?.ToString(),
                UserEmail = row.Cells[nameof(User.UserEmail)].Value?.ToString(),
                UserMessengerId = row.Cells[nameof(User.UserMessengerId)].Value?.ToString(),
                RemarkDc = row.Cells[nameof(User.RemarkDc)].Value?.ToString(),
                IdDept = Convert.ToInt32(row.Cells[nameof(User.IdDept)].Value),
                DeptCd = row.Cells[nameof(User.DeptCd)].Value?.ToString(),
                DeptName = row.Cells[nameof(User.DeptName)].Value?.ToString()
            };

            UserUpdateForm userUpdateForm = new UserUpdateForm(user);
            userUpdateForm.ShowDialog();

            if (userUpdateForm.UserUpdateFg)
            {
                UserSrch();
            }
        }

        public void UserDelete()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("선택된 데이터가 없습니다.");
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];

            var user = new User
            {
                Id = Convert.ToInt32(row.Cells[nameof(User.Id)].Value),
                UserId = row.Cells[nameof(User.UserId)].Value?.ToString(),
                UserName = row.Cells[nameof(User.UserName)].Value?.ToString()
            };

            if (MessageBox.Show($"사원코드: {user.UserId}\n사원명: {user.UserName}\n\n삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int result = ConnDatabase.Instance.DeleteUser(user.Id);

                if (result > 0)
                {
                    MessageBox.Show($"사원코드: {user.UserId}\n사원명: {user.UserName}\n\n데이터가 삭제되었습니다.");
                    UserSrch();
                }
                else if (result == -2)
                {
                    MessageBox.Show("삭제 중 오류가 발생했습니다.");
                }
                else
                {
                    MessageBox.Show("삭제에 실패했습니다");
                }
            }
        }

        public void UserClose()
        {
            this.Close();
        }
    }
}
