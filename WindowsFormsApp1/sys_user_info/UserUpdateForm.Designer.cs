namespace WindowsFormsApp1.sys_user_info
{
    partial class UserUpdateForm
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
            this.select_dept_cd = new System.Windows.Forms.ComboBox();
            this.input_user_messenger_id = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.input_user_email = new System.Windows.Forms.TextBox();
            this.input_user_tel = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.input_user_emp_type = new System.Windows.Forms.TextBox();
            this.input_user_rank = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.input_user_name = new System.Windows.Forms.TextBox();
            this.input_user_id = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_act = new System.Windows.Forms.Button();
            this.input_remark_dc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.input_dept_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // select_dept_cd
            // 
            this.select_dept_cd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.select_dept_cd.FormattingEnabled = true;
            this.select_dept_cd.Items.AddRange(new object[] {
            "관리부",
            "영업부",
            "개발부"});
            this.select_dept_cd.Location = new System.Drawing.Point(24, 52);
            this.select_dept_cd.Name = "select_dept_cd";
            this.select_dept_cd.Size = new System.Drawing.Size(170, 20);
            this.select_dept_cd.TabIndex = 39;
            this.select_dept_cd.UseWaitCursor = true;
            // 
            // input_user_messenger_id
            // 
            this.input_user_messenger_id.Location = new System.Drawing.Point(414, 232);
            this.input_user_messenger_id.Name = "input_user_messenger_id";
            this.input_user_messenger_id.Size = new System.Drawing.Size(170, 21);
            this.input_user_messenger_id.TabIndex = 49;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(412, 211);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 12);
            this.label12.TabIndex = 64;
            this.label12.Text = "메신저ID";
            // 
            // input_user_email
            // 
            this.input_user_email.Location = new System.Drawing.Point(218, 232);
            this.input_user_email.Name = "input_user_email";
            this.input_user_email.Size = new System.Drawing.Size(170, 21);
            this.input_user_email.TabIndex = 48;
            // 
            // input_user_tel
            // 
            this.input_user_tel.Location = new System.Drawing.Point(26, 232);
            this.input_user_tel.Name = "input_user_tel";
            this.input_user_tel.Size = new System.Drawing.Size(170, 21);
            this.input_user_tel.TabIndex = 47;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(216, 211);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 63;
            this.label10.Text = "이메일";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(23, 211);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 62;
            this.label11.Text = "휴대전화";
            // 
            // input_user_emp_type
            // 
            this.input_user_emp_type.Location = new System.Drawing.Point(217, 173);
            this.input_user_emp_type.Name = "input_user_emp_type";
            this.input_user_emp_type.Size = new System.Drawing.Size(170, 21);
            this.input_user_emp_type.TabIndex = 46;
            // 
            // input_user_rank
            // 
            this.input_user_rank.Location = new System.Drawing.Point(25, 173);
            this.input_user_rank.Name = "input_user_rank";
            this.input_user_rank.Size = new System.Drawing.Size(170, 21);
            this.input_user_rank.TabIndex = 45;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(215, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 61;
            this.label8.Text = "고용형태";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(22, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 60;
            this.label9.Text = "직위";
            // 
            // input_user_name
            // 
            this.input_user_name.Location = new System.Drawing.Point(216, 111);
            this.input_user_name.Name = "input_user_name";
            this.input_user_name.Size = new System.Drawing.Size(170, 21);
            this.input_user_name.TabIndex = 42;
            // 
            // input_user_id
            // 
            this.input_user_id.Location = new System.Drawing.Point(24, 111);
            this.input_user_id.Name = "input_user_id";
            this.input_user_id.ReadOnly = true;
            this.input_user_id.Size = new System.Drawing.Size(170, 21);
            this.input_user_id.TabIndex = 41;
            this.input_user_id.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(214, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 57;
            this.label4.Text = "사원명";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(21, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 56;
            this.label5.Text = "사원코드";
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_cancel.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.Location = new System.Drawing.Point(473, 335);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(0);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(110, 35);
            this.btn_cancel.TabIndex = 52;
            this.btn_cancel.Text = "취소(ESC)";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_act
            // 
            this.btn_act.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_act.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_act.ForeColor = System.Drawing.Color.White;
            this.btn_act.Location = new System.Drawing.Point(354, 335);
            this.btn_act.Margin = new System.Windows.Forms.Padding(0);
            this.btn_act.Name = "btn_act";
            this.btn_act.Size = new System.Drawing.Size(110, 35);
            this.btn_act.TabIndex = 51;
            this.btn_act.Text = "저장(F4)";
            this.btn_act.UseVisualStyleBackColor = false;
            this.btn_act.Click += new System.EventHandler(this.btn_act_Click);
            // 
            // input_remark_dc
            // 
            this.input_remark_dc.Location = new System.Drawing.Point(25, 294);
            this.input_remark_dc.Name = "input_remark_dc";
            this.input_remark_dc.Size = new System.Drawing.Size(559, 21);
            this.input_remark_dc.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(24, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 55;
            this.label3.Text = "메모";
            // 
            // input_dept_name
            // 
            this.input_dept_name.Location = new System.Drawing.Point(216, 52);
            this.input_dept_name.Name = "input_dept_name";
            this.input_dept_name.ReadOnly = true;
            this.input_dept_name.Size = new System.Drawing.Size(170, 21);
            this.input_dept_name.TabIndex = 40;
            this.input_dept_name.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(214, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 54;
            this.label2.Text = "부서명";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(21, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 53;
            this.label1.Text = "부서코드";
            // 
            // user_update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 385);
            this.Controls.Add(this.select_dept_cd);
            this.Controls.Add(this.input_user_messenger_id);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.input_user_email);
            this.Controls.Add(this.input_user_tel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.input_user_emp_type);
            this.Controls.Add(this.input_user_rank);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.input_user_name);
            this.Controls.Add(this.input_user_id);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_act);
            this.Controls.Add(this.input_remark_dc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.input_dept_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "user_update";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "사원 수정";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.user_update_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_act;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox select_dept_cd;
        public System.Windows.Forms.TextBox input_user_name;
        public System.Windows.Forms.TextBox input_user_id;
        public System.Windows.Forms.TextBox input_dept_name;
        public System.Windows.Forms.TextBox input_user_messenger_id;
        public System.Windows.Forms.TextBox input_user_email;
        public System.Windows.Forms.TextBox input_user_tel;
        public System.Windows.Forms.TextBox input_user_emp_type;
        public System.Windows.Forms.TextBox input_user_rank;
        public System.Windows.Forms.TextBox input_remark_dc;
    }
}