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
using WindowsFormsApp1.helper;
using WindowsFormsApp1.sys_user_info;

namespace WindowsFormsApp1.sys_dept_info
{
    public partial class DeptInfoForm : Form
    {
        private BindingList<Dept> deptList = new BindingList<Dept>();

        public bool DeptChangeFg { get; private set; } = false;

        private void InitEvents()
        {
            this.Load += DeptInfoForm_Load;
            this.KeyDown += DeptInfoForm_KeyDown;
            
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

        public void DeptInfoForm_Load(object sender, EventArgs e)
        {
            DeptSrch();
        }

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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            DeptAddLoad();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            DeptUpdateLoad();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeptDelete();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            DeptClose();
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DeptUpdateLoad();
        }

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

        public void DeptSrch()
        {
            deptList = ConnDatabase.Instance.GetDept();
            dataGridView1.DataSource = deptList;
        }

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

        public void DeptUpdateLoad()
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
                DeptName = row.Cells[nameof(Dept.DeptName)].Value?.ToString(),
                RemarkDc = row.Cells[nameof(Dept.RemarkDc)].Value?.ToString()
            };

            DeptUpdateForm deptUpdateForm = new DeptUpdateForm(dept);
            deptUpdateForm.ShowDialog();

            if (deptUpdateForm.DeptUpdateFg)
            {
                DeptSrch();
                DeptChangeFg = true;
            }
        }

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

            if (MessageBox.Show($"부서코드: {dept.DeptCd}\n부서명: {dept.DeptName}\n\n삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int result = ConnDatabase.Instance.DeleteDept(dept.Id);

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

        public void DeptClose()
        {
            this.Close();
        }
    }
}
