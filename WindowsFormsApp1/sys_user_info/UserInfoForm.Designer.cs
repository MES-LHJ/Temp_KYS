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
            this.dept_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dept_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_login_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_pass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_rank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_emp_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_tel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_messenger_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark_dc = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
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
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
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
            this.btnLoginInfo.Click += new System.EventHandler(this.BtnLogin_Click);
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
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
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
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
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
            this.btnDept.Click += new System.EventHandler(this.BtnDept_Click);
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
            this.btnSrch.Click += new System.EventHandler(this.BtnSrch_Click);
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
            this.dept_cd,
            this.dept_name,
            this.user_id,
            this.user_name,
            this.user_login_id,
            this.user_pass,
            this.user_rank,
            this.user_emp_type,
            this.user_tel,
            this.user_email,
            this.user_messenger_id,
            this.remark_dc});
            this.dataGridView1.Location = new System.Drawing.Point(12, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1243, 300);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellDoubleClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridView1_CellFormatting);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridView1_KeyDown);
            // 
            // dept_cd
            // 
            this.dept_cd.DataPropertyName = "dept_cd";
            this.dept_cd.HeaderText = "부서코드";
            this.dept_cd.Name = "dept_cd";
            this.dept_cd.ReadOnly = true;
            // 
            // dept_name
            // 
            this.dept_name.DataPropertyName = "dept_name";
            this.dept_name.HeaderText = "부서명";
            this.dept_name.Name = "dept_name";
            this.dept_name.ReadOnly = true;
            // 
            // user_id
            // 
            this.user_id.DataPropertyName = "user_id";
            this.user_id.HeaderText = "사원코드";
            this.user_id.Name = "user_id";
            this.user_id.ReadOnly = true;
            // 
            // user_name
            // 
            this.user_name.DataPropertyName = "user_name";
            this.user_name.HeaderText = "사원명";
            this.user_name.Name = "user_name";
            this.user_name.ReadOnly = true;
            // 
            // user_login_id
            // 
            this.user_login_id.DataPropertyName = "user_login_id";
            this.user_login_id.HeaderText = "로그인ID";
            this.user_login_id.Name = "user_login_id";
            this.user_login_id.ReadOnly = true;
            // 
            // user_pass
            // 
            this.user_pass.DataPropertyName = "user_pass";
            this.user_pass.HeaderText = "비밀번호";
            this.user_pass.Name = "user_pass";
            this.user_pass.ReadOnly = true;
            // 
            // user_rank
            // 
            this.user_rank.DataPropertyName = "user_rank";
            this.user_rank.HeaderText = "직위";
            this.user_rank.Name = "user_rank";
            this.user_rank.ReadOnly = true;
            // 
            // user_emp_type
            // 
            this.user_emp_type.DataPropertyName = "user_emp_type";
            this.user_emp_type.HeaderText = "고용형태";
            this.user_emp_type.Name = "user_emp_type";
            this.user_emp_type.ReadOnly = true;
            // 
            // user_tel
            // 
            this.user_tel.DataPropertyName = "user_tel";
            this.user_tel.HeaderText = "휴대전화";
            this.user_tel.Name = "user_tel";
            this.user_tel.ReadOnly = true;
            // 
            // user_email
            // 
            this.user_email.DataPropertyName = "user_email";
            this.user_email.HeaderText = "이메일";
            this.user_email.Name = "user_email";
            this.user_email.ReadOnly = true;
            // 
            // user_messenger_id
            // 
            this.user_messenger_id.DataPropertyName = "user_messenger_id";
            this.user_messenger_id.HeaderText = "메신저ID";
            this.user_messenger_id.Name = "user_messenger_id";
            this.user_messenger_id.ReadOnly = true;
            // 
            // remark_dc
            // 
            this.remark_dc.DataPropertyName = "remark_dc";
            this.remark_dc.HeaderText = "비고";
            this.remark_dc.Name = "remark_dc";
            this.remark_dc.ReadOnly = true;
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
            this.Load += new System.EventHandler(this.UserInfo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserInfoForm_KeyDown);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dept_cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dept_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_login_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_pass;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_rank;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_emp_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_tel;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_email;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_messenger_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark_dc;
    }
}