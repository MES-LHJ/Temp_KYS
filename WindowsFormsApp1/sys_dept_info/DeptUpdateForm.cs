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
using WindowsFormsApp1.api;
using WindowsFormsApp1.helper;

namespace WindowsFormsApp1.sys_dept_info
{
    public partial class DeptUpdateForm : Form
    {
        private Dept dataDeptInfo;

        public bool DeptUpdateFg { get; private set; } = false;

        private readonly int id;

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
            this.Load += DeptUpdateForm_Load;
            this.KeyDown += DeptUpdateForm_KeyDown;
            txtRemarkDc.KeyDown += TxtRemarkDc_KeyDown;

            btnAct.Click += BtnAct_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        public DeptUpdateForm(int id)
        {
            this.id = id;
            InitializeComponent();
            InitEvent();
        }

        // ------------
        // 이벤트 정의
        // ------------

        // 폼 Load 이벤트
        public void DeptUpdateForm_Load(object sender, EventArgs e)
        {
            DeptSetData();
        }

        // 폼 KeyDown 이벤트
        private void DeptUpdateForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // 엔터키
                case Keys.Enter:
                    this.SelectNextControl(this.ActiveControl, true, true, true, false);
                    break;

                // 저장(F4)
                case Keys.F4:
                    DeptUpdateCheck();
                    break;

                // 닫기(ESC)
                case Keys.Escape:
                    DeptClose();
                    break;

                default:
                    break;
            }
        }

        // input 비고 KeyDown 이벤트
        private void TxtRemarkDc_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    DeptUpdateCheck();
                    break;

                default:
                    break;
            }
        }

        // 저장 버튼 클릭 이벤트
        private void BtnAct_Click(object sender, EventArgs e)
        {
            DeptUpdateCheck();
        }

        // 닫기 버튼 클릭 이벤트
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DeptClose();
        }


        // ------------
        // 메서드 정의
        // ------------

        // 부서 데이터 SET
        public async void DeptSetData()
        {
            try
            {
                var result = await ApiDeptRepository.Instance.GetDept(1);

                if (!string.IsNullOrEmpty(result.Error))
                {
                    MessageBox.Show($"부서 조회 실패: {result.Error}");
                    return;
                }

                dataDeptInfo = result.Data.FirstOrDefault(u => u.Id == id);

                DeptCdText = dataDeptInfo.DeptCd;
                DeptNameText = dataDeptInfo.DeptName;
                RemarkDcText = dataDeptInfo.RemarkDc;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"조회 중 오류가 발생했습니다.\n{ex.Message}");
            }

            //dataDeptInfo = DeptRepository.Instance.GetDeptById(id);

            //if (dataDeptInfo == null)
            //{
            //    MessageBox.Show("해당 부서 정보를 찾을 수 없습니다.");
            //    this.Close();
            //}
            //else
            //{
            //    DeptCdText = dataDeptInfo.DeptCd;
            //    DeptNameText = dataDeptInfo.DeptName;
            //    RemarkDcText = dataDeptInfo.RemarkDc;
            //}
        }

        // 수정된 데이터 존재 여부 체크
        private void DeptUpdateCheck()
        {
            bool fieldUpdateFg = false;

            if (!fieldUpdateFg && DeptCdText != dataDeptInfo.DeptCd) fieldUpdateFg = true;
            if (!fieldUpdateFg && DeptNameText != dataDeptInfo.DeptName) fieldUpdateFg = true;
            if (!fieldUpdateFg && RemarkDcText != dataDeptInfo.RemarkDc) fieldUpdateFg = true;

            if (!fieldUpdateFg)
            {
                MessageBox.Show("수정된 데이터가 없습니다.");
                return;
            }

            DeptReg();
        }

        // 부서 저장
        private async void DeptReg()
        {
            if (dataDeptInfo == null) return;

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
                var updatedDept = new Dept
                {
                    Id = dataDeptInfo.Id,
                    DeptCd = DeptCdText,
                    DeptName = DeptNameText,
                    RemarkDc = RemarkDcText
                };

                try
                {
                    var result = await ApiDeptRepository.Instance.UpdateDept(updatedDept);

                    if (!string.IsNullOrEmpty(result.Error))
                    {
                        MessageBox.Show($"부서 수정 실패: {result.Error}");
                        return;
                    }

                    DeptUpdateFg = true;
                    MessageBox.Show("저장되었습니다.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"부서 수정 중 오류가 발생했습니다.\n{ex.Message}");
                    txtDeptCd.Focus();
                }

                //int result = DeptRepository.Instance.UpdateDept(dataDeptInfo);

                //switch (result)
                //{
                //    case int n when n > 0:
                //        DeptUpdateFg = true;
                //        MessageBox.Show("수정되었습니다.");
                //        this.Close();
                //        break;

                //    case -1:
                //        MessageBox.Show("이미 존재하는 부서코드 입니다.");
                //        txtDeptCd.Focus();
                //        break;

                //    case -2:
                //        MessageBox.Show("수정 중 오류가 발생했습니다.");
                //        break;

                //    default:
                //        MessageBox.Show("수정에 실패했습니다.");
                //        break;
                //}
            }
        }

        // 폼 닫기
        private void DeptClose()
        {
            DeptUpdateFg = false;
            this.Close();
        }
    }
}
