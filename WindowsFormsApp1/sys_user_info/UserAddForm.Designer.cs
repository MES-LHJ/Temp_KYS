namespace WindowsFormsApp1
{
    partial class UserAddForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAct = new System.Windows.Forms.Button();
            this.txtRemarkDc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDeptName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserPass = new System.Windows.Forms.TextBox();
            this.txtUserLoginId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUserEmpType = new System.Windows.Forms.TextBox();
            this.txtUserRank = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUserEmail = new System.Windows.Forms.TextBox();
            this.txtUserTel = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUserMessengerId = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.selectDeptCd = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.OrangeRed;
            this.btnCancel.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(473, 390);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 35);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "취소(ESC)";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnAct
            // 
            this.btnAct.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAct.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAct.ForeColor = System.Drawing.Color.White;
            this.btnAct.Location = new System.Drawing.Point(354, 390);
            this.btnAct.Margin = new System.Windows.Forms.Padding(0);
            this.btnAct.Name = "btnAct";
            this.btnAct.Size = new System.Drawing.Size(110, 35);
            this.btnAct.TabIndex = 13;
            this.btnAct.Text = "저장(F4)";
            this.btnAct.UseVisualStyleBackColor = false;
            // 
            // txtRemarkDc
            // 
            this.txtRemarkDc.Location = new System.Drawing.Point(25, 349);
            this.txtRemarkDc.Name = "txtRemarkDc";
            this.txtRemarkDc.Size = new System.Drawing.Size(559, 21);
            this.txtRemarkDc.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(24, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "메모";
            // 
            // txtDeptName
            // 
            this.txtDeptName.Location = new System.Drawing.Point(216, 50);
            this.txtDeptName.Name = "txtDeptName";
            this.txtDeptName.ReadOnly = true;
            this.txtDeptName.Size = new System.Drawing.Size(170, 21);
            this.txtDeptName.TabIndex = 2;
            this.txtDeptName.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(214, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "부서명";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(21, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "부서코드";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(216, 109);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(170, 21);
            this.txtUserName.TabIndex = 4;
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(24, 109);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(170, 21);
            this.txtUserId.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(214, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 23;
            this.label4.Text = "사원명";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(21, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "사원코드";
            // 
            // txtUserPass
            // 
            this.txtUserPass.Location = new System.Drawing.Point(216, 168);
            this.txtUserPass.Name = "txtUserPass";
            this.txtUserPass.PasswordChar = '*';
            this.txtUserPass.Size = new System.Drawing.Size(170, 21);
            this.txtUserPass.TabIndex = 6;
            // 
            // txtUserLoginId
            // 
            this.txtUserLoginId.Location = new System.Drawing.Point(24, 168);
            this.txtUserLoginId.Name = "txtUserLoginId";
            this.txtUserLoginId.Size = new System.Drawing.Size(170, 21);
            this.txtUserLoginId.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(214, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 27;
            this.label6.Text = "비밀번호";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(21, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "로그인ID";
            // 
            // txtUserEmpType
            // 
            this.txtUserEmpType.Location = new System.Drawing.Point(217, 228);
            this.txtUserEmpType.Name = "txtUserEmpType";
            this.txtUserEmpType.Size = new System.Drawing.Size(170, 21);
            this.txtUserEmpType.TabIndex = 8;
            // 
            // txtUserRank
            // 
            this.txtUserRank.Location = new System.Drawing.Point(25, 228);
            this.txtUserRank.Name = "txtUserRank";
            this.txtUserRank.Size = new System.Drawing.Size(170, 21);
            this.txtUserRank.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(215, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 31;
            this.label8.Text = "고용형태";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(22, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 30;
            this.label9.Text = "직위";
            // 
            // txtUserEmail
            // 
            this.txtUserEmail.Location = new System.Drawing.Point(218, 287);
            this.txtUserEmail.Name = "txtUserEmail";
            this.txtUserEmail.Size = new System.Drawing.Size(170, 21);
            this.txtUserEmail.TabIndex = 10;
            // 
            // txtUserTel
            // 
            this.txtUserTel.Location = new System.Drawing.Point(26, 287);
            this.txtUserTel.Name = "txtUserTel";
            this.txtUserTel.Size = new System.Drawing.Size(170, 21);
            this.txtUserTel.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(216, 266);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 35;
            this.label10.Text = "이메일";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(23, 266);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 34;
            this.label11.Text = "휴대전화";
            // 
            // txtUserMessengerId
            // 
            this.txtUserMessengerId.Location = new System.Drawing.Point(414, 287);
            this.txtUserMessengerId.Name = "txtUserMessengerId";
            this.txtUserMessengerId.Size = new System.Drawing.Size(170, 21);
            this.txtUserMessengerId.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(412, 266);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 12);
            this.label12.TabIndex = 38;
            this.label12.Text = "메신저ID";
            // 
            // selectDeptCd
            // 
            this.selectDeptCd.CausesValidation = false;
            this.selectDeptCd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectDeptCd.FormattingEnabled = true;
            this.selectDeptCd.Location = new System.Drawing.Point(24, 50);
            this.selectDeptCd.Name = "selectDeptCd";
            this.selectDeptCd.Size = new System.Drawing.Size(170, 20);
            this.selectDeptCd.TabIndex = 1;
            // 
            // UserAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(614, 441);
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
            this.Controls.Add(this.txtUserPass);
            this.Controls.Add(this.txtUserLoginId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAct);
            this.Controls.Add(this.txtRemarkDc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDeptName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "UserAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "사원 추가";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAct;
        private System.Windows.Forms.TextBox txtRemarkDc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDeptName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUserPass;
        private System.Windows.Forms.TextBox txtUserLoginId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUserEmpType;
        private System.Windows.Forms.TextBox txtUserRank;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUserEmail;
        private System.Windows.Forms.TextBox txtUserTel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtUserMessengerId;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox selectDeptCd;
    }
}