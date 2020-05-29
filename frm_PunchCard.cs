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
    public partial class frm_PunchCard : Form
    {
        KV_ISO15693.Reader reader = new Reader();//实例化Reader类
        SqlHelper sh = new SqlHelper();          //实例化SqlHelper类
        private Thread Thread_15693;             //创建线程
        private delegate void ShowTextBoxMessageDel(TextBox txt, string msg);//定义委托
        public frm_PunchCard()
        {
            InitializeComponent();
        }

        #region 窗体的Load事件
        private void frm_PunchCard_Load(object sender, EventArgs e)
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
                SetTextValue(txtAccessID, "");//通过委托设置TextBox控件的值
                try
                {
                    ModulateMethod mm = ModulateMethod.ASK;     //设置读写器的调制方式为ASK(幅移键控)
                    InventoryModel im = InventoryModel.Multiple;//设置读写器的寻卡方式为寻多卡Multiple(寻多卡)
                    Int32 TagCount = 0;                         //TagCount用于返回读取到的卡片数量
                    String[] TagNumber = new String[1];         //TagNumber用于返回读取到的所有卡片的卡号
                    Byte value = reader.Inventory(mm, im, ref TagCount, ref TagNumber);//寻卡
                    sh.SearchCardInfo(TagNumber[0]);
                    bool flag = sh.flagCard;
                    if (flag)
                    {
                        if (TagCount == 1)                         //如果寻到一张卡
                        {
                            sh.SearchCardInfo(TagNumber[0]);
                            SetTextValue(txtAccessID, sh.cardInfoName);//通过委托设置TextBox控件的值
                            SignInOrOut();

                        }
                    }
                    Thread.Sleep(100);                          //让线程休眠一秒
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("扫描失败");
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion

        #region 查询签到/签退情况
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbCheckStatus.Text.Trim() != null) //如果cmbCheckStatus不为空
            {
                DataSet ds = sh.CheckingInOrOut(cmbCheckStatus.Text.Trim());//调用CheckingInOrOut方法查询指定条件的签到/签退信息并将返回的结果存储在DataSet缓存中
                dgvCheckInOrOutInfo.DataSource = ds.Tables[0];              //通过设置dgvCheckInOrOutInfo的数据源显示查询结果
              

            }
            else
            {
                MessageBox.Show("查询失败，请先选择查询条件再进行查询！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);   
            }
        }
        #endregion

        #region 签到/签退
        private void SignInOrOut()
        {
            if (txtAccessID.Text.Trim() != null)
            {
                string SignStatus;
                sh.SearchCardInfo(txtAccessID.Text.Trim());//查询将要签到的卡的信息
                int hour = DateTime.Now.Hour;              //根据当前时间判断签到状态
                if (hour <= 8)
                {
                    SignStatus = "已签到";
                }
                else if(hour>8&&hour<=12)
                {
                    SignStatus = "迟到";
                }
                else if (hour > 12 && hour < 18)
                {
                    SignStatus = "早退";
                }
                else 
                {
                    SignStatus = "已签退";
                }

                sh.InsertCheckInfo(SignStatus);//将已签到的卡的卡号和对应的人员信息插入数据库
                int i = sh.IsSuccess();
                if (i > 0)
                {
                    MessageBox.Show("签到/签退成功!");
                }
                else
                {
                    MessageBox.Show("数据库错误!签到/签退失败!");
                }
            }
        }
        #endregion

        #region 在关闭窗体时关闭串口和线程,释放系统资源
        private void frm_PunchCard_FormClosed(object sender, FormClosedEventArgs e)
        {
           
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
                try { this.Invoke(del, txt, msg); }
                catch { }
                
            }
            else
            {
                txt.Text = msg;
            }
        }
        #endregion

        #region 当前时间
        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString();
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            dgvCheckInOrOutInfo.DataSource = null;
        }

    }
}
