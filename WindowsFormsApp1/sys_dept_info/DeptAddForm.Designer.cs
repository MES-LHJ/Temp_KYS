namespace WindowsFormsApp1.sys_dept_info
{
    partial class DeptAddForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDeptCd = new System.Windows.Forms.TextBox();
            this.txtDeptName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRemarkDc = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAct = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(22, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "부서코드";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(215, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "부서명";
            // 
            // txtDeptCd
            // 
            this.txtDeptCd.Location = new System.Drawing.Point(25, 51);
            this.txtDeptCd.Name = "txtDeptCd";
            this.txtDeptCd.Size = new System.Drawing.Size(170, 21);
            this.txtDeptCd.TabIndex = 1;
            // 
            // txtDeptName
            // 
            this.txtDeptName.Location = new System.Drawing.Point(217, 51);
            this.txtDeptName.Name = "txtDeptName";
            this.txtDeptName.Size = new System.Drawing.Size(170, 21);
            this.txtDeptName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(23, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "메모";
            // 
            // txtRemarkDc
            // 
            this.txtRemarkDc.Location = new System.Drawing.Point(24, 120);
            this.txtRemarkDc.Name = "txtRemarkDc";
            this.txtRemarkDc.Size = new System.Drawing.Size(363, 21);
            this.txtRemarkDc.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.OrangeRed;
            this.btnCancel.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(278, 163);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 35);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "취소(ESC)";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnAct
            // 
            this.btnAct.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAct.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAct.ForeColor = System.Drawing.Color.White;
            this.btnAct.Location = new System.Drawing.Point(159, 163);
            this.btnAct.Margin = new System.Windows.Forms.Padding(0);
            this.btnAct.Name = "btnAct";
            this.btnAct.Size = new System.Drawing.Size(110, 35);
            this.btnAct.TabIndex = 4;
            this.btnAct.Text = "저장(F4)";
            this.btnAct.UseVisualStyleBackColor = false;
            // 
            // DeptAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 211);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAct);
            this.Controls.Add(this.txtRemarkDc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDeptName);
            this.Controls.Add(this.txtDeptCd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "DeptAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "부서 추가";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDeptCd;
        private System.Windows.Forms.TextBox txtDeptName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRemarkDc;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAct;
    }
}