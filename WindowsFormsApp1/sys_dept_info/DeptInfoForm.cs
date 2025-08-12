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
        private int ID { get; set; }

        public DeptInfoForm()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            DeptAddForm show_dept_add = new DeptAddForm(this);
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

            string dept_id = row.Cells[0].Value.ToString();
            string dept_cd = row.Cells[1].Value.ToString();
            string dept_name = row.Cells[2].Value.ToString();
            string remark_dc = row.Cells[3].Value.ToString();

            DeptUpdateForm show_dept_update = new DeptUpdateForm(this);

            show_dept_update.input_dept_id.Text = dept_id;
            show_dept_update.input_dept_cd.Text = dept_cd;
            show_dept_update.input_dept_name.Text = dept_name;
            show_dept_update.input_remark_dc.Text = remark_dc;
            
            show_dept_update.Show();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.RowCount == 0)
            {
                MessageBox.Show("선택된 데이터가 없습니다.");
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];

            string id = row.Cells[0].Value.ToString();
            string dept_cd = row.Cells[1].Value.ToString();
            string dept_name = row.Cells[2].Value.ToString();

            ConnDatabase db = new ConnDatabase();
            db.Open();
            
            string sql = "delete from sys_dept_info where id = "+id;

            if (MessageBox.Show("부서코드: "+dept_cd+"\n부서명: "+dept_name+"\n\n삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataSet ds = db.GetDataSet(sql);
                
                MessageBox.Show("부서코드: "+dept_cd+"\n부서명: "+dept_name+"\n\n데이터가 삭제되었습니다.");
                dept_info_Load(sender, e);
            }

            db.Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        public void dept_info_Load(object sender, EventArgs e)
        {
            ConnDatabase db = new ConnDatabase();
            db.Open();

            string sql = "select * from sys_dept_info order by dept_cd, dept_name";

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
                case Keys.Enter:
                    btn_update_Click(sender, e);
                    e.SuppressKeyPress = true;
                    break;

                default:
                    break;
            }
        }

        private void dept_info_KeyDown(object sender, KeyEventArgs e)
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

                default:
                    break;
            }
        }
    }
}
