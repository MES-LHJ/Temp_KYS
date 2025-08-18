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
        private Dept DataDeptInfo = new Dept();

        private void InitEvent()
        {
            this.KeyDown += DeptAddForm_KeyDown;
            txtRemarkDc.KeyDown += TxtRemarkDc_KeyDown;

            btnAct.Click += BtnAct_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        public DeptAddForm()
        {
            InitializeComponent();
            InitEvent();
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
                    DeptClose();
                    break;

                default:
                    break;
            }
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
            DeptClose();
        }

        public void ResetForm()
        {
            txtDeptCd.Text = string.Empty;
            txtDeptName.Text = string.Empty;
            txtRemarkDc.Text = string.Empty;

            this.ActiveControl = txtDeptCd;
        }

        private void DeptReg()
        {
            DataDeptInfo.DeptCd = txtDeptCd.Text.Trim();
            DataDeptInfo.DeptName = txtDeptName.Text.Trim();
            DataDeptInfo.RemarkDc = txtRemarkDc.Text.Trim();

            if (string.IsNullOrEmpty(DataDeptInfo.DeptCd))
            {
                MessageBox.Show("부서코드가 입력되지 않았습니다.");
                txtDeptCd.Focus();
                return;
            }

            if (string.IsNullOrEmpty(DataDeptInfo.DeptName))
            {
                MessageBox.Show("부서명이 입력되지 않았습니다.");
                txtDeptName.Focus();
                return;
            }

            int result = ConnDatabase.Instance.AddDept(DataDeptInfo);

            if (result > 0)
            {
                MessageBox.Show("저장되었습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (result == -1)
            {
                MessageBox.Show("이미 존재하는 부서코드 입니다.");
                txtDeptCd.Focus();
            }
            else if (result == -2)
            {
                MessageBox.Show("저장 중 오류가 발생했습니다.");
            }
            else
            {
                MessageBox.Show("저장에 실패했습니다.");
            }
        }

        private void DeptClose()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
