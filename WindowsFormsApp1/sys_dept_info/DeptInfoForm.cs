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
using WindowsFormsApp1.sys_user_info;

namespace WindowsFormsApp1
{
    public partial class DeptInfoForm : Form
    {        
        //private int ID { get; set; }

        public DeptInfoForm()
        {
            InitializeComponent();
        }

        public void DeptInfo_Load(object sender, EventArgs e)
        {
            DeptSrch();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            DeptAddLoad();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            DeptUpdate();
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
            DeptUpdate();
        }

        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // 추가(F1)
                case Keys.Enter:
                    DeptUpdate();
                    e.SuppressKeyPress = true;
                    break;

                default:
                    break;
            }
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

        public void DeptSrch()
        {
            ConnDatabase db = new ConnDatabase();
            db.Open();

            string sql = "select * from sys_dept_info order by dept_cd, dept_name";

            DataSet ds = db.GetDataSet(sql);
            dataGridView1.DataSource = ds.Tables[0];
            db.Close();
        }

        public void DeptUpdate()
        {
            if (this.dataGridView1.RowCount == 0)
            {
                MessageBox.Show("선택된 데이터가 없습니다.");
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];

            string deptId = row.Cells["id"].Value?.ToString();
            string deptCd = row.Cells["dept_cd"].Value?.ToString();
            string deptName = row.Cells["dept_name"].Value?.ToString();
            string remarkDc = row.Cells["remark_dc"].Value?.ToString();

            DeptUpdateForm deptUpdateForm = new DeptUpdateForm();

            deptUpdateForm.txtDeptId.Text = deptId;
            deptUpdateForm.txtDeptCd.Text = deptCd;
            deptUpdateForm.txtDeptName.Text = deptName;
            deptUpdateForm.txtRemarkDc.Text = remarkDc;

            this.Close();
            deptUpdateForm.Show();
        }

        public void DeptDelete()
        {
            if (this.dataGridView1.RowCount == 0)
            {
                MessageBox.Show("선택된 데이터가 없습니다.");
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];

            string Id = row.Cells["id"].Value?.ToString();
            string deptCd = row.Cells["dept_Cd"].Value?.ToString();
            string deptName = row.Cells["dept_name"].Value?.ToString();

            ConnDatabase db = new ConnDatabase();
            db.Open();

            string sql = "delete from sys_dept_info where id = " + Id;

            if (MessageBox.Show("부서코드: " + deptCd + "\n부서명: " + deptName + "\n\n삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataSet ds = db.GetDataSet(sql);

                MessageBox.Show("부서코드: " + deptCd + "\n부서명: " + deptName + "\n\n데이터가 삭제되었습니다.");
                DeptSrch();
            }

            db.Close();
        }

        public void DeptAddLoad()
        {
            this.Close();
            DeptAddForm deptAddForm = new DeptAddForm();
            deptAddForm.Show();
        }

        public void DeptClose()
        {
            this.Close();
            UserInfoForm userInfoForm = new UserInfoForm();
            userInfoForm.Show();
        }
    }
}
