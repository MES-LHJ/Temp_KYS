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

namespace WindowsFormsApp2.sys_upperdept_info
{
    public partial class UpperDeptInfoForm : XtraForm
    {
        private List<UpperDept> upperDeptList = new List<UpperDept>();

        public bool UpperDeptChangeFg { get; private set; } = false;


        // 이벤트 핸들러
        private void InitEvents()
        {
            this.Load += UpperDeptInfoForm_Load;

            btnChange.Click += BtnChange_Click;
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnClose.Click += BtnClose_Click;
        }

        public UpperDeptInfoForm()
        {
            InitializeComponent();
            InitEvents();
        }

        // ------------
        // 이벤트 정의
        // ------------

        // 폼 Load 이벤트
        public void UpperDeptInfoForm_Load(object sender, EventArgs e)
        {
            UpperDeptSrch();
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

        // ------------
        // 메서드 정의
        // ------------

        // 상위 부서 조회
        public void UpperDeptSrch()
        {
            upperDeptList = UpperDeptRepository.Instance.GetUpperDept();
            masterGrid.DataSource = upperDeptList;
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
                sfd.FileName = $"부서목록_{DateTime.Now.ToString("yyyyMMdd")}.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var workBook = new ClosedXML.Excel.XLWorkbook())
                    {
                        var workSheet = workBook.Worksheets.Add("부서정보");
                        var dataTable = new DataTable();

                        // 엑셀 column 추가
                        foreach (var header in DeptExcelConfig.ColumnInfo.Values)
                        {
                            dataTable.Columns.Add(header);
                        }

                        // upperDeptList 안에 있는 각 Dept 객체를 반복
                        foreach (var upperDept in upperDeptList)
                        {
                            // DataTable에 추가할 새로운 행(Row) 생성
                            var row = dataTable.NewRow();

                            // ColumnInfo에 정의된 컬럼만큼 반복
                            // kvp.Key = Dept 클래스 속성 이름 (예: "DeptCd")
                            // kvp.Value = Excel/Datatable 컬럼 이름 (예: "부서코드")
                            foreach (var kvp in DeptExcelConfig.ColumnInfo)
                            {
                                // Dept 클래스에서 속성 정보를 가져옴
                                // typeof(Dept).GetProperty(kvp.Key) → "DeptCd" 속성 정보
                                var prop = typeof(UpperDept).GetProperty(kvp.Key);

                                // 속성이 존재하면 해당 Dept 객체에서 값 가져오기
                                // prop.GetValue(dept) → dept.DeptCd 값
                                // 값이 null이면 DBNull.Value로 처리 (Excel/Datatable에서 빈 셀 처리)
                                var value = prop != null ? prop.GetValue(upperDept) ?? DBNull.Value : DBNull.Value;

                                // DataRow에 값을 할당
                                // row["부서코드"] = dept.DeptCd
                                row[kvp.Value] = value;
                            }

                            // DataTable에 완성된 행 추가
                            dataTable.Rows.Add(row);
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
            UpperDeptAddForm upperDeptAddForm = new UpperDeptAddForm();
            upperDeptAddForm.ShowDialog();

            if (upperDeptAddForm.UpperDeptInsertFg)
            {
                UpperDeptSrch();
                UpperDeptChangeFg = true;
            }
        }

        // 부서 수정 폼 Load
        public void DeptUpdateLoad()
        {
            if (masterGridView.FocusedRowHandle < 0)
            {
                MessageBox.Show("선택된 데이터가 없습니다.");
                return;
            }

            var upperDept = masterGridView.GetRow(masterGridView.FocusedRowHandle) as UpperDept;

            UpperDeptUpdateForm upperDeptUpdateForm = new UpperDeptUpdateForm(upperDept.Id);
            upperDeptUpdateForm.ShowDialog();

            if (upperDeptUpdateForm.UpperDeptUpdateFg)
            {
                UpperDeptSrch();
                UpperDeptChangeFg = true;
            }
        }

        // 부서 삭제
        public void DeptDelete()
        {
            if (masterGridView.FocusedRowHandle < 0)
            {
                MessageBox.Show("선택된 데이터가 없습니다.");
                return;
            }

            var upperDept = masterGridView.GetRow(masterGridView.FocusedRowHandle) as UpperDept;

            if (MessageBox.Show($"부서코드: {upperDept.UpperDeptCd}\n부서명: {upperDept.UpperDeptName}\n\n삭제하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int result = UpperDeptRepository.Instance.DeleteUpperDept(upperDept.Id);

                if (result > 0)
                {
                    MessageBox.Show($"부서코드: {upperDept.UpperDeptCd}\n부서명: {upperDept.UpperDeptName}\n\n데이터가 삭제되었습니다.");
                    UpperDeptChangeFg = true;
                    UpperDeptSrch();
                }
                else if (result == -1)
                {
                    MessageBox.Show("하위부서가 존재해 삭제할 수 없습니다.");
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
