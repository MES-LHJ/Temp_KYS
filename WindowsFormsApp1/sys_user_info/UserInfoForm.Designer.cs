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
            this.btn_close = new System.Windows.Forms.Label();
            this.btn_change = new System.Windows.Forms.Label();
            this.btn_delete = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Label();
            this.btn_update = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Label();
            this.btn_dept = new System.Windows.Forms.Label();
            this.btn_srch = new System.Windows.Forms.Label();
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
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Controls.Add(this.btn_change);
            this.panel1.Controls.Add(this.btn_delete);
            this.panel1.Controls.Add(this.btn_login);
            this.panel1.Controls.Add(this.btn_update);
            this.panel1.Controls.Add(this.btn_add);
            this.panel1.Controls.Add(this.btn_dept);
            this.panel1.Controls.Add(this.btn_srch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1243, 45);
            this.panel1.TabIndex = 2;
            // 
            // btn_close
            // 
            this.btn_close.AutoSize = true;
            this.btn_close.Font = new System.Drawing.Font("굴림", 11F);
            this.btn_close.Location = new System.Drawing.Point(1155, 12);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(78, 15);
            this.btn_close.TabIndex = 8;
            this.btn_close.Text = "닫기(ESC)";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_change
            // 
            this.btn_change.AutoSize = true;
            this.btn_change.Font = new System.Drawing.Font("굴림", 11F);
            this.btn_change.Location = new System.Drawing.Point(1070, 12);
            this.btn_change.Name = "btn_change";
            this.btn_change.Size = new System.Drawing.Size(67, 15);
            this.btn_change.TabIndex = 7;
            this.btn_change.Text = "자료변환";
            this.btn_change.Click += new System.EventHandler(this.btn_change_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.AutoSize = true;
            this.btn_delete.Font = new System.Drawing.Font("굴림", 11F);
            this.btn_delete.Location = new System.Drawing.Point(988, 12);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(65, 15);
            this.btn_delete.TabIndex = 6;
            this.btn_delete.Text = "삭제(F7)";
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_login
            // 
            this.btn_login.AutoSize = true;
            this.btn_login.Font = new System.Drawing.Font("굴림", 11F);
            this.btn_login.Location = new System.Drawing.Point(891, 12);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(82, 15);
            this.btn_login.TabIndex = 5;
            this.btn_login.Text = "로그인정보";
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_update
            // 
            this.btn_update.AutoSize = true;
            this.btn_update.Font = new System.Drawing.Font("굴림", 11F);
            this.btn_update.Location = new System.Drawing.Point(837, 12);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(37, 15);
            this.btn_update.TabIndex = 4;
            this.btn_update.Text = "수정";
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_add
            // 
            this.btn_add.AutoSize = true;
            this.btn_add.Font = new System.Drawing.Font("굴림", 11F);
            this.btn_add.Location = new System.Drawing.Point(758, 12);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(65, 15);
            this.btn_add.TabIndex = 3;
            this.btn_add.Text = "추가(F1)";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_dept
            // 
            this.btn_dept.AutoSize = true;
            this.btn_dept.Font = new System.Drawing.Font("굴림", 11F);
            this.btn_dept.Location = new System.Drawing.Point(618, 12);
            this.btn_dept.Name = "btn_dept";
            this.btn_dept.Size = new System.Drawing.Size(37, 15);
            this.btn_dept.TabIndex = 2;
            this.btn_dept.Text = "부서";
            this.btn_dept.Click += new System.EventHandler(this.BtnDept_Click);
            // 
            // btn_srch
            // 
            this.btn_srch.AutoSize = true;
            this.btn_srch.Font = new System.Drawing.Font("굴림", 11F);
            this.btn_srch.Location = new System.Drawing.Point(675, 12);
            this.btn_srch.Name = "btn_srch";
            this.btn_srch.Size = new System.Drawing.Size(65, 15);
            this.btn_srch.TabIndex = 1;
            this.btn_srch.Text = "조회(F2)";
            this.btn_srch.Click += new System.EventHandler(this.btn_srch_Click);
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
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
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
            // user_info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 461);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "user_info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "부서사원";
            this.Load += new System.EventHandler(this.UserInfo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.user_info_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label btn_close;
        private System.Windows.Forms.Label btn_change;
        private System.Windows.Forms.Label btn_delete;
        private System.Windows.Forms.Label btn_login;
        private System.Windows.Forms.Label btn_update;
        private System.Windows.Forms.Label btn_add;
        private System.Windows.Forms.Label btn_dept;
        private System.Windows.Forms.Label btn_srch;
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