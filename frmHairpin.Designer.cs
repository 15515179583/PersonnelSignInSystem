namespace PersonnelSignInSystem
{
    partial class frmHairpin
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lbAccessID = new System.Windows.Forms.Label();
            this.cmbStaffSex = new System.Windows.Forms.ComboBox();
            this.txtIDNO = new System.Windows.Forms.TextBox();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.txtAccessID = new System.Windows.Forms.TextBox();
            this.lbIDNO = new System.Windows.Forms.Label();
            this.lbStaffSex = new System.Windows.Forms.Label();
            this.lbStaffName = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRegister);
            this.groupBox1.Controls.Add(this.lbAccessID);
            this.groupBox1.Controls.Add(this.cmbStaffSex);
            this.groupBox1.Controls.Add(this.txtIDNO);
            this.groupBox1.Controls.Add(this.txtStaffName);
            this.groupBox1.Controls.Add(this.txtAccessID);
            this.groupBox1.Controls.Add(this.lbIDNO);
            this.groupBox1.Controls.Add(this.lbStaffSex);
            this.groupBox1.Controls.Add(this.lbStaffName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 244);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "登记信息";
            // 
            // btnRegister
            // 
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRegister.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRegister.Location = new System.Drawing.Point(18, 195);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(239, 37);
            this.btnRegister.TabIndex = 9;
            this.btnRegister.Text = "登记信息";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lbAccessID
            // 
            this.lbAccessID.AutoSize = true;
            this.lbAccessID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbAccessID.Location = new System.Drawing.Point(16, 27);
            this.lbAccessID.Name = "lbAccessID";
            this.lbAccessID.Size = new System.Drawing.Size(65, 12);
            this.lbAccessID.TabIndex = 8;
            this.lbAccessID.Text = "人员卡号：";
            // 
            // cmbStaffSex
            // 
            this.cmbStaffSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStaffSex.FormattingEnabled = true;
            this.cmbStaffSex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cmbStaffSex.Location = new System.Drawing.Point(96, 112);
            this.cmbStaffSex.Name = "cmbStaffSex";
            this.cmbStaffSex.Size = new System.Drawing.Size(161, 20);
            this.cmbStaffSex.TabIndex = 7;
            // 
            // txtIDNO
            // 
            this.txtIDNO.Location = new System.Drawing.Point(96, 154);
            this.txtIDNO.Name = "txtIDNO";
            this.txtIDNO.Size = new System.Drawing.Size(161, 21);
            this.txtIDNO.TabIndex = 6;
            this.txtIDNO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIDNO_KeyPress);
            // 
            // txtStaffName
            // 
            this.txtStaffName.Location = new System.Drawing.Point(96, 67);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.Size = new System.Drawing.Size(161, 21);
            this.txtStaffName.TabIndex = 5;
            this.txtStaffName.TextChanged += new System.EventHandler(this.txtStaffName_TextChanged);
            // 
            // txtAccessID
            // 
            this.txtAccessID.Location = new System.Drawing.Point(96, 24);
            this.txtAccessID.Name = "txtAccessID";
            this.txtAccessID.ReadOnly = true;
            this.txtAccessID.Size = new System.Drawing.Size(161, 21);
            this.txtAccessID.TabIndex = 4;
            // 
            // lbIDNO
            // 
            this.lbIDNO.AutoSize = true;
            this.lbIDNO.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbIDNO.Location = new System.Drawing.Point(16, 158);
            this.lbIDNO.Name = "lbIDNO";
            this.lbIDNO.Size = new System.Drawing.Size(65, 12);
            this.lbIDNO.TabIndex = 3;
            this.lbIDNO.Text = "身份证号：";
            // 
            // lbStaffSex
            // 
            this.lbStaffSex.AutoSize = true;
            this.lbStaffSex.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbStaffSex.Location = new System.Drawing.Point(16, 116);
            this.lbStaffSex.Name = "lbStaffSex";
            this.lbStaffSex.Size = new System.Drawing.Size(65, 12);
            this.lbStaffSex.TabIndex = 2;
            this.lbStaffSex.Text = "人员性别：";
            // 
            // lbStaffName
            // 
            this.lbStaffName.AutoSize = true;
            this.lbStaffName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbStaffName.Location = new System.Drawing.Point(16, 71);
            this.lbStaffName.Name = "lbStaffName";
            this.lbStaffName.Size = new System.Drawing.Size(65, 12);
            this.lbStaffName.TabIndex = 1;
            this.lbStaffName.Text = "人员姓名：";
            // 
            // frmHairpin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 244);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmHairpin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "发卡";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmHairpin_FormClosed);
            this.Load += new System.EventHandler(this.Hairpin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lbAccessID;
        private System.Windows.Forms.ComboBox cmbStaffSex;
        private System.Windows.Forms.TextBox txtIDNO;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.TextBox txtAccessID;
        private System.Windows.Forms.Label lbIDNO;
        private System.Windows.Forms.Label lbStaffSex;
        private System.Windows.Forms.Label lbStaffName;

    }
}