namespace WindowsFormsApp1
{
    partial class index
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
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_log_in = new System.Windows.Forms.Button();
            this.user_pass = new System.Windows.Forms.TextBox();
            this.user_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.DarkGray;
            this.btn_close.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_close.ForeColor = System.Drawing.Color.White;
            this.btn_close.Location = new System.Drawing.Point(357, 98);
            this.btn_close.Margin = new System.Windows.Forms.Padding(0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(110, 35);
            this.btn_close.TabIndex = 11;
            this.btn_close.Text = "닫기";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_log_in
            // 
            this.btn_log_in.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_log_in.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_log_in.ForeColor = System.Drawing.Color.White;
            this.btn_log_in.Location = new System.Drawing.Point(238, 98);
            this.btn_log_in.Margin = new System.Windows.Forms.Padding(0);
            this.btn_log_in.Name = "btn_log_in";
            this.btn_log_in.Size = new System.Drawing.Size(110, 35);
            this.btn_log_in.TabIndex = 10;
            this.btn_log_in.Text = "로그인";
            this.btn_log_in.UseVisualStyleBackColor = false;
            this.btn_log_in.Click += new System.EventHandler(this.btn_log_in_Click);
            // 
            // user_pass
            // 
            this.user_pass.Location = new System.Drawing.Point(238, 51);
            this.user_pass.Name = "user_pass";
            this.user_pass.PasswordChar = '*';
            this.user_pass.Size = new System.Drawing.Size(187, 21);
            this.user_pass.TabIndex = 9;
            // 
            // user_id
            // 
            this.user_id.Location = new System.Drawing.Point(21, 51);
            this.user_id.Name = "user_id";
            this.user_id.Size = new System.Drawing.Size(187, 21);
            this.user_id.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "비밀번호";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "로그인ID";
            // 
            // index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 159);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_log_in);
            this.Controls.Add(this.user_pass);
            this.Controls.Add(this.user_id);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "index";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "로그인정보";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_log_in;
        private System.Windows.Forms.TextBox user_pass;
        private System.Windows.Forms.TextBox user_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}