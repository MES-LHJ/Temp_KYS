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
        public DeptAddForm()
        {
            InitializeComponent();
        }

        private void TxtRemarkDc_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    DeptReg();
                    break;

                default:
                    break;
            }
        }

        private void BtnAct_Click(object sender, EventArgs e)
        {
            DeptReg();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DeptLoad();
        }

        private void DeptAddForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // 엔터키
                case Keys.Enter:
                    this.SelectNextControl(this.ActiveControl, true, true, true, false);
                    break;

                // 저장(F4)
                case Keys.F4:
                    DeptReg();
                    break;

                // 닫기(ESC)
                case Keys.Escape:
                    DeptLoad();
                    break;

                default:
                    break;
            }
        }

        private void DeptReg()
        {
            string deptCd = txtDeptCd.Text.ToString();
            string deptName = txtDeptName.Text.ToString();
            string remarkDc = txtRemarkDc.Text.ToString();

            if (string.IsNullOrEmpty(deptCd))
            {
                MessageBox.Show("부서코드가 입력되지 않았습니다.");
                txtDeptCd.Focus();
                return;

            }
            else if (string.IsNullOrEmpty(deptName))
            {
                MessageBox.Show("부서명이 입력되지 않았습니다.");
                txtDeptName.Focus();
                return;
            }

            ConnDatabase db = new ConnDatabase();
            db.Open();

            string sql = "insert into sys_dept_info values (" + "\'" + deptCd + "\', \'" + deptName + "\', \'" + remarkDc + "" + "');";

            DataSet ds = db.GetDataSet(sql);

            db.Close();

            MessageBox.Show("처리되었습니다.");

            DeptLoad();
        }

        private void DeptLoad()
        {
            this.Close();

            DeptInfoForm deptInfoForm = new DeptInfoForm();
            deptInfoForm.Show();
        }
    }
}
