namespace WindowsFormsApp2.sys_dept_info
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.txtRemarkDc = new DevExpress.XtraEditors.TextEdit();
            this.btnAct = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.txtDeptCd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtDeptName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarkDc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeptCd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeptName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnCancel);
            this.panelControl1.Controls.Add(this.txtRemarkDc);
            this.panelControl1.Controls.Add(this.btnAct);
            this.panelControl1.Controls.Add(this.labelControl15);
            this.panelControl1.Controls.Add(this.txtDeptCd);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.txtDeptName);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(414, 211);
            this.panelControl1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.BackColor = System.Drawing.Color.OrangeRed;
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnCancel.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Appearance.Options.UseBackColor = true;
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Appearance.Options.UseForeColor = true;
            this.btnCancel.Location = new System.Drawing.Point(277, 160);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.True;
            this.btnCancel.Size = new System.Drawing.Size(110, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "취소";
            // 
            // txtRemarkDc
            // 
            this.txtRemarkDc.Location = new System.Drawing.Point(25, 116);
            this.txtRemarkDc.Name = "txtRemarkDc";
            this.txtRemarkDc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtRemarkDc.Properties.Appearance.Options.UseFont = true;
            this.txtRemarkDc.Size = new System.Drawing.Size(362, 22);
            this.txtRemarkDc.TabIndex = 3;
            // 
            // btnAct
            // 
            this.btnAct.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAct.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnAct.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAct.Appearance.Options.UseBackColor = true;
            this.btnAct.Appearance.Options.UseFont = true;
            this.btnAct.Appearance.Options.UseForeColor = true;
            this.btnAct.Location = new System.Drawing.Point(161, 160);
            this.btnAct.Name = "btnAct";
            this.btnAct.Size = new System.Drawing.Size(110, 30);
            this.btnAct.TabIndex = 4;
            this.btnAct.Text = "저장";
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl15.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.Appearance.Options.UseForeColor = true;
            this.labelControl15.Location = new System.Drawing.Point(25, 91);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(28, 19);
            this.labelControl15.TabIndex = 37;
            this.labelControl15.Text = "메모";
            // 
            // txtDeptCd
            // 
            this.txtDeptCd.Location = new System.Drawing.Point(25, 51);
            this.txtDeptCd.Name = "txtDeptCd";
            this.txtDeptCd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtDeptCd.Properties.Appearance.Options.UseFont = true;
            this.txtDeptCd.Size = new System.Drawing.Size(170, 22);
            this.txtDeptCd.TabIndex = 1;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.Location = new System.Drawing.Point(25, 26);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(56, 19);
            this.labelControl6.TabIndex = 35;
            this.labelControl6.Text = "부서코드";
            // 
            // txtDeptName
            // 
            this.txtDeptName.Location = new System.Drawing.Point(217, 51);
            this.txtDeptName.Name = "txtDeptName";
            this.txtDeptName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtDeptName.Properties.Appearance.Options.UseFont = true;
            this.txtDeptName.Size = new System.Drawing.Size(170, 22);
            this.txtDeptName.TabIndex = 2;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.Location = new System.Drawing.Point(217, 26);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(42, 19);
            this.labelControl5.TabIndex = 34;
            this.labelControl5.Text = "부서명";
            // 
            // DeptAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 211);
            this.Controls.Add(this.panelControl1);
            this.Name = "DeptAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "부서 추가";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarkDc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeptCd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeptName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtRemarkDc;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.TextEdit txtDeptCd;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtDeptName;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnAct;
    }
}