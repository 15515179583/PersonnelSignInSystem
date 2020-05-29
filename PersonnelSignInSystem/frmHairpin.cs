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
using System.Text.RegularExpressions;

namespace PersonnelSignInSystem
{
    public partial class frmHairpin : Form
    {
        KV_ISO15693.Reader reader = new Reader();  //实例化Reader类
        private Thread Thread_15693;              //创建线程
        private delegate void ShowTextBoxMessageDel(TextBox txt, string msg);//定义委托
        Regex regex = new Regex("[1][0-9]{17}");
        public frmHairpin()
        {
            InitializeComponent();
        }

        #region 窗体的Load事件
        private void Hairpin_Load(object sender, EventArgs e)
        {
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
                    Int32 TagCount = 0;                         //TagCount用于返回读取到的卡片数量
                    String[] TagNumber = new String[1];         //TagNumber用于返回读取到的所有卡片的卡号
                    Byte value = reader.Inventory(mm, im, ref TagCount, ref TagNumber);//寻卡
                    if (TagCount == 1)                           //如果寻到一张卡
                    {
                        SetTextValue(txtAccessID, TagNumber[0]); //通过委托设置TextBox控件的值
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

        #region 登记信息
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (this.txtAccessID.Text == "")
            {
                MessageBox.Show("门禁卡号不能为空", "消息对话框", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (this.txtStaffName.Text == "")
            {
                MessageBox.Show("人员姓名不能为空", "消息对话框", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (this.cmbStaffSex.Text == "")
            {
                MessageBox.Show("人员性别不能为空", "消息对话框", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (regex.IsMatch(this.txtIDNO.Text) == false)
            {
                MessageBox.Show("身份证号错误", "消息对话框", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlHelper sh = new SqlHelper();
                sh.cardID = txtAccessID.Text.Trim();    //将控件中的值赋给变量
                sh.name = txtStaffName.Text.Trim();
                sh.sex = cmbStaffSex.Text.Trim();
                sh.identifyCardID = txtIDNO.Text.Trim();
                if (sh.CheckEmployees())
                {
                    MessageBox.Show("该卡已登记!");
                    return;
                }
                sh.Insert();                           //通过SqlHelper的对象调用Insert方法将用户信息存入数据库
                int i = sh.IsSuccess();                //通过数据库中表的受影响行数判断登记信息是否成功
                if (i > 0)
                {
                    MessageBox.Show("登记信息成功!");
                }
                else
                {
                    MessageBox.Show("数据库错误!登记信息失败!");
                }
            }
        }
        #endregion

        #region 在关闭窗体时关闭串口和线程,释放系统资源
        private void frmHairpin_FormClosed(object sender, FormClosedEventArgs e)
        {          
            if (reader.IsOpen)
            {
                Byte value = reader.CloseSerialPort();//通过Reader类的对象调用CloseSerialPort()方法关闭串口
                if (value == 0x00)
                {
                    MessageBox.Show("串口关闭成功!");
                    //Thread_15693.Abort();             //中止线程

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

        private void txtIDNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)8 || e.KeyChar == (char)88 || e.KeyChar == (char)120)
            {
                if ((e.KeyChar == (char)8))
                {
                    e.Handled = false;
                    return;
                }
                else
                {
                    int len = ((TextBox)sender).Text.Length;
                    if ((e.KeyChar == (char)88 || e.KeyChar == (char)120) && len != 17)
                    {
                        return;
                    }

                    if (len == 0 && e.KeyChar != '0')
                    {
                        e.Handled = false;
                        return;
                    }
                    else if (len == 0 || len == 18)
                    {
                        return;
                    }
                    e.Handled = false;
                }
            }
        }

        private void txtStaffName_TextChanged(object sender, EventArgs e)
        {
            int len = ((TextBox)sender).Text.Length;
            if (len > 15)
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text.Substring(0, len - 1);
            }
        }
    }
}
