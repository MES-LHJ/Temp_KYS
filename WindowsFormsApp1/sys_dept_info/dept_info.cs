using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class dept_info : Form
    {
        public dept_info()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            dept_add show_dept_add = new dept_add();
            show_dept_add.Show();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.RowCount == 0)
            {
                MessageBox.Show("선택된 데이터가 없습니다.");
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];

            string dept_cd = row.Cells[0].Value.ToString();
            string dept_name = row.Cells[1].Value.ToString();

            MessageBox.Show("부서코드: " + dept_cd + ", 부서명: " + dept_name);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.RowCount == 0)
            {
                MessageBox.Show("선택된 데이터가 없습니다.");
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];

            string dept_cd = row.Cells[0].Value.ToString();
            string dept_name = row.Cells[1].Value.ToString();

            MessageBox.Show("부서코드: " + dept_cd + ", 부서명: " + dept_name);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void dept_info_Load(object sender, EventArgs e)
        {
            Con_Database db = new Con_Database();
            db.Open();

            string sql = "select * from sys_dept_info";

            DataSet ds = db.GetDataSet(sql);
            dataGridView1.DataSource = ds.Tables[0];
            db.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_update_Click(sender, e);
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // 추가(F1)
                case Keys.F1:
                    btn_add_Click(sender, e);
                    break;

                // 삭제(F7)
                case Keys.F7:
                    btn_delete_Click(sender, e);
                    break;

                // 닫기(ESC)
                case Keys.Escape:
                    btn_close_Click(sender, e);
                    break;
            }
        }
    }
}
