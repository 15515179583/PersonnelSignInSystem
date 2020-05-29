namespace PersonnelSignInSystem
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbHairpin = new System.Windows.Forms.ToolStripButton();
            this.tsbPunchCard = new System.Windows.Forms.ToolStripButton();
            this.tsbMeetingSign = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbHairpin,
            this.tsbPunchCard,
            this.tsbMeetingSign});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(413, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbHairpin
            // 
            this.tsbHairpin.Image = ((System.Drawing.Image)(resources.GetObject("tsbHairpin.Image")));
            this.tsbHairpin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHairpin.Name = "tsbHairpin";
            this.tsbHairpin.Size = new System.Drawing.Size(76, 22);
            this.tsbHairpin.Text = "发卡管理";
            this.tsbHairpin.Click += new System.EventHandler(this.tsbHairpin_Click);
            // 
            // tsbPunchCard
            // 
            this.tsbPunchCard.Image = ((System.Drawing.Image)(resources.GetObject("tsbPunchCard.Image")));
            this.tsbPunchCard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPunchCard.Name = "tsbPunchCard";
            this.tsbPunchCard.Size = new System.Drawing.Size(52, 22);
            this.tsbPunchCard.Text = "打卡";
            this.tsbPunchCard.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // tsbMeetingSign
            // 
            this.tsbMeetingSign.Image = ((System.Drawing.Image)(resources.GetObject("tsbMeetingSign.Image")));
            this.tsbMeetingSign.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMeetingSign.Name = "tsbMeetingSign";
            this.tsbMeetingSign.Size = new System.Drawing.Size(76, 22);
            this.tsbMeetingSign.Text = "会议签到";
            this.tsbMeetingSign.Click += new System.EventHandler(this.tsbMeetingSign_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Location = new System.Drawing.Point(0, 25);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(413, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 170);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "人员签到系统";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbHairpin;
        private System.Windows.Forms.ToolStripButton tsbPunchCard;
        private System.Windows.Forms.ToolStripButton tsbMeetingSign;
        private System.Windows.Forms.ToolStrip toolStrip2;

    }
}

