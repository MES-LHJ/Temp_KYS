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
            this.selectDeptCd = new System.Windows.Forms.ComboBox();
            this.txtUserMessengerId = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtUserEmail = new System.Windows.Forms.TextBox();
            this.txtUserTel = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUserEmpType = new System.Windows.Forms.TextBox();
            this.txtUserRank = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAct = new System.Windows.Forms.Button();
            this.txtRemarkDc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDeptName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.chkUserGender2 = new System.Windows.Forms.CheckBox();
            this.chkUserGender1 = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnClearImage = new System.Windows.Forms.Button();
            this.userImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.userImage)).BeginInit();
            this.SuspendLayout();
            // 
            // selectDeptCd
            // 
            this.selectDeptCd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectDeptCd.FormattingEnabled = true;
            this.selectDeptCd.Items.AddRange(new object[] {
            "관리부",
            "영업부",
            "개발부"});
            this.selectDeptCd.Location = new System.Drawing.Point(24, 50);
            this.selectDeptCd.Name = "selectDeptCd";
            this.selectDeptCd.Size = new System.Drawing.Size(170, 20);
            this.selectDeptCd.TabIndex = 39;
            this.selectDeptCd.UseWaitCursor = true;
            // 
            // txtUserMessengerId
            // 
            this.txtUserMessengerId.Location = new System.Drawing.Point(414, 288);
            this.txtUserMessengerId.Name = "txtUserMessengerId";
            this.txtUserMessengerId.Size = new System.Drawing.Size(170, 21);
            this.txtUserMessengerId.TabIndex = 49;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(412, 267);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 12);
            this.label12.TabIndex = 64;
            this.label12.Text = "메신저ID";
            // 
            // txtUserEmail
            // 
            this.txtUserEmail.Location = new System.Drawing.Point(218, 288);
            this.txtUserEmail.Name = "txtUserEmail";
            this.txtUserEmail.Size = new System.Drawing.Size(170, 21);
            this.txtUserEmail.TabIndex = 48;
            // 
            // txtUserTel
            // 
            this.txtUserTel.Location = new System.Drawing.Point(26, 288);
            this.txtUserTel.Name = "txtUserTel";
            this.txtUserTel.Size = new System.Drawing.Size(170, 21);
            this.txtUserTel.TabIndex = 47;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(216, 267);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 63;
            this.label10.Text = "이메일";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(23, 267);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 62;
            this.label11.Text = "휴대전화";
            // 
            // txtUserEmpType
            // 
            this.txtUserEmpType.Location = new System.Drawing.Point(217, 229);
            this.txtUserEmpType.Name = "txtUserEmpType";
            this.txtUserEmpType.Size = new System.Drawing.Size(170, 21);
            this.txtUserEmpType.TabIndex = 44;
            // 
            // txtUserRank
            // 
            this.txtUserRank.Location = new System.Drawing.Point(25, 229);
            this.txtUserRank.Name = "txtUserRank";
            this.txtUserRank.Size = new System.Drawing.Size(170, 21);
            this.txtUserRank.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(215, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 61;
            this.label8.Text = "고용형태";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(22, 208);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 60;
            this.label9.Text = "직위";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(216, 109);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(170, 21);
            this.txtUserName.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(214, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 57;
            this.label4.Text = "사원명";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(21, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 56;
            this.label5.Text = "사원코드";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.OrangeRed;
            this.btnClose.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(473, 391);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 35);
            this.btnClose.TabIndex = 52;
            this.btnClose.Text = "취소(ESC)";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // btnAct
            // 
            this.btnAct.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAct.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAct.ForeColor = System.Drawing.Color.White;
            this.btnAct.Location = new System.Drawing.Point(354, 391);
            this.btnAct.Margin = new System.Windows.Forms.Padding(0);
            this.btnAct.Name = "btnAct";
            this.btnAct.Size = new System.Drawing.Size(110, 35);
            this.btnAct.TabIndex = 51;
            this.btnAct.Text = "저장(F4)";
            this.btnAct.UseVisualStyleBackColor = false;
            // 
            // txtRemarkDc
            // 
            this.txtRemarkDc.Location = new System.Drawing.Point(25, 350);
            this.txtRemarkDc.Name = "txtRemarkDc";
            this.txtRemarkDc.Size = new System.Drawing.Size(559, 21);
            this.txtRemarkDc.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(24, 329);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 55;
            this.label3.Text = "메모";
            // 
            // txtDeptName
            // 
            this.txtDeptName.Location = new System.Drawing.Point(216, 50);
            this.txtDeptName.Name = "txtDeptName";
            this.txtDeptName.ReadOnly = true;
            this.txtDeptName.Size = new System.Drawing.Size(170, 21);
            this.txtDeptName.TabIndex = 40;
            this.txtDeptName.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(214, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 54;
            this.label2.Text = "부서명";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(21, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 53;
            this.label1.Text = "부서코드";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(26, 109);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(170, 21);
            this.txtUserId.TabIndex = 41;
            // 
            // chkUserGender2
            // 
            this.chkUserGender2.AutoSize = true;
            this.chkUserGender2.Location = new System.Drawing.Point(456, 231);
            this.chkUserGender2.Name = "chkUserGender2";
            this.chkUserGender2.Size = new System.Drawing.Size(36, 16);
            this.chkUserGender2.TabIndex = 46;
            this.chkUserGender2.Text = "여";
            this.chkUserGender2.UseVisualStyleBackColor = true;
            // 
            // chkUserGender1
            // 
            this.chkUserGender1.AutoSize = true;
            this.chkUserGender1.Location = new System.Drawing.Point(414, 231);
            this.chkUserGender1.Name = "chkUserGender1";
            this.chkUserGender1.Size = new System.Drawing.Size(36, 16);
            this.chkUserGender1.TabIndex = 45;
            this.chkUserGender1.Text = "남";
            this.chkUserGender1.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(412, 208);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 67;
            this.label13.Text = "성별";
            // 
            // btnClearImage
            // 
            this.btnClearImage.BackColor = System.Drawing.Color.DarkGray;
            this.btnClearImage.ForeColor = System.Drawing.Color.White;
            this.btnClearImage.Location = new System.Drawing.Point(414, 162);
            this.btnClearImage.Name = "btnClearImage";
            this.btnClearImage.Size = new System.Drawing.Size(150, 30);
            this.btnClearImage.TabIndex = 69;
            this.btnClearImage.TabStop = false;
            this.btnClearImage.Text = "이미지 비우기";
            this.btnClearImage.UseVisualStyleBackColor = false;
            // 
            // userImage
            // 
            this.userImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userImage.Location = new System.Drawing.Point(414, 12);
            this.userImage.Name = "userImage";
            this.userImage.Size = new System.Drawing.Size(150, 150);
            this.userImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userImage.TabIndex = 68;
            this.userImage.TabStop = false;
            // 
            // UserUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 441);
            this.Controls.Add(this.btnClearImage);
            this.Controls.Add(this.userImage);
            this.Controls.Add(this.chkUserGender2);
            this.Controls.Add(this.chkUserGender1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.selectDeptCd);
            this.Controls.Add(this.txtUserMessengerId);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtUserEmail);
            this.Controls.Add(this.txtUserTel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtUserEmpType);
            this.Controls.Add(this.txtUserRank);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAct);
            this.Controls.Add(this.txtRemarkDc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDeptName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "UserUpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "사원 수정";
            ((System.ComponentModel.ISupportInitialize)(this.userImage)).EndInit();
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
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAct;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox selectDeptCd;
        public System.Windows.Forms.TextBox txtUserName;
        public System.Windows.Forms.TextBox txtDeptName;
        public System.Windows.Forms.TextBox txtUserMessengerId;
        public System.Windows.Forms.TextBox txtUserEmail;
        public System.Windows.Forms.TextBox txtUserTel;
        public System.Windows.Forms.TextBox txtUserEmpType;
        public System.Windows.Forms.TextBox txtUserRank;
        public System.Windows.Forms.TextBox txtRemarkDc;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.CheckBox chkUserGender2;
        private System.Windows.Forms.CheckBox chkUserGender1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnClearImage;
        private System.Windows.Forms.PictureBox userImage;
    }
}