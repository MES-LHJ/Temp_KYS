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

namespace WindowsFormsApp2.sys_upperdept_info
{
    public partial class UpperDeptAddForm : XtraForm
    {
        private UpperDept dataUpperDeptInfo = new UpperDept();

        public bool UpperDeptInsertFg { get; private set; } = false;

        //-----------
        // 속성 설정
        //-----------

        // 부서코드
        public string UpperDeptCdText
        {
            get => txtUpperDeptCd.Text.Trim();
            set => txtUpperDeptCd.Text = value;
        }

        // 부서명
        public string UpperDeptNameText
        {
            get => txtUpperDeptName.Text.Trim();
            set => txtUpperDeptName.Text = value;
        }

        // 메모
        public string UpperRemarkDcText
        {
            get => txtUpperRemarkDc.Text.Trim();
            set => txtUpperRemarkDc.Text = value;
        }

        // 이벤트 핸들러
        private void InitEvent()
        {
            btnAct.Click += BtnAct_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        public UpperDeptAddForm()
        {
            InitializeComponent();
            InitEvent();
        }

        // ------------
        // 이벤트 정의
        // ------------

        // 저장 버튼 클릭 이벤트
        private void BtnAct_Click(object sender, EventArgs e)
        {
            UpperDeptReg();
        }

        // 취소 버튼 클릭 이벤트
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            UpperDeptClose();
        }

        // ------------
        // 메서드 정의
        // ------------

        // 부서 저장
        private void UpperDeptReg()
        {
            if (string.IsNullOrEmpty(UpperDeptCdText))
            {
                MessageBox.Show("부서코드가 입력되지 않았습니다.");
                txtUpperDeptCd.Focus();
                return;
            }

            if (string.IsNullOrEmpty(UpperDeptNameText))
            {
                MessageBox.Show("부서명이 입력되지 않았습니다.");
                txtUpperDeptName.Focus();
                return;
            }

            if (MessageBox.Show("저장하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dataUpperDeptInfo.UpperDeptCd = UpperDeptCdText;
                dataUpperDeptInfo.UpperDeptName = UpperDeptNameText;
                dataUpperDeptInfo.UpperRemarkDc = UpperRemarkDcText;

                int result = UpperDeptRepository.Instance.AddUpperDept(dataUpperDeptInfo);

                switch (result)
                {
                    case int n when n > 0:
                        UpperDeptInsertFg = true;
                        MessageBox.Show("저장되었습니다.");
                        this.Close();
                        break;

                    case -1:
                        MessageBox.Show("이미 존재하는 부서코드 입니다.");
                        txtUpperDeptCd.Focus();
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
        private void UpperDeptClose()
        {
            UpperDeptInsertFg = false;
            this.Close();
        }
    }
}
