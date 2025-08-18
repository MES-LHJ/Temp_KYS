namespace WindowsFormsApp1
{
    partial class UserInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Label();
            this.btnLoginInfo = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Label();
            this.btnDept = new System.Windows.Forms.Label();
            this.btnSrch = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DeptCd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserLoginId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserPass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserRank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserEmpType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserMessengerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemarkDc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdDept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnChange);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnLoginInfo);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnDept);
            this.panel1.Controls.Add(this.btnSrch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1243, 45);
            this.panel1.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("굴림", 11F);
            this.btnClose.Location = new System.Drawing.Point(1155, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 15);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "닫기(ESC)";
            // 
            // btnChange
            // 
            this.btnChange.AutoSize = true;
            this.btnChange.Font = new System.Drawing.Font("굴림", 11F);
            this.btnChange.Location = new System.Drawing.Point(1070, 12);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(67, 15);
            this.btnChange.TabIndex = 7;
            this.btnChange.Text = "자료변환";
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.Font = new System.Drawing.Font("굴림", 11F);
            this.btnDelete.Location = new System.Drawing.Point(988, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 15);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "삭제(F7)";
            // 
            // btnLoginInfo
            // 
            this.btnLoginInfo.AutoSize = true;
            this.btnLoginInfo.Font = new System.Drawing.Font("굴림", 11F);
            this.btnLoginInfo.Location = new System.Drawing.Point(891, 12);
            this.btnLoginInfo.Name = "btnLoginInfo";
            this.btnLoginInfo.Size = new System.Drawing.Size(82, 15);
            this.btnLoginInfo.TabIndex = 5;
            this.btnLoginInfo.Text = "로그인정보";
            // 
            // btnUpdate
            // 
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.Font = new System.Drawing.Font("굴림", 11F);
            this.btnUpdate.Location = new System.Drawing.Point(837, 12);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(37, 15);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "수정";
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Font = new System.Drawing.Font("굴림", 11F);
            this.btnAdd.Location = new System.Drawing.Point(758, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(65, 15);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "추가(F1)";
            // 
            // btnDept
            // 
            this.btnDept.AutoSize = true;
            this.btnDept.Font = new System.Drawing.Font("굴림", 11F);
            this.btnDept.Location = new System.Drawing.Point(618, 12);
            this.btnDept.Name = "btnDept";
            this.btnDept.Size = new System.Drawing.Size(37, 15);
            this.btnDept.TabIndex = 2;
            this.btnDept.Text = "부서";
            // 
            // btnSrch
            // 
            this.btnSrch.AutoSize = true;
            this.btnSrch.Font = new System.Drawing.Font("굴림", 11F);
            this.btnSrch.Location = new System.Drawing.Point(675, 12);
            this.btnSrch.Name = "btnSrch";
            this.btnSrch.Size = new System.Drawing.Size(65, 15);
            this.btnSrch.TabIndex = 1;
            this.btnSrch.Text = "조회(F2)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 13F);
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "부서사원";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeptCd,
            this.DeptName,
            this.UserId,
            this.UserName,
            this.UserLoginId,
            this.UserPass,
            this.UserRank,
            this.UserEmpType,
            this.UserTel,
            this.UserEmail,
            this.UserMessengerId,
            this.RemarkDc,
            this.Id,
            this.IdDept});
            this.dataGridView1.Location = new System.Drawing.Point(12, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1243, 300);
            this.dataGridView1.TabIndex = 3;
            // 
            // DeptCd
            // 
            this.DeptCd.DataPropertyName = "DeptCd";
            this.DeptCd.HeaderText = "부서코드";
            this.DeptCd.Name = "DeptCd";
            this.DeptCd.ReadOnly = true;
            // 
            // DeptName
            // 
            this.DeptName.DataPropertyName = "DeptName";
            this.DeptName.HeaderText = "부서명";
            this.DeptName.Name = "DeptName";
            this.DeptName.ReadOnly = true;
            // 
            // UserId
            // 
            this.UserId.DataPropertyName = "UserId";
            this.UserId.HeaderText = "사원코드";
            this.UserId.Name = "UserId";
            this.UserId.ReadOnly = true;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "사원명";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // UserLoginId
            // 
            this.UserLoginId.DataPropertyName = "UserLoginId";
            this.UserLoginId.HeaderText = "로그인ID";
            this.UserLoginId.Name = "UserLoginId";
            this.UserLoginId.ReadOnly = true;
            // 
            // UserPass
            // 
            this.UserPass.DataPropertyName = "UserPass";
            this.UserPass.HeaderText = "비밀번호";
            this.UserPass.Name = "UserPass";
            this.UserPass.ReadOnly = true;
            // 
            // UserRank
            // 
            this.UserRank.DataPropertyName = "UserRank";
            this.UserRank.HeaderText = "직위";
            this.UserRank.Name = "UserRank";
            this.UserRank.ReadOnly = true;
            // 
            // UserEmpType
            // 
            this.UserEmpType.DataPropertyName = "UserEmpType";
            this.UserEmpType.HeaderText = "고용형태";
            this.UserEmpType.Name = "UserEmpType";
            this.UserEmpType.ReadOnly = true;
            // 
            // UserTel
            // 
            this.UserTel.DataPropertyName = "UserTel";
            this.UserTel.HeaderText = "휴대전화";
            this.UserTel.Name = "UserTel";
            this.UserTel.ReadOnly = true;
            // 
            // UserEmail
            // 
            this.UserEmail.DataPropertyName = "UserEmail";
            this.UserEmail.HeaderText = "이메일";
            this.UserEmail.Name = "UserEmail";
            this.UserEmail.ReadOnly = true;
            // 
            // UserMessengerId
            // 
            this.UserMessengerId.DataPropertyName = "UserMessengerId";
            this.UserMessengerId.HeaderText = "메신저ID";
            this.UserMessengerId.Name = "UserMessengerId";
            this.UserMessengerId.ReadOnly = true;
            // 
            // RemarkDc
            // 
            this.RemarkDc.DataPropertyName = "RemarkDc";
            this.RemarkDc.HeaderText = "비고";
            this.RemarkDc.Name = "RemarkDc";
            this.RemarkDc.ReadOnly = true;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // IdDept
            // 
            this.IdDept.DataPropertyName = "IdDept";
            this.IdDept.HeaderText = "IdDept";
            this.IdDept.Name = "IdDept";
            this.IdDept.ReadOnly = true;
            this.IdDept.Visible = false;
            // 
            // UserInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 461);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "UserInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "부서사원";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label btnClose;
        private System.Windows.Forms.Label btnChange;
        private System.Windows.Forms.Label btnDelete;
        private System.Windows.Forms.Label btnLoginInfo;
        private System.Windows.Forms.Label btnUpdate;
        private System.Windows.Forms.Label btnAdd;
        private System.Windows.Forms.Label btnDept;
        private System.Windows.Forms.Label btnSrch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeptCd;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserLoginId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserPass;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserRank;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserEmpType;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserMessengerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn RemarkDc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDept;
    }
}