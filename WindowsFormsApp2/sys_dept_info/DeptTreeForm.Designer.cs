namespace WindowsFormsApp2.sys_dept_info
{
    partial class DeptTreeForm
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
            this.components = new System.ComponentModel.Container();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.UpperDeptCd = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.UpperDeptName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.DeptCd = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.DeptName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.UserId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.UserName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.treeList1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(798, 368);
            this.panelControl1.TabIndex = 0;
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.UpperDeptCd,
            this.DeptCd,
            this.UserId,
            this.UpperDeptName,
            this.DeptName,
            this.UserName});
            this.treeList1.Location = new System.Drawing.Point(12, 12);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.Size = new System.Drawing.Size(774, 344);
            this.treeList1.TabIndex = 0;
            // 
            // UpperDeptCd
            // 
            this.UpperDeptCd.Caption = "상위부서코드";
            this.UpperDeptCd.FieldName = "UpperDeptCd";
            this.UpperDeptCd.Name = "UpperDeptCd";
            this.UpperDeptCd.Visible = true;
            this.UpperDeptCd.VisibleIndex = 0;
            // 
            // UpperDeptName
            // 
            this.UpperDeptName.Caption = "상위부서명";
            this.UpperDeptName.FieldName = "UpperDeptName";
            this.UpperDeptName.Name = "UpperDeptName";
            this.UpperDeptName.Visible = true;
            this.UpperDeptName.VisibleIndex = 3;
            // 
            // DeptCd
            // 
            this.DeptCd.Caption = "하위부서코드";
            this.DeptCd.FieldName = "DeptCd";
            this.DeptCd.Name = "DeptCd";
            this.DeptCd.Visible = true;
            this.DeptCd.VisibleIndex = 1;
            // 
            // DeptName
            // 
            this.DeptName.Caption = "하위부서명";
            this.DeptName.FieldName = "DeptName";
            this.DeptName.Name = "DeptName";
            this.DeptName.Visible = true;
            this.DeptName.VisibleIndex = 4;
            // 
            // UserId
            // 
            this.UserId.Caption = "사원코드";
            this.UserId.FieldName = "UserId";
            this.UserId.Name = "UserId";
            this.UserId.Visible = true;
            this.UserId.VisibleIndex = 2;
            // 
            // UserName
            // 
            this.UserName.Caption = "사원명";
            this.UserName.FieldName = "UserName";
            this.UserName.Name = "UserName";
            this.UserName.Visible = true;
            this.UserName.VisibleIndex = 5;
            // 
            // DeptTreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 368);
            this.Controls.Add(this.panelControl1);
            this.Name = "DeptTreeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "트리";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn UpperDeptCd;
        private DevExpress.XtraTreeList.Columns.TreeListColumn UpperDeptName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn DeptCd;
        private DevExpress.XtraTreeList.Columns.TreeListColumn DeptName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn UserId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn UserName;
    }
}