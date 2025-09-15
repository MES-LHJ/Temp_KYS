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
    public partial class UpperDeptUpdateForm : XtraForm
    {
        private UpperDept dataUpperDeptInfo;

        public bool UpperDeptUpdateFg { get; private set; } = false;

        private readonly int id;

        // 부서코드
        private string UpperDeptCdText
        {
            get => txtUpperDeptCd.Text.Trim();
            set => txtUpperDeptCd.Text = value;
        }

        // 부서명
        private string UpperDeptNameText
        {
            get => txtUpperDeptName.Text.Trim();
            set => txtUpperDeptName.Text = value;
        }

        // 메모
        private string UpperRemarkDcText
        {
            get => txtUpperRemarkDc.Text.Trim();
            set => txtUpperRemarkDc.Text = value;
        }

        // 이벤트 핸들러
        private void InitEvent()
        {
            this.Load += UpperDeptUpdateForm_Load;

            btnAct.Click += BtnAct_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        public UpperDeptUpdateForm(int id)
        {
            this.id = id;
            InitializeComponent();
            InitEvent();
        }

        // ------------
        // 이벤트 정의
        // ------------

        // 폼 Load 이벤트
        private void UpperDeptUpdateForm_Load(object sender, EventArgs e)
        {
            UpperDeptSetData();
        }

        // 저장 버튼 클릭 이벤트
        private void BtnAct_Click(object sender, EventArgs e)
        {
            UpperDeptUpdateCheck();
        }

        // 닫기 버튼 클릭 이벤트
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            UpperDeptClose();
        }

        // ------------
        // 메서드 정의
        // ------------

        // 부서 데이터 SET
        private void UpperDeptSetData()
        {
            dataUpperDeptInfo = UpperDeptRepository.Instance.GetUpperDeptById(id);

            if (dataUpperDeptInfo == null)
            {
                MessageBox.Show("해당 부서 정보를 찾을 수 없습니다.");
                this.Close();
            }
            else
            {
                UpperDeptCdText = dataUpperDeptInfo.UpperDeptCd;
                UpperDeptNameText = dataUpperDeptInfo.UpperDeptName;
                UpperRemarkDcText = dataUpperDeptInfo.UpperRemarkDc;
            }
        }

        // 수정된 데이터 존재 여부 체크
        private void UpperDeptUpdateCheck()
        {
            bool fieldUpdateFg = false;

            if (!fieldUpdateFg && UpperDeptCdText != dataUpperDeptInfo.UpperDeptCd) fieldUpdateFg = true;
            if (!fieldUpdateFg && UpperDeptNameText != dataUpperDeptInfo.UpperDeptName) fieldUpdateFg = true;
            if (!fieldUpdateFg && UpperRemarkDcText != dataUpperDeptInfo.UpperRemarkDc) fieldUpdateFg = true;

            if (!fieldUpdateFg)
            {
                MessageBox.Show("수정된 데이터가 없습니다.");
                return;
            }

            DeptReg();
        }

        // 부서 저장
        private void DeptReg()
        {
            if (dataUpperDeptInfo == null) return;

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
                var updatedDept = new UpperDept
                {
                    Id = dataUpperDeptInfo.Id,
                    UpperDeptCd = UpperDeptCdText,
                    UpperDeptName = UpperDeptNameText,
                    UpperRemarkDc = UpperRemarkDcText
                };

                int result = UpperDeptRepository.Instance.UpdateUpperDept(updatedDept);

                switch (result)
                {
                    case int n when n > 0:
                        UpperDeptUpdateFg = true;
                        MessageBox.Show("수정되었습니다.");
                        this.Close();
                        break;

                    case -1:
                        MessageBox.Show("이미 존재하는 부서코드 입니다.");
                        txtUpperDeptCd.Focus();
                        break;

                    case -2:
                        MessageBox.Show("수정 중 오류가 발생했습니다.");
                        break;

                    default:
                        MessageBox.Show("수정에 실패했습니다.");
                        break;
                }
            }
        }

        // 폼 닫기
        private void UpperDeptClose()
        {
            UpperDeptUpdateFg = false;
            this.Close();
        }
    }
}
