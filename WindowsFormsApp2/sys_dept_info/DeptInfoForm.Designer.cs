namespace WindowsFormsApp2.sys_dept_info
{
    partial class DeptInfoForm
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.masterGrid = new DevExpress.XtraGrid.GridControl();
            this.masterGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.UpperDeptCd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UpperDeptName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UpperRemarkDc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.detailGrid = new DevExpress.XtraGrid.GridControl();
            this.detailGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DeptCd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DeptName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RemarkDc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdDept = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdUpperDept = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnChart = new DevExpress.XtraEditors.LabelControl();
            this.btnClose = new DevExpress.XtraEditors.LabelControl();
            this.btnDelete = new DevExpress.XtraEditors.LabelControl();
            this.btnUpdate = new DevExpress.XtraEditors.LabelControl();
            this.btnAdd = new DevExpress.XtraEditors.LabelControl();
            this.btnTree = new DevExpress.XtraEditors.LabelControl();
            this.btnUpperDept = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.masterGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.splitContainerControl1);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(984, 411);
            this.panelControl1.TabIndex = 0;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(2, 42);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.masterGrid);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.detailGrid);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(980, 367);
            this.splitContainerControl1.SplitterPosition = 486;
            this.splitContainerControl1.TabIndex = 2;
            // 
            // masterGrid
            // 
            this.masterGrid.Font = new System.Drawing.Font("Tahoma", 10F);
            this.masterGrid.Location = new System.Drawing.Point(10, 6);
            this.masterGrid.MainView = this.masterGridView;
            this.masterGrid.Name = "masterGrid";
            this.masterGrid.Size = new System.Drawing.Size(450, 350);
            this.masterGrid.TabIndex = 0;
            this.masterGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.masterGridView});
            // 
            // masterGridView
            // 
            this.masterGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.UpperDeptCd,
            this.UpperDeptName,
            this.UpperRemarkDc,
            this.Id});
            this.masterGridView.GridControl = this.masterGrid;
            this.masterGridView.Name = "masterGridView";
            this.masterGridView.OptionsBehavior.Editable = false;
            this.masterGridView.OptionsView.ShowGroupPanel = false;
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
            this.UpperDeptName.VisibleIndex = 1;
            // 
            // UpperRemarkDc
            // 
            this.UpperRemarkDc.Caption = "메모";
            this.UpperRemarkDc.FieldName = "UpperRemarkDc";
            this.UpperRemarkDc.Name = "UpperRemarkDc";
            this.UpperRemarkDc.Visible = true;
            this.UpperRemarkDc.VisibleIndex = 2;
            // 
            // Id
            // 
            this.Id.Caption = "ID";
            this.Id.FieldName = "Id";
            this.Id.Name = "Id";
            // 
            // detailGrid
            // 
            this.detailGrid.Font = new System.Drawing.Font("Tahoma", 10F);
            this.detailGrid.Location = new System.Drawing.Point(24, 7);
            this.detailGrid.MainView = this.detailGridView;
            this.detailGrid.Name = "detailGrid";
            this.detailGrid.Size = new System.Drawing.Size(450, 350);
            this.detailGrid.TabIndex = 0;
            this.detailGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.detailGridView});
            // 
            // detailGridView
            // 
            this.detailGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.DeptCd,
            this.DeptName,
            this.RemarkDc,
            this.IdDept,
            this.IdUpperDept});
            this.detailGridView.GridControl = this.detailGrid;
            this.detailGridView.Name = "detailGridView";
            this.detailGridView.OptionsBehavior.Editable = false;
            this.detailGridView.OptionsView.ShowGroupPanel = false;
            // 
            // DeptCd
            // 
            this.DeptCd.Caption = "부서코드";
            this.DeptCd.FieldName = "DeptCd";
            this.DeptCd.Name = "DeptCd";
            this.DeptCd.Visible = true;
            this.DeptCd.VisibleIndex = 0;
            // 
            // DeptName
            // 
            this.DeptName.Caption = "부서명";
            this.DeptName.FieldName = "DeptName";
            this.DeptName.Name = "DeptName";
            this.DeptName.Visible = true;
            this.DeptName.VisibleIndex = 1;
            // 
            // RemarkDc
            // 
            this.RemarkDc.Caption = "메모";
            this.RemarkDc.FieldName = "RemarkDc";
            this.RemarkDc.Name = "RemarkDc";
            this.RemarkDc.Visible = true;
            this.RemarkDc.VisibleIndex = 2;
            // 
            // IdDept
            // 
            this.IdDept.Caption = "IdDept";
            this.IdDept.FieldName = "Id";
            this.IdDept.Name = "IdDept";
            // 
            // IdUpperDept
            // 
            this.IdUpperDept.Caption = "IdUpperDept";
            this.IdUpperDept.FieldName = "IdUpperDept";
            this.IdUpperDept.Name = "IdUpperDept";
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.Controls.Add(this.btnChart);
            this.panelControl2.Controls.Add(this.btnClose);
            this.panelControl2.Controls.Add(this.btnDelete);
            this.panelControl2.Controls.Add(this.btnUpdate);
            this.panelControl2.Controls.Add(this.btnAdd);
            this.panelControl2.Controls.Add(this.btnTree);
            this.panelControl2.Controls.Add(this.btnUpperDept);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(980, 40);
            this.panelControl2.TabIndex = 1;
            // 
            // btnChart
            // 
            this.btnChart.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnChart.Appearance.Options.UseFont = true;
            this.btnChart.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.btnChart.Location = new System.Drawing.Point(734, 10);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(33, 19);
            this.btnChart.TabIndex = 10;
            this.btnChart.Text = "차트";
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.btnClose.Location = new System.Drawing.Point(926, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 19);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "닫기";
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.btnDelete.Location = new System.Drawing.Point(878, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(32, 19);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "삭제";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdate.Appearance.Options.UseFont = true;
            this.btnUpdate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.btnUpdate.Location = new System.Drawing.Point(831, 10);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(31, 19);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "수정";
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.btnAdd.Location = new System.Drawing.Point(783, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(33, 19);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "추가";
            // 
            // btnTree
            // 
            this.btnTree.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTree.Appearance.Options.UseFont = true;
            this.btnTree.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.btnTree.Location = new System.Drawing.Point(685, 10);
            this.btnTree.Name = "btnTree";
            this.btnTree.Size = new System.Drawing.Size(33, 19);
            this.btnTree.TabIndex = 2;
            this.btnTree.Text = "트리";
            // 
            // btnUpperDept
            // 
            this.btnUpperDept.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpperDept.Appearance.Options.UseFont = true;
            this.btnUpperDept.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.btnUpperDept.Location = new System.Drawing.Point(609, 10);
            this.btnUpperDept.Name = "btnUpperDept";
            this.btnUpperDept.Size = new System.Drawing.Size(60, 19);
            this.btnUpperDept.TabIndex = 1;
            this.btnUpperDept.Text = "상위부서";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(10, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "부서";
            // 
            // DeptInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 411);
            this.Controls.Add(this.panelControl1);
            this.Name = "DeptInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "부서";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.masterGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl btnClose;
        private DevExpress.XtraEditors.LabelControl btnDelete;
        private DevExpress.XtraEditors.LabelControl btnUpdate;
        private DevExpress.XtraEditors.LabelControl btnAdd;
        private DevExpress.XtraEditors.LabelControl btnTree;
        private DevExpress.XtraEditors.LabelControl btnUpperDept;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl masterGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView masterGridView;
        private DevExpress.XtraGrid.GridControl detailGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView detailGridView;
        private DevExpress.XtraGrid.Columns.GridColumn UpperDeptCd;
        private DevExpress.XtraGrid.Columns.GridColumn UpperDeptName;
        private DevExpress.XtraGrid.Columns.GridColumn UpperRemarkDc;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn DeptCd;
        private DevExpress.XtraGrid.Columns.GridColumn DeptName;
        private DevExpress.XtraGrid.Columns.GridColumn RemarkDc;
        private DevExpress.XtraGrid.Columns.GridColumn IdDept;
        private DevExpress.XtraGrid.Columns.GridColumn IdUpperDept;
        private DevExpress.XtraEditors.LabelControl btnChart;
    }
}