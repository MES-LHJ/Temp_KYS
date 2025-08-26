using DocumentFormat.OpenXml.Spreadsheet;
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
using System.Windows.Forms.DataVisualization.Charting;
using WindowsFormsApp1.helper;
using WindowsFormsApp1.sys_user_info;

namespace WindowsFormsApp1.sys_dept_info
{
    public partial class DeptInfoForm : Form
    {
        private BindingList<Dept> deptList = new BindingList<Dept>();

        public bool DeptChangeFg { get; private set; } = false;

        // 이벤트 핸들러
        private void InitEvents()
        {
            this.Load += DeptInfoForm_Load;
            this.KeyDown += DeptInfoForm_KeyDown;

            btnChart.Click += BtnChart_Click;
            btnChange.Click += BtnChange_Click;
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnClose.Click += BtnClose_Click;

            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            dataGridView1.KeyDown += DataGridView1_KeyDown;
        }

        public DeptInfoForm()
        {
            InitializeComponent();
            InitEvents();
        }

        // ------------
        // 이벤트 정의
        // ------------

        // 폼 Load 이벤트
        public void DeptInfoForm_Load(object sender, EventArgs e)
        {
            DeptSrch();
        }

        // 폼 KeyDown 이벤트
        private void DeptInfoForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // 추가(F1)
                case Keys.F1:
                    DeptAddLoad();
                    break;

                // 삭제(F7)
                case Keys.F7:
                    DeptDelete();
                    break;

                // 닫기(ESC)
                case Keys.Escape:
                    DeptClose();
                    break;

                default:
                    break;
            }
        }

        // 차트 버튼 클릭 이벤트
        private void BtnChart_Click(object sender, EventArgs e)
        {
            DeptChartLoad();
        }

        // 자료변환 버튼 클릭 이벤트 (엑셀 다운로드)
        private void BtnChange_Click(object sender, EventArgs e)
        {
            ExcelDownLoad();
        }

        // 추가 버튼 클릭 이벤트
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            DeptAddLoad();
        }

        // 수정 버튼 클릭 이벤트
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            DeptUpdateLoad();
        }

        // 삭제 버튼 클릭 이벤트
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeptDelete();
        }
        
        // 닫기 버튼 클릭 이벤트
        private void BtnClose_Click(object sender, EventArgs e)
        {
            DeptClose();
        }

        // 데이터 그리드 셀 더블클릭 이벤트
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DeptUpdateLoad();
        }

        // 데이터 그리드 KeyDown 이벤트
        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    DeptUpdateLoad();
                    e.SuppressKeyPress = true;
                    break;

                default:
                    break;
            }
        }

        // ------------
        // 메서드 정의
        // ------------

        // 부서 조회
        public void DeptSrch()
        {
            deptList = DeptRepository.Instance.GetDept();
            dataGridView1.DataSource = deptList;
        }

        // 부서 차트 폼 Load
        public void DeptChartLoad()
        {
            DeptChartForm deptChart = new DeptChartForm();
            deptChart.ShowDialog();
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
                sfd.FileName = $"부서목록_{DateTime.Now.ToString("yyyyMMdd")}.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var workBook = new ClosedXML.Excel.XLWorkbook())
                    {
                        var workSheet = workBook.Worksheets.Add("부서정보");

                        var visibleColumns = dataGridView1.Columns
                            .Cast<DataGridViewColumn>()
                            .Where(c => c.Visible)
                            .OrderBy(c => c.DisplayIndex)
                            .ToList();

                        var dataTable = new DataTable();
                        for (int i = 0; i < visibleColumns.Count; i++)
                        {
                            dataTable.Columns.Add(visibleColumns[i].HeaderText);
                        }

                        for (int j = 0; j < dataGridView1.Rows.Count; j++)
                        {
                            var row = dataGridView1.Rows[j];
                            if (row.IsNewRow) continue;

                            var dataRow = dataTable.NewRow();

                            for (int k = 0; k < visibleColumns.Count; k++)
                            {
                                dataRow[k] = row.Cells[visibleColumns[k].Index].FormattedValue ?? "";
                            }

                            dataTable.Rows.Add(dataRow);
                        }

                        var table = workSheet.Cell(1, 1).InsertTable(dataTable, "부서정보", true);

                        workSheet.Columns().Width = 15;

                        workBook.SaveAs(sfd.FileName);
                    }
                }
            }
        }

        // 부서 추가 폼 Load
        public void DeptAddLoad()
        {
            DeptAddForm deptAddForm = new DeptAddForm();
            deptAddForm.ShowDialog();

            if (deptAddForm.DeptInsertFg)
            {
                DeptSrch();
                DeptChangeFg = true;
            }
        }

        // 부서 수정 폼 Load
        public void DeptUpdateLoad()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("선택된 데이터가 없습니다.");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[nameof(Dept.Id)].Value);

            DeptUpdateForm deptUpdateForm = new DeptUpdateForm(id);
            deptUpdateForm.ShowDialog();

            if (deptUpdateForm.DeptUpdateFg)
            {
                DeptSrch();
                DeptChangeFg = true;
            }
        }

        // 부서 삭제
        public void DeptDelete()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("선택된 데이터가 없습니다.");
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];

            var dept = new Dept
            {
                Id = Convert.ToInt32(row.Cells[nameof(Dept.Id)].Value),
                DeptCd = row.Cells[nameof(Dept.DeptCd)].Value?.ToString(),
                DeptName = row.Cells[nameof(Dept.DeptName)].Value?.ToString()
            };

            if (MessageBox.Show($"부서코드: {dept.DeptCd}\n부서명: {dept.DeptName}\n\n삭제하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int result = DeptRepository.Instance.DeleteDept(dept.Id);

                if (result > 0)
                {
                    MessageBox.Show($"부서코드: {dept.DeptCd}\n부서명: {dept.DeptName}\n\n데이터가 삭제되었습니다.");
                    DeptSrch();
                }
                else if (result == -1)
                {
                    MessageBox.Show("이미 사용중인 부서 데이터는 삭제할 수 없습니다.");
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

        // 폼 닫기
        public void DeptClose()
        {
            this.Close();
        }
    }
}
