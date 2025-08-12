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

namespace WindowsFormsApp1
{
    public partial class DeptAddForm : Form
    {
        DeptInfoForm _frm1;

        public DeptAddForm(DeptInfoForm _frm2)
        {
            InitializeComponent();
            _frm1 = _frm2;
        }

        private void input_remark_dc_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btn_act_Click(sender, e);
                    break;

                default:
                    break;
            }
        }

        private void btn_act_Click(object sender, EventArgs e)
        {
            string dept_cd = input_dept_cd.Text.ToString();
            string dept_name = input_dept_name.Text.ToString();
            string remark_dc = input_remark_dc.Text.ToString();
            
            if(dept_cd == "")
            {
                MessageBox.Show("부서코드가 입력되지 않았습니다.");
                input_dept_cd.Focus();
                return;

            } else if(dept_name == "")
            {
                MessageBox.Show("부서명이 입력되지 않았습니다.");
                input_dept_name.Focus();
                return;
            }

            ConnDatabase db = new ConnDatabase();
            db.Open();

            string sql = "insert into sys_dept_info values (" + "\'" + dept_cd + "\', \'" + dept_name + "\', \'" + remark_dc + "" +"');";
            
            DataSet ds = db.GetDataSet(sql);

            db.Close();

            MessageBox.Show("처리되었습니다.");

            _frm1.dept_info_Load(sender, e);

            this.Visible = false;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void dept_add_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // 엔터키
                case Keys.Enter:
                    this.SelectNextControl(this.ActiveControl, true, true, true, false);
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
    }
}
