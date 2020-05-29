namespace PersonnelSignInSystem
{
    partial class frm_PunchCard
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
            this.cmbCheckStatus = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblCheckingInOrOut = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvCheckInOrOutInfo = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtAccessID = new System.Windows.Forms.TextBox();
            this.lbAccessID = new System.Windows.Forms.Label();
            this.btnSignInOrOut = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckInOrOutInfo)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbCheckStatus);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.lblCheckingInOrOut);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 85);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询签到/签退信息";
            // 
            // cmbCheckStatus
            // 
            this.cmbCheckStatus.FormattingEnabled = true;
            this.cmbCheckStatus.Items.AddRange(new object[] {
            "已签到",
            "已签退",
            "迟到",
            "早退"});
            this.cmbCheckStatus.Location = new System.Drawing.Point(151, 31);
            this.cmbCheckStatus.Name = "cmbCheckStatus";
            this.cmbCheckStatus.Size = new System.Drawing.Size(121, 20);
            this.cmbCheckStatus.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(292, 31);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 20);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblCheckingInOrOut
            // 
            this.lblCheckingInOrOut.AutoSize = true;
            this.lblCheckingInOrOut.Location = new System.Drawing.Point(38, 34);
            this.lblCheckingInOrOut.Name = "lblCheckingInOrOut";
            this.lblCheckingInOrOut.Size = new System.Drawing.Size(107, 12);
            this.lblCheckingInOrOut.TabIndex = 0;
            this.lblCheckingInOrOut.Text = "签到/签退情况查询";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvCheckInOrOutInfo);
            this.groupBox2.Location = new System.Drawing.Point(12, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(500, 221);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "签到/签退信息";
            // 
            // dgvCheckInOrOutInfo
            // 
            this.dgvCheckInOrOutInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCheckInOrOutInfo.Location = new System.Drawing.Point(18, 25);
            this.dgvCheckInOrOutInfo.Name = "dgvCheckInOrOutInfo";
            this.dgvCheckInOrOutInfo.RowTemplate.Height = 23;
            this.dgvCheckInOrOutInfo.Size = new System.Drawing.Size(439, 178);
            this.dgvCheckInOrOutInfo.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtAccessID);
            this.groupBox3.Controls.Add(this.lbAccessID);
            this.groupBox3.Controls.Add(this.btnSignInOrOut);
            this.groupBox3.Location = new System.Drawing.Point(30, 343);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(482, 85);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "签到/签退";
            // 
            // txtAccessID
            // 
            this.txtAccessID.Enabled = false;
            this.txtAccessID.Location = new System.Drawing.Point(106, 30);
            this.txtAccessID.Name = "txtAccessID";
            this.txtAccessID.Size = new System.Drawing.Size(161, 21);
            this.txtAccessID.TabIndex = 10;
            // 
            // lbAccessID
            // 
            this.lbAccessID.AutoSize = true;
            this.lbAccessID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbAccessID.Location = new System.Drawing.Point(35, 39);
            this.lbAccessID.Name = "lbAccessID";
            this.lbAccessID.Size = new System.Drawing.Size(65, 12);
            this.lbAccessID.TabIndex = 9;
            this.lbAccessID.Text = "人员卡号：";
            // 
            // btnSignInOrOut
            // 
            this.btnSignInOrOut.Location = new System.Drawing.Point(292, 31);
            this.btnSignInOrOut.Name = "btnSignInOrOut";
            this.btnSignInOrOut.Size = new System.Drawing.Size(80, 20);
            this.btnSignInOrOut.TabIndex = 4;
            this.btnSignInOrOut.Text = "签到/签退";
            this.btnSignInOrOut.UseVisualStyleBackColor = true;
            this.btnSignInOrOut.Click += new System.EventHandler(this.btnSignInOrOut_Click);
            // 
            // frm_PunchCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 440);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_PunchCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "打卡";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_PunchCard_FormClosed);
            this.Load += new System.EventHandler(this.frm_PunchCard_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckInOrOutInfo)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbCheckStatus;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblCheckingInOrOut;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.DataGridView dgvCheckInOrOutInfo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSignInOrOut;
        private System.Windows.Forms.Label lbAccessID;
        private System.Windows.Forms.TextBox txtAccessID;
    }
}