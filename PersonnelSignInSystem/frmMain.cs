#region 文件说明
//Descrition:Provides usage information for the class and others
//
//Copyrigt (c) 2009 XueMen.com All rights reserved.
//$Author$
//$Revision$
//$LastChangedDate$
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonnelSignInSystem
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        #region 打开发卡页面
        private void tsbHairpin_Click(object sender, EventArgs e)
        {
            frmHairpin fh = new frmHairpin();
            fh.Show();
        }
        #endregion

        #region 打开打卡页面
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frm_PunchCard fp = new frm_PunchCard();
            fp.Show();
        }
        #endregion

        #region 打开会议签到页面
        private void tsbMeetingSign_Click(object sender, EventArgs e)
        {
            frmMeeting fm = new frmMeeting();
            fm.Show();
        }
       #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;
        }

    }
}
