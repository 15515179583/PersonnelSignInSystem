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
    public partial class frmSerialPort : Form
    {
        public frmSerialPort()
        {
            InitializeComponent();
        }

        private void frmSerialPort_Load(object sender, EventArgs e)
        {
            String[] PortNames = System.IO.Ports.SerialPort.GetPortNames();
            this.cmbPort.Items.Clear();
            if (PortNames.Length > 0)
            {
                for (Int32 i = 0; i < PortNames.Length; i++)
                {
                    if (PortNames[i].Length >= 7) continue;
                    this.cmbPort.Items.Add(PortNames[i]);
                }
                this.cmbPort.SelectedIndex = 0;
            }
            else
            { this.cmbPort.Text = "无串口"; }
        }

        private void btnOpenSerial_Click(object sender, EventArgs e)
        {
            Program.PortName = cmbPort.Text.Trim();
            Hide();
            frmMain frm = new frmMain();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
