namespace WindowsFormsApp1
{
    partial class dept_info
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.Label();
            this.btn_delete = new System.Windows.Forms.Label();
            this.btn_update = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dept_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dept_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark_dc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Controls.Add(this.btn_delete);
            this.panel1.Controls.Add(this.btn_update);
            this.panel1.Controls.Add(this.btn_add);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(443, 43);
            this.panel1.TabIndex = 3;
            // 
            // btn_close
            // 
            this.btn_close.AutoSize = true;
            this.btn_close.Font = new System.Drawing.Font("굴림", 11F);
            this.btn_close.Location = new System.Drawing.Point(357, 12);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(78, 15);
            this.btn_close.TabIndex = 8;
            this.btn_close.Text = "닫기(ESC)";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.AutoSize = true;
            this.btn_delete.Font = new System.Drawing.Font("굴림", 11F);
            this.btn_delete.Location = new System.Drawing.Point(286, 12);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(65, 15);
            this.btn_delete.TabIndex = 6;
            this.btn_delete.Text = "삭제(F7)";
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_update
            // 
            this.btn_update.AutoSize = true;
            this.btn_update.Font = new System.Drawing.Font("굴림", 11F);
            this.btn_update.Location = new System.Drawing.Point(243, 12);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(37, 15);
            this.btn_update.TabIndex = 4;
            this.btn_update.Text = "수정";
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_add
            // 
            this.btn_add.AutoSize = true;
            this.btn_add.Font = new System.Drawing.Font("굴림", 11F);
            this.btn_add.Location = new System.Drawing.Point(172, 12);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(65, 15);
            this.btn_add.TabIndex = 3;
            this.btn_add.Text = "추가(F1)";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 13F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "부서";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dept_cd,
            this.dept_name,
            this.remark_dc});
            this.dataGridView1.Location = new System.Drawing.Point(12, 73);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(443, 294);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // dept_cd
            // 
            this.dept_cd.DataPropertyName = "dept_cd";
            this.dept_cd.HeaderText = "부서코드";
            this.dept_cd.Name = "dept_cd";
            this.dept_cd.ReadOnly = true;
            // 
            // dept_name
            // 
            this.dept_name.DataPropertyName = "dept_name";
            this.dept_name.HeaderText = "부서명";
            this.dept_name.Name = "dept_name";
            this.dept_name.ReadOnly = true;
            // 
            // remark_dc
            // 
            this.remark_dc.DataPropertyName = "remark_dc";
            this.remark_dc.HeaderText = "비고";
            this.remark_dc.Name = "remark_dc";
            this.remark_dc.ReadOnly = true;
            this.remark_dc.Width = 200;
            // 
            // dept_info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 401);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "dept_info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "부서";
            this.Load += new System.EventHandler(this.dept_info_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label btn_close;
        private System.Windows.Forms.Label btn_delete;
        private System.Windows.Forms.Label btn_update;
        private System.Windows.Forms.Label btn_add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dept_cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dept_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark_dc;
    }
}