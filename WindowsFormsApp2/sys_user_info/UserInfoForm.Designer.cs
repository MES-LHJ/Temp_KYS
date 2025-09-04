namespace WindowsFormsApp2.sys_user_info
{
    partial class UserInfoForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.Columns.GridColumn DeptCd;
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.masterGrid = new DevExpress.XtraGrid.GridControl();
            this.masterGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DeptName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UserId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UserLoginId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UserPass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UserRank = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UserEmpTpye = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UserGender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UserTel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UserEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.USerMessengerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RemarkDc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdDept = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UserImage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.LabelControl();
            this.btnChange = new DevExpress.XtraEditors.LabelControl();
            this.btnDelete = new DevExpress.XtraEditors.LabelControl();
            this.btnLoginInfo = new DevExpress.XtraEditors.LabelControl();
            this.btnUpdate = new DevExpress.XtraEditors.LabelControl();
            this.btnMultiAdd = new DevExpress.XtraEditors.LabelControl();
            this.btnAdd = new DevExpress.XtraEditors.LabelControl();
            this.btnSrch = new DevExpress.XtraEditors.LabelControl();
            this.btnDept = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            DeptCd = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.masterGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // DeptCd
            // 
            DeptCd.Caption = "부서코드";
            DeptCd.FieldName = "DeptCd";
            DeptCd.Name = "DeptCd";
            DeptCd.Visible = true;
            DeptCd.VisibleIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelControl1.Controls.Add(this.masterGrid);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1284, 461);
            this.panelControl1.TabIndex = 0;
            // 
            // masterGrid
            // 
            this.masterGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.masterGrid.Location = new System.Drawing.Point(2, 42);
            this.masterGrid.MainView = this.masterGridView;
            this.masterGrid.Name = "masterGrid";
            this.masterGrid.Size = new System.Drawing.Size(1280, 417);
            this.masterGrid.TabIndex = 1;
            this.masterGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.masterGridView});
            // 
            // masterGridView
            // 
            this.masterGridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.masterGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            DeptCd,
            this.DeptName,
            this.UserId,
            this.UserName,
            this.UserLoginId,
            this.UserPass,
            this.UserRank,
            this.UserEmpTpye,
            this.UserGender,
            this.UserTel,
            this.UserEmail,
            this.USerMessengerId,
            this.RemarkDc,
            this.Id,
            this.IdDept,
            this.UserImage});
            this.masterGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.masterGridView.GridControl = this.masterGrid;
            this.masterGridView.Name = "masterGridView";
            this.masterGridView.OptionsBehavior.Editable = false;
            this.masterGridView.OptionsFind.AlwaysVisible = true;
            this.masterGridView.OptionsView.ShowGroupPanel = false;
            // 
            // DeptName
            // 
            this.DeptName.Caption = "부서명";
            this.DeptName.FieldName = "DeptName";
            this.DeptName.Name = "DeptName";
            this.DeptName.Visible = true;
            this.DeptName.VisibleIndex = 1;
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
            this.UserName.VisibleIndex = 3;
            // 
            // UserLoginId
            // 
            this.UserLoginId.Caption = "로그인ID";
            this.UserLoginId.FieldName = "UserLoginId";
            this.UserLoginId.Name = "UserLoginId";
            this.UserLoginId.Visible = true;
            this.UserLoginId.VisibleIndex = 4;
            // 
            // UserPass
            // 
            this.UserPass.Caption = "비밀번호";
            this.UserPass.FieldName = "UserPass";
            this.UserPass.Name = "UserPass";
            this.UserPass.Visible = true;
            this.UserPass.VisibleIndex = 5;
            // 
            // UserRank
            // 
            this.UserRank.Caption = "직위";
            this.UserRank.FieldName = "UserRank";
            this.UserRank.Name = "UserRank";
            this.UserRank.Visible = true;
            this.UserRank.VisibleIndex = 6;
            // 
            // UserEmpTpye
            // 
            this.UserEmpTpye.Caption = "고용형태";
            this.UserEmpTpye.FieldName = "UserEmpTpye";
            this.UserEmpTpye.Name = "UserEmpTpye";
            this.UserEmpTpye.Visible = true;
            this.UserEmpTpye.VisibleIndex = 7;
            // 
            // UserGender
            // 
            this.UserGender.Caption = "성별";
            this.UserGender.FieldName = "UserGender";
            this.UserGender.Name = "UserGender";
            this.UserGender.Visible = true;
            this.UserGender.VisibleIndex = 8;
            // 
            // UserTel
            // 
            this.UserTel.Caption = "휴대전화";
            this.UserTel.FieldName = "UserTel";
            this.UserTel.Name = "UserTel";
            this.UserTel.Visible = true;
            this.UserTel.VisibleIndex = 9;
            // 
            // UserEmail
            // 
            this.UserEmail.Caption = "이메일";
            this.UserEmail.FieldName = "UserEmail";
            this.UserEmail.Name = "UserEmail";
            this.UserEmail.Visible = true;
            this.UserEmail.VisibleIndex = 10;
            // 
            // USerMessengerId
            // 
            this.USerMessengerId.Caption = "메신저ID";
            this.USerMessengerId.FieldName = "USerMessengerId";
            this.USerMessengerId.Name = "USerMessengerId";
            this.USerMessengerId.Visible = true;
            this.USerMessengerId.VisibleIndex = 11;
            // 
            // RemarkDc
            // 
            this.RemarkDc.Caption = "메모";
            this.RemarkDc.FieldName = "RemarkDc";
            this.RemarkDc.Name = "RemarkDc";
            this.RemarkDc.Visible = true;
            this.RemarkDc.VisibleIndex = 12;
            // 
            // Id
            // 
            this.Id.Caption = "Id";
            this.Id.FieldName = "Id";
            this.Id.Name = "Id";
            // 
            // IdDept
            // 
            this.IdDept.Caption = "IdDept";
            this.IdDept.FieldName = "IdDept";
            this.IdDept.Name = "IdDept";
            // 
            // UserImage
            // 
            this.UserImage.Caption = "UserImage";
            this.UserImage.FieldName = "UserImage";
            this.UserImage.Name = "UserImage";
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.Controls.Add(this.btnClose);
            this.panelControl2.Controls.Add(this.btnChange);
            this.panelControl2.Controls.Add(this.btnDelete);
            this.panelControl2.Controls.Add(this.btnLoginInfo);
            this.panelControl2.Controls.Add(this.btnUpdate);
            this.panelControl2.Controls.Add(this.btnMultiAdd);
            this.panelControl2.Controls.Add(this.btnAdd);
            this.panelControl2.Controls.Add(this.btnSrch);
            this.panelControl2.Controls.Add(this.btnDept);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1280, 40);
            this.panelControl2.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.btnClose.Location = new System.Drawing.Point(1224, 10);
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
            this.btnChange.Location = new System.Drawing.Point(1151, 10);
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
            this.btnDelete.Location = new System.Drawing.Point(1100, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(32, 19);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "삭제";
            // 
            // btnLoginInfo
            // 
            this.btnLoginInfo.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLoginInfo.Appearance.Options.UseFont = true;
            this.btnLoginInfo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.btnLoginInfo.Location = new System.Drawing.Point(1010, 10);
            this.btnLoginInfo.Name = "btnLoginInfo";
            this.btnLoginInfo.Size = new System.Drawing.Size(84, 19);
            this.btnLoginInfo.TabIndex = 6;
            this.btnLoginInfo.Text = "로그인정보";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdate.Appearance.Options.UseFont = true;
            this.btnUpdate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.btnUpdate.Location = new System.Drawing.Point(959, 10);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(31, 19);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "수정";
            // 
            // btnMultiAdd
            // 
            this.btnMultiAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMultiAdd.Appearance.Options.UseFont = true;
            this.btnMultiAdd.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.btnMultiAdd.Location = new System.Drawing.Point(886, 10);
            this.btnMultiAdd.Name = "btnMultiAdd";
            this.btnMultiAdd.Size = new System.Drawing.Size(67, 19);
            this.btnMultiAdd.TabIndex = 4;
            this.btnMultiAdd.Text = "다중추가";
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.btnAdd.Location = new System.Drawing.Point(838, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(33, 19);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "추가";
            // 
            // btnSrch
            // 
            this.btnSrch.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSrch.Appearance.Options.UseFont = true;
            this.btnSrch.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.btnSrch.Location = new System.Drawing.Point(790, 10);
            this.btnSrch.Name = "btnSrch";
            this.btnSrch.Size = new System.Drawing.Size(33, 19);
            this.btnSrch.TabIndex = 2;
            this.btnSrch.Text = "조회";
            // 
            // btnDept
            // 
            this.btnDept.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDept.Appearance.Options.UseFont = true;
            this.btnDept.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.btnDept.Location = new System.Drawing.Point(742, 10);
            this.btnDept.Name = "btnDept";
            this.btnDept.Size = new System.Drawing.Size(33, 19);
            this.btnDept.TabIndex = 1;
            this.btnDept.Text = "부서";
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
            this.labelControl1.Text = "부서사원";
            // 
            // UserInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1284, 461);
            this.Controls.Add(this.panelControl1);
            this.Name = "UserInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "부서사원";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.masterGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl btnDept;
        private DevExpress.XtraEditors.LabelControl btnLoginInfo;
        private DevExpress.XtraEditors.LabelControl btnUpdate;
        private DevExpress.XtraEditors.LabelControl btnMultiAdd;
        private DevExpress.XtraEditors.LabelControl btnAdd;
        private DevExpress.XtraEditors.LabelControl btnSrch;
        private DevExpress.XtraEditors.LabelControl btnClose;
        private DevExpress.XtraEditors.LabelControl btnChange;
        private DevExpress.XtraEditors.LabelControl btnDelete;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraGrid.GridControl masterGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView masterGridView;
        private DevExpress.XtraGrid.Columns.GridColumn DeptName;
        private DevExpress.XtraGrid.Columns.GridColumn UserId;
        private DevExpress.XtraGrid.Columns.GridColumn UserName;
        private DevExpress.XtraGrid.Columns.GridColumn UserLoginId;
        private DevExpress.XtraGrid.Columns.GridColumn UserPass;
        private DevExpress.XtraGrid.Columns.GridColumn UserRank;
        private DevExpress.XtraGrid.Columns.GridColumn UserEmpTpye;
        private DevExpress.XtraGrid.Columns.GridColumn UserGender;
        private DevExpress.XtraGrid.Columns.GridColumn UserTel;
        private DevExpress.XtraGrid.Columns.GridColumn UserEmail;
        private DevExpress.XtraGrid.Columns.GridColumn USerMessengerId;
        private DevExpress.XtraGrid.Columns.GridColumn RemarkDc;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn IdDept;
        private DevExpress.XtraGrid.Columns.GridColumn UserImage;
    }
}

