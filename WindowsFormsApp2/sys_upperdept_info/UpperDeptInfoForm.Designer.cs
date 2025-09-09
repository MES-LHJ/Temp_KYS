namespace WindowsFormsApp2.sys_upperdept_info
{
    partial class UpperDeptInfoForm
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
            this.masterGrid = new DevExpress.XtraGrid.GridControl();
            this.masterGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.UpperDeptCd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UpperDeptName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UpperRemarkDc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.LabelControl();
            this.btnChange = new DevExpress.XtraEditors.LabelControl();
            this.btnDelete = new DevExpress.XtraEditors.LabelControl();
            this.btnUpdate = new DevExpress.XtraEditors.LabelControl();
            this.btnAdd = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.masterGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.masterGrid);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(684, 411);
            this.panelControl1.TabIndex = 0;
            // 
            // masterGrid
            // 
            this.masterGrid.Font = new System.Drawing.Font("Tahoma", 10F);
            this.masterGrid.Location = new System.Drawing.Point(12, 49);
            this.masterGrid.MainView = this.masterGridView;
            this.masterGrid.Name = "masterGrid";
            this.masterGrid.Size = new System.Drawing.Size(660, 350);
            this.masterGrid.TabIndex = 2;
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
            this.UpperDeptCd.Caption = "부서코드";
            this.UpperDeptCd.FieldName = "UpperDeptCd";
            this.UpperDeptCd.Name = "UpperDeptCd";
            this.UpperDeptCd.Visible = true;
            this.UpperDeptCd.VisibleIndex = 0;
            // 
            // UpperDeptName
            // 
            this.UpperDeptName.Caption = "부서명";
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
            this.Id.Caption = "Id";
            this.Id.FieldName = "Id";
            this.Id.Name = "Id";
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.Controls.Add(this.btnClose);
            this.panelControl2.Controls.Add(this.btnChange);
            this.panelControl2.Controls.Add(this.btnDelete);
            this.panelControl2.Controls.Add(this.btnUpdate);
            this.panelControl2.Controls.Add(this.btnAdd);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(680, 40);
            this.panelControl2.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.btnClose.Location = new System.Drawing.Point(627, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 19);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "닫기";
            // 
            // btnChange
            // 
            this.btnChange.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnChange.Appearance.Options.UseFont = true;
            this.btnChange.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.btnChange.Location = new System.Drawing.Point(407, 12);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(67, 19);
            this.btnChange.TabIndex = 8;
            this.btnChange.Text = "자료변환";
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.btnDelete.Location = new System.Drawing.Point(576, 12);
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
            this.btnUpdate.Location = new System.Drawing.Point(528, 12);
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
            this.btnAdd.Location = new System.Drawing.Point(480, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(33, 19);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "추가";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(10, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(76, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "상위부서";
            // 
            // UpperDeptInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 411);
            this.Controls.Add(this.panelControl1);
            this.Name = "UpperDeptInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "상위부서";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.masterGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl btnClose;
        private DevExpress.XtraEditors.LabelControl btnChange;
        private DevExpress.XtraEditors.LabelControl btnDelete;
        private DevExpress.XtraEditors.LabelControl btnUpdate;
        private DevExpress.XtraEditors.LabelControl btnAdd;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl masterGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView masterGridView;
        private DevExpress.XtraGrid.Columns.GridColumn UpperDeptCd;
        private DevExpress.XtraGrid.Columns.GridColumn UpperDeptName;
        private DevExpress.XtraGrid.Columns.GridColumn UpperRemarkDc;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
    }
}