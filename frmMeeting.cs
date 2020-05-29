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
using KV_ISO15693;
using System.Threading;
using System.IO.Ports;

namespace PersonnelSignInSystem
{
    public partial class frmMeeting : Form
    {
        KV_ISO15693.Reader reader = new Reader();  //实例化Reader类      
        private Thread Thread_15693;               //创建线程
        private delegate void ShowTextBoxMessageDel(TextBox txt, string msg);//定义委托
        SqlHelper sh = new SqlHelper();            //实例化SqlHelper类
        bool flag = false;
        public frmMeeting()
        {
            InitializeComponent();
        }
        #region 窗体的Load事件
        private void frmMeeting_Load(object sender, EventArgs e)
        {
            timer1.Start();
            Byte value = reader.OpenSerialPort(Program.PortName);//打开串口
            if (value == 0x00)
            {
                MessageBox.Show("串口打开成功");

                //启动线程
                Thread_15693 = new Thread(new ThreadStart(ReadCard));//循环读卡
                Thread_15693.IsBackground = true;
                Thread_15693.Start();

            }
            else
            {
                MessageBox.Show("串口打开失败,请检查设备端口是否连接正常！");
            }
        }
        #endregion

        #region 读卡方法
        /// <summary>
        /// 读卡方法
        /// </summary>
        private void ReadCard()
        {
            while (true)
            {
                try
                {
                    ModulateMethod mm = ModulateMethod.ASK;     //设置读写器的调制方式为ASK(幅移键控)
                    InventoryModel im = InventoryModel.Multiple;//设置读写器的寻卡方式为寻多卡Multiple(寻多卡)
                    Int32 TagCount = 0;                          //TagCount用于返回读取到的卡片数量
                    String[] TagNumber = new String[1];           //TagNumber用于返回读取到的所有卡片的卡号
                    Byte value = reader.Inventory(mm, im, ref TagCount, ref TagNumber);//寻卡
                    SetTextValue(txtAccessID, "");  
                    SetTextValue(txtAccessName, "");
                    if (TagCount == 1)                             //如果寻到一张卡
                    {
                        sh.SearchCardInfo(TagNumber[0]);
                        SetTextValue(txtAccessID, TagNumber[0]);   //通过委托设置TextBox控件的值
                        SetTextValue(txtAccessName, sh.cardInfoName);
                        MeetingSign();
                    }
                    Thread.Sleep(100);                            //让线程休眠一秒
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("扫描失败");
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion

        #region 会议签到
        private void MeetingSign()
        {
            if (txtAccessID.Text.Trim() != null && textBox1.Enabled == false)
            {
                sh.SearchCardInfo(txtAccessID.Text.Trim());//查询将要签到的卡的信息
                flag = sh.IsMeetingSign(textBox1.Text.Trim());
                if (!flag)
                {
                    sh.InsertMeetingSignInfo(textBox1.Text.Trim());                //将会议签到信息存入数据库
                    int i = sh.IsSuccess();
                    if (i > 0)
                    {
                        MessageBox.Show("会议签到成功!");
                    }
                    else
                    {
                        MessageBox.Show("数据库错误!会议签到信息失败!");
                    }
                }
            }
            else
            {
                MessageBox.Show("没有搜索到卡片或当前未创建会议！");
            }
        }
        #endregion

        #region 刷新已进行会议签到的人员信息
        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString();
            if (textBox1.Enabled == false && !flag)
            {
                DataSet ds = sh.RefreshMeetingSignInfo(textBox1.Text.Trim());//调用RefreshMeetingSignInfo()方法查询所有已进行会议签到的人员信息并将返回的结果存储在DataSet缓存中
                dgvMeeting.DataSource = ds.Tables[0];    //通过设置dgvCheckInOrOutInfo的数据源显示查询结果
                flag = true;
            }
        }
        #endregion

        #region 在关闭窗体时关闭串口和线程,释放系统资源
        private void frmMeeting_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
            if (reader.IsOpen)
            {
                Byte value = reader.CloseSerialPort();
                if (value == 0x00)
                {
                    MessageBox.Show("串口关闭成功!");
                    //Thread_15693.Abort();

                }
                else
                    MessageBox.Show("串口关闭失败!");
            }
            else
            {
                MessageBox.Show(String.Format("错误：串口已经处于关闭状态！"));
            }
        }
        #endregion

        #region 使用委托设置TextBox值得方法
        private void SetTextValue(TextBox txt, string msg)
        {
            if (txt.InvokeRequired)
            {
                ShowTextBoxMessageDel del = new ShowTextBoxMessageDel(SetTextValue);
                this.Invoke(del, txt, msg);
            }
            else
            {
                txt.Text = msg;
            }
        }
        #endregion

        #region 点击创建按钮
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                flag = false;
                textBox1.Enabled = false;
            }
            else
            {
                MessageBox.Show("请输入会议名称！");
            }
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(textBox1.Text + " 已结束！");
            textBox1.Text = "";
            textBox1.Enabled = true;
            dgvMeeting.DataSource = null;
            flag = true;
        }

    }
}
