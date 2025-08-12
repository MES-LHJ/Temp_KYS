namespace WindowsFormsApp1
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
            this.input_dept_cd = new System.Windows.Forms.TextBox();
            this.input_dept_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.input_remark_dc = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_act = new System.Windows.Forms.Button();
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
            // input_dept_cd
            // 
            this.input_dept_cd.Location = new System.Drawing.Point(25, 51);
            this.input_dept_cd.Name = "input_dept_cd";
            this.input_dept_cd.Size = new System.Drawing.Size(170, 21);
            this.input_dept_cd.TabIndex = 1;
            // 
            // input_dept_name
            // 
            this.input_dept_name.Location = new System.Drawing.Point(217, 51);
            this.input_dept_name.Name = "input_dept_name";
            this.input_dept_name.Size = new System.Drawing.Size(170, 21);
            this.input_dept_name.TabIndex = 2;
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
            // input_remark_dc
            // 
            this.input_remark_dc.Location = new System.Drawing.Point(24, 120);
            this.input_remark_dc.Name = "input_remark_dc";
            this.input_remark_dc.Size = new System.Drawing.Size(363, 21);
            this.input_remark_dc.TabIndex = 3;
            this.input_remark_dc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.input_remark_dc_KeyDown);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_cancel.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.Location = new System.Drawing.Point(278, 163);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(0);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(110, 35);
            this.btn_cancel.TabIndex = 5;
            this.btn_cancel.Text = "취소(ESC)";
            this.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_act
            // 
            this.btn_act.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_act.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_act.ForeColor = System.Drawing.Color.White;
            this.btn_act.Location = new System.Drawing.Point(159, 163);
            this.btn_act.Margin = new System.Windows.Forms.Padding(0);
            this.btn_act.Name = "btn_act";
            this.btn_act.Size = new System.Drawing.Size(110, 35);
            this.btn_act.TabIndex = 4;
            this.btn_act.Text = "저장(F4)";
            this.btn_act.UseVisualStyleBackColor = false;
            this.btn_act.Click += new System.EventHandler(this.btn_act_Click);
            // 
            // dept_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 211);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_act);
            this.Controls.Add(this.input_remark_dc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.input_dept_name);
            this.Controls.Add(this.input_dept_cd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "dept_add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "부서 추가";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dept_add_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox input_dept_cd;
        private System.Windows.Forms.TextBox input_dept_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox input_remark_dc;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_act;
    }
}