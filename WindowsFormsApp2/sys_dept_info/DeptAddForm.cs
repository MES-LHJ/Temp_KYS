using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.helper;
using DevExpress.XtraEditors;

namespace WindowsFormsApp2.sys_dept_info
{
    public partial class DeptAddForm : XtraForm
    {
        private Dept dataDeptInfo = new Dept();
        
        public bool DeptInsertFg { get; private set; } = false;

        private readonly int idUpperDept;

        //-----------
        // 속성 설정
        //-----------

        // 부서코드
        public string DeptCdText
        {
            get => txtDeptCd.Text.Trim();
            set => txtDeptCd.Text = value;
        }

        // 부서명
        public string DeptNameText
        {
            get => txtDeptName.Text.Trim();
            set => txtDeptName.Text = value;
        }

        // 메모
        public string RemarkDcText
        {
            get => txtRemarkDc.Text.Trim();
            set => txtRemarkDc.Text = value;
        }

        // 이벤트 핸들러
        private void InitEvent()
        {
            btnAct.Click += BtnAct_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        public DeptAddForm(int idUpperDept)
        {
            this.idUpperDept = idUpperDept;
            InitializeComponent();
            InitEvent();
        }

        // ------------
        // 이벤트 정의
        // ------------

        // 저장 버튼 클릭 이벤트
        private void BtnAct_Click(object sender, EventArgs e)
        {
            DeptReg();
        }

        // 취소 버튼 클릭 이벤트
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DeptClose();
        }

        // ------------
        // 메서드 정의
        // ------------

        // 부서 저장
        private void DeptReg()
        {
            if (string.IsNullOrEmpty(DeptCdText))
            {
                MessageBox.Show("부서코드가 입력되지 않았습니다.");
                txtDeptCd.Focus();
                return;
            }

            if (string.IsNullOrEmpty(DeptNameText))
            {
                MessageBox.Show("부서명이 입력되지 않았습니다.");
                txtDeptName.Focus();
                return;
            }

            if (MessageBox.Show("저장하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dataDeptInfo.IdUpperDept = idUpperDept;
                dataDeptInfo.DeptCd = DeptCdText;
                dataDeptInfo.DeptName = DeptNameText;
                dataDeptInfo.RemarkDc = RemarkDcText;

                int result = DeptRepository.Instance.AddDept(dataDeptInfo);

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

        // 폼 닫기
        private void DeptClose()
        {
            DeptInsertFg = false;
            this.Close();
        }
    }
}
