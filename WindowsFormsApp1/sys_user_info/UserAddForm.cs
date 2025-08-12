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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class UserAddForm : Form
    {
        private List<CmnDeptCombo> combo_list = new List<CmnDeptCombo>();

        public UserAddForm()
        {
            InitializeComponent();
        }

        private void user_add_Load(object sender, EventArgs e)
        {
            ConnDatabase db = new ConnDatabase();
            db.Open();

            string sql = "select * from sys_dept_info";

            DataSet ds = db.GetDataSet(sql);
            
            db.Close();
            
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                CmnDeptCombo db_dept = new CmnDeptCombo
                {
                    id = ds.Tables[0].Rows[i][0].ToString(),
                    dept_cd = ds.Tables[0].Rows[i][1].ToString(), 
                    dept_name = ds.Tables[0].Rows[i][2].ToString()
                };

                combo_list.Add(db_dept);
            }

            select_id_dept.DataSource = combo_list;
            select_id_dept.DisplayMember = "dept_cd";
            select_id_dept.ValueMember = "dept_name";

            select_id_dept_SelectedIndexChanged(sender, e);
        }

        private void btn_act_Click(object sender, EventArgs e)
        {
            string user_id = input_user_id.Text.ToString();
            string user_name = input_user_name.Text.ToString();

            MessageBox.Show(user_id + " " + user_name);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void user_add_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // 엔터키
                case Keys.Enter:
                    this.SelectNextControl(this.ActiveControl, true, true, true, false);
                    e.Handled = true;
                    break;

                // 저장(F4)
                case Keys.F4:
                    btn_act_Click(sender, e);
                    break;

                // 닫기(ESC)
                case Keys.Escape:
                    btn_cancel_Click(sender, e);
                    break;

                default:
                    break;
            }
        }

        private void select_id_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (select_id_dept.SelectedItem != null)
            {
                var selected_dept = (CmnDeptCombo)select_id_dept.SelectedItem;
                var id_dept = selected_dept.id;

                input_dept_name.Text = select_id_dept.SelectedValue.ToString();
                input_id_dept.Text = id_dept;

                input_user_id.Focus();
            }
        }
    }
}
