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
    public partial class dept_add : Form
    {
        public dept_add()
        {
            InitializeComponent();
        }

        private void btn_act_Click(object sender, EventArgs e)
        {
            string dept_cd = input_dept_cd.Text.ToString();
            string dept_name = input_dept_name.Text.ToString();
            
            if(dept_cd == "" || dept_name == "")
            {
                MessageBox.Show("필수 입력값이 입력되지 않았습니다.");
                return;
            }

            MessageBox.Show(dept_cd + " " + dept_name);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void dept_add_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // 저장(F4)
                case Keys.F4:
                    btn_act_Click(sender, e);
                    break;

                // 닫기(ESC)
                case Keys.Escape:
                    btn_cancel_Click(sender, e);
                    break;
            }
        }
    }
}
