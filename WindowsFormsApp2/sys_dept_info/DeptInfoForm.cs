using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraTab;
using DocumentFormat.OpenXml.Drawing.Charts;
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
using WindowsFormsApp2.sys_upperdept_info;
using DevExpress.XtraEditors;

namespace WindowsFormsApp2.sys_dept_info
{
    public partial class DeptInfoForm : XtraForm
    {
        private List<UpperDept> upperDeptList = new List<UpperDept>();
        private List<Dept> deptList = new List<Dept>();

        public bool DeptChangeFg { get; private set; } = false;

        // 이벤트 핸들러
        private void InitEvents()
        {
            this.Load += DeptInfoForm_Load;

            btnUpperDept.Click += BtnUpperDept_Click;
            btnTree.Click += BtnTree_Click;
            btnChart.Click += BtnChart_Click;
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnClose.Click += BtnClose_Click;

            masterGridView.FocusedRowChanged += MasterGridView_FocusedRowChanged;
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

        // 상위부서 버튼 클릭 이벤트
        private void BtnUpperDept_Click(object sender, EventArgs e)
        {
            UpperDeptLoad();
        }

        // 트리 버튼 클릭 이벤트
        private void BtnTree_Click(object sender, EventArgs e)
        {
            DeptTreeLoad();
        }

        // 차트 버튼 클릭 이벤트
        private void BtnChart_Click(object sender, EventArgs e)
        {
            DeptChartLoad();
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

        // masterGrid 포커스 체인지 이벤트
        private void MasterGridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            RefreshDetailGrid();
        }

        // ------------
        // 메서드 정의
        // ------------

        // 부서 조회
        public void DeptSrch()
        {
            upperDeptList = UpperDeptRepository.Instance.GetUpperDept();
            masterGrid.DataSource = upperDeptList;
        }

        // 상위부서 폼 Load
        public void UpperDeptLoad()
        {
            UpperDeptInfoForm upperDeptInfoForm = new UpperDeptInfoForm();
            upperDeptInfoForm.ShowDialog();

            if (upperDeptInfoForm.UpperDeptChangeFg)
            {
                DeptSrch();
            }
        }

        // 트리 폼 Load
        public void DeptTreeLoad()
        {
            DeptTreeForm deptTreeForm = new DeptTreeForm();
            deptTreeForm.ShowDialog();
        }

        // 차트 폼 Load
        public void DeptChartLoad()
        {
            DeptChartForm deptChartForm = new DeptChartForm();
            deptChartForm.ShowDialog();
        }

        // 부서 추가 폼 Load
        public void DeptAddLoad()
        {
            if (masterGridView.FocusedRowHandle < 0)
            {
                MessageBox.Show("선택된 상위부서 데이터가 없습니다.");
                return;
            }

            var upperDept = masterGridView.GetRow(masterGridView.FocusedRowHandle) as UpperDept;
            
            DeptAddForm deptAddForm = new DeptAddForm(upperDept.Id);
            deptAddForm.ShowDialog();

            if (deptAddForm.DeptInsertFg)
            {
                RefreshDetailGrid();
                DeptChangeFg = true;
            }
        }

        // 부서 수정 폼 Load
        public void DeptUpdateLoad()
        {
            if (detailGridView.FocusedRowHandle < 0)
            {
                MessageBox.Show("선택된 데이터가 없습니다.");
                return;
            }

            var dept = detailGridView.GetRow(detailGridView.FocusedRowHandle) as Dept;

            DeptUpdateForm deptUpdateForm = new DeptUpdateForm(dept.Id);
            deptUpdateForm.ShowDialog();

            if (deptUpdateForm.DeptUpdateFg)
            {
                RefreshDetailGrid();
                DeptChangeFg = true;
            }
        }

        // 부서 삭제
        public void DeptDelete()
        {
            if (detailGridView.FocusedRowHandle < 0)
            {
                MessageBox.Show("선택된 데이터가 없습니다.");
                return;
            }

            var dept = detailGridView.GetRow(detailGridView.FocusedRowHandle) as Dept;

            if (MessageBox.Show($"부서코드: {dept.DeptCd}\n부서명: {dept.DeptName}\n\n삭제하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int result = DeptRepository.Instance.DeleteDept(dept.Id);

                if (result > 0)
                {
                    MessageBox.Show($"부서코드: {dept.DeptCd}\n부서명: {dept.DeptName}\n\n데이터가 삭제되었습니다.");
                    RefreshDetailGrid();
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

        // detailGrid 데이터 불러오기
        private void RefreshDetailGrid()
        {
            var selectedUpperDept = masterGridView.GetRow(masterGridView.FocusedRowHandle) as UpperDept;

            if (selectedUpperDept != null)
            {
                List<Dept> deptList = DeptRepository.Instance.GetDept()
                    .Where(d => d.IdUpperDept == selectedUpperDept.Id)
                    .OrderBy(d => d.DeptCd)
                    .ToList();
                detailGrid.DataSource = deptList;
            }
            else
            {
                detailGrid.DataSource = null;
            }
        }
    }
}