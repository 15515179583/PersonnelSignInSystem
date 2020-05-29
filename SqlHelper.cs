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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace PersonnelSignInSystem
{
    class SqlHelper
    {
        #region 变量

        public string cardID;
        public string name;
        public string sex;
        public string identifyCardID;
        public string cardInfoCardID;
        public string cardInfoName;
        public string cardInfoSex;
        public bool flagCard;
        //建立连接字符串
        public static string GetConnectionString()
        {
            string strServer = AppDomain.CurrentDomain.BaseDirectory + "SqlConfig.txt";
            return File.ReadAllText(strServer);
        }
        public string connection = GetConnectionString();
        public int i = 0;
        //创建SqlConnection对象
        SqlConnection sc = new SqlConnection();

        #endregion

        #region 登记信息
        public void Insert()
        {
            sc.ConnectionString = connection;     //设置SqlConnecttion对象的连接字符串
            try
            {
                sc.Open();                         //打开数据库连接
                SqlCommand cmd = new SqlCommand(); //创建SqlCommand对象
                cmd.CommandType = CommandType.Text;//设置SqlCommand对象执行SQL文本命令
                cmd.Connection = sc;               //设置SqlCommand对象的Connection属性
                cmd.CommandText =                  //设置SqlCommand对象执行的Sql语句
                    "INSERT INTO tb_Employees values( '" + cardID + "','" + name + "','" + sex + "','" + identifyCardID + "')";
                i = cmd.ExecuteNonQuery();         //返回数据库中受影响的行数
            }
            finally
            {

                sc.Close();
            }
        }
        #endregion

        #region 查询是否已登记

        public bool CheckEmployees()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from tb_Employees where e_CardID='" + cardID + "'", connection);//通过SqlDataAdapter对象执行SQL语句
            DataSet ds = new DataSet();    //创建DataSet缓存对象
            sda.Fill(ds);                  //将查询结果存储在ds中

            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region 返回受影响的行数
        public int IsSuccess()
        {
            return i;
        }
        #endregion

        #region 查询签到/签退情况
        public DataSet CheckingInOrOut(string CheckingInOrOut)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select s_CardID,s_Name,s_SignStatus,s_Time from tb_SignIN where s_SignStatus='" + CheckingInOrOut + "' ORDER BY s_Time DESC", connection);//通过SqlDataAdapter对象执行SQL语句
            DataSet ds = new DataSet();    //创建DataSet缓存对象
            sda.Fill(ds);                  //将查询结果存储在ds中
            return ds;                     //返回ds
        }
        #endregion

        #region 查询签到/签退的卡对应的人员信息
        public void SearchCardInfo(string CardID)
        {
            //使用SqlDataAdapter建立数据库连接并同时执行SQL语句
            SqlDataAdapter sda = new SqlDataAdapter("select e_CardID,e_Name,e_Sex  from tb_Employees where e_CardID='" + CardID + "'", connection);
            DataSet ds = new DataSet();                        //建立数据集对象
            sda.Fill(ds);                                      //将SQL语句执行结果缓存在数据集ds中
            DataView dataCard = new DataView(ds.Tables[0]);    //创建自定义视图并将SQL语句执行结果存储在自定义视图中


            foreach (DataRowView row in dataCard)              //遍历自定义视图(SQL语句执行结果)并将结果分别存储在变量中
            {
                cardInfoCardID = row["e_CardID"].ToString();
                cardInfoName = row["e_Name"].ToString();
                cardInfoSex = row["e_Sex"].ToString();
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                flagCard = true;
            }
            else
            {
                flagCard = false;
            }
        }
        #endregion

        #region 将签到签退信息存入数据库
        public void InsertCheckInfo(string SignStatus)
        {
            sc.ConnectionString = connection;     //设置SqlConnecttion对象的连接字符串
            try
            {
                sc.Open();                         //打开数据库连接
                SqlCommand cmd = new SqlCommand(); //创建SqlCommand对象
                cmd.CommandType = CommandType.Text;//设置SqlCommand对象执行SQL文本命令
                cmd.Connection = sc;               //设置SqlCommand对象的Connection属性
                cmd.CommandText =                  //设置SqlCommand对象执行的Sql语句
                    "INSERT INTO tb_SignIN values( '" + cardInfoCardID + "', '" + cardInfoName + "', '" + cardInfoSex + "', '" + SignStatus + "','" + DateTime.Now + "')";
                i = cmd.ExecuteNonQuery();         //返回数据库中受影响的行数
            }
            finally
            {
                sc.Close();
            }
        }
        #endregion

        #region 将会议签到信息存入数据库
        public void InsertMeetingSignInfo(string meetingName)
        {
            sc.ConnectionString = connection;     //设置SqlConnecttion对象的连接字符串
            try
            {
                sc.Open();                         //打开数据库连接
                SqlCommand cmd = new SqlCommand(); //创建SqlCommand对象
                cmd.CommandType = CommandType.Text;//设置SqlCommand对象执行SQL文本命令
                cmd.Connection = sc;               //设置SqlCommand对象的Connection属性
                cmd.CommandText =                  //设置SqlCommand对象执行的Sql语句
                    "INSERT INTO tb_Meeting values( '" + meetingName + "', '" + cardInfoCardID + "', '" + cardInfoName + "', '" + cardInfoSex + "', '" + DateTime.Now + "')";
                i = cmd.ExecuteNonQuery();         //返回数据库中受影响的行数
            }
            finally
            {
                sc.Close();
            }
        }
        #endregion

        #region 刷新已进行会议签到的人员信息
        public DataSet RefreshMeetingSignInfo(string meetingName)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select m_CardID,m_IDName,m_Time from tb_Meeting where m_Name='" + meetingName + "' ORDER BY m_Time DESC", connection);//通过SqlDataAdapter对象执行SQL语句
            DataSet ds = new DataSet();//创建DataSet缓存对象
            sda.Fill(ds);              //将查询结果存储在ds中
            return ds;                 //返回ds
        }
        #endregion

        #region 查询已进行会议签到的人员信息
        public bool IsMeetingSign(string meetingName)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select m_CardID,m_IDName,m_Time from tb_Meeting where m_Name='" + meetingName + "' and m_CardID='" + cardInfoCardID + "'", connection);//通过SqlDataAdapter对象执行SQL语句
            DataSet myds = new DataSet();//创建DataSet缓存对象
            sda.Fill(myds);              //将查询结果存储在ds中
            if (myds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion



    }
}
