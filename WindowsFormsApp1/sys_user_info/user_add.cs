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
    public partial class user_add : Form
    {
        public user_add()
        {
            InitializeComponent();
        }

        private void detp_cd_SelectedIndexChanged(object sender, EventArgs e)
        {

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
