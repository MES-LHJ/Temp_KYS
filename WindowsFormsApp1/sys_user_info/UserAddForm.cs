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
        private List<CmnDeptCombo> comboList = new List<CmnDeptCombo>();

        public UserAddForm()
        {
            InitializeComponent();
        }

        private void UserAdd_Load(object sender, EventArgs e)
        {
            ConnDatabase db = new ConnDatabase();
            db.Open();

            string sql = "select * from sys_dept_info";

            DataSet ds = db.GetDataSet(sql);

            db.Close();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                CmnDeptCombo dbDept = new CmnDeptCombo
                {
                    Id = ds.Tables[0].Rows[i]["id"].ToString(),
                    DeptCd = ds.Tables[0].Rows[i]["dept_cd"].ToString(),
                    deptName = ds.Tables[0].Rows[i]["dept_name"].ToString()
                };

                comboList.Add(dbDept);
            }

            selectDeptCd.DataSource = comboList;
            selectDeptCd.DisplayMember = "deptCd";
            selectDeptCd.ValueMember = "deptName";

            selectDeptCd_SelectedIndexChanged(sender, e);
        }

        private void BtnAct_Click(object sender, EventArgs e)
        {
            string userId = txtUserId.Text.ToString();
            string userName = txtUserName.Text.ToString();

            MessageBox.Show(userId + " " + userName);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            UserInfoForm userInfoForm = new UserInfoForm();

            this.Close();
            userInfoForm.Show();
        }

        private void UserAddForm_KeyDown(object sender, KeyEventArgs e)
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
                    BtnAct_Click(sender, e);
                    break;

                // 닫기(ESC)
                case Keys.Escape:
                    BtnCancel_Click(sender, e);
                    break;

                default:
                    break;
            }
        }

        private void selectDeptCd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectDeptCd.SelectedItem != null)
            {
                var selected_dept = (CmnDeptCombo)selectDeptCd.SelectedItem;
                var id_dept = selected_dept.Id;

                txtDeptName.Text = selectDeptCd.SelectedValue.ToString();
                input_id_dept.Text = id_dept;

                txtUserId.Focus();
            }
        }
    }
}
