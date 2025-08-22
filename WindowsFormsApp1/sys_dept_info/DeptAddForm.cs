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
using WindowsFormsApp1.helper;

namespace WindowsFormsApp1.sys_dept_info
{
    public partial class DeptAddForm : Form
    {
        private Dept DataDeptInfo = new Dept();

        public bool DeptInsertFg { get; private set; } = false;

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

        //public void ResetForm()
        //{
        //    txtDeptCd.Text = string.Empty;
        //    txtDeptName.Text = string.Empty;
        //    txtRemarkDc.Text = string.Empty;

        //    this.ActiveControl = txtDeptCd;
        //}

        private void DeptReg()
        {
            if (string.IsNullOrEmpty(txtDeptCd.Text.Trim()))
            {
                MessageBox.Show("부서코드가 입력되지 않았습니다.");
                txtDeptCd.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtDeptName.Text.Trim()))
            {
                MessageBox.Show("부서명이 입력되지 않았습니다.");
                txtDeptName.Focus();
                return;
            }

            if (MessageBox.Show("저장하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataDeptInfo.DeptCd = txtDeptCd.Text.Trim();
                DataDeptInfo.DeptName = txtDeptName.Text.Trim();
                DataDeptInfo.RemarkDc = txtRemarkDc.Text.Trim();

                int result = ConnDatabase.Instance.AddDept(DataDeptInfo);

                switch (result)
                {
                    case int n when n > 0:
                        DeptInsertFg = true;
                        MessageBox.Show("저장되었습니다.");
                        this.Close();
                        break;

                    case -1:
                        MessageBox.Show("이미 존재하는 부서코드 입니다.");
                        txtDeptCd.Focus();
                        break;

                    case -2:
                        MessageBox.Show("저장 중 오류가 발생했습니다.");
                        break;

                    default:
                        MessageBox.Show("저장에 실패했습니다.");
                        break;
                }
            }
        }

        private void DeptClose()
        {
            DeptInsertFg = false;
            this.Close();
        }
    }
}
