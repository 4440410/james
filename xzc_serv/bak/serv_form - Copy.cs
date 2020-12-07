using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace xzc_serv
{
    public partial class serv_form : Form
    {
        xzc_serv.DCon dcon = new xzc_serv.DCon();
        Socket socketCommunication;
        string wdname, qyname,ipaddress,ip;
        

        public serv_form()
        {
            InitializeComponent();
            //Control.CheckForIllegalCrossThreadCalls = false;
            
        }

        //定义一个键值对集合，用于存储客户端的ip+端口及对应负责通信的socket对象
        Dictionary<string, Socket> dicSocket = new Dictionary<string, Socket>();

        void ShowMsg(string str)
        {
            if (txtLog.InvokeRequired)//判断是否跨线程访问：true就是跨线程
            {
                txtLog.Invoke(new Action<string>(s =>
                {
                    txtLog.AppendText(s + "\r\n");
                }),str);
            }
            else
            {
                txtLog.AppendText(str + "\r\n");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Socket socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建socket连接
            
            IPAddress ip = IPAddress.Parse(textBox1.Text);
            IPEndPoint endPoint = new IPEndPoint(ip,8000);
            socketWatch.Bind(endPoint);            
            socketWatch.Listen(10);

            Thread thread = new Thread(Listen);
            thread.IsBackground = true;
            thread.Start(socketWatch);
            toolStripStatusLabel1.Text = "监听已启动";
            button1.Enabled = false;
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ip = null;
            ShowMsg("发送目标解除");
        }

        private void serv_form_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
             
            if(listBox1.SelectedItem == null)
            {
                ShowMsg("IP未选择");
            }
            else
            {
                ip = listBox1.SelectedItem.ToString();
                ShowMsg(ip + "已设置");
            }
            
            
        }

        void Listen(object obj) //创建监听方法
        {
            Socket socketWatch = obj as Socket;
            while (true)
            {
                socketCommunication = socketWatch.Accept();//等待客户端的连接，同时会创建一个与其通信的socket
                
                dicSocket.Add(socketCommunication.RemoteEndPoint.ToString(), socketCommunication);
                //解决跨线程访问listbox所导致的问题
                if(listBox1.InvokeRequired)
                {
                    //comboBox1.Invoke(new Action(() => { comboBox1.Items.Add(socketCommunication.RemoteEndPoint.ToString()); }), null);
                    listBox1.Invoke(new Action(() => { listBox1.Items.Add(socketCommunication.RemoteEndPoint.ToString()); }), null);
                }
                else
                {
                    //comboBox1.Items.Add(socketCommunication.RemoteEndPoint.ToString());
                    listBox1.Items.Add(socketCommunication.RemoteEndPoint.ToString());
                }

                ShowMsg(DateTime.Now.ToString("yyyyMMdd") + " " + DateTime.Now.ToString("t") + " " + ((IPEndPoint)socketCommunication.RemoteEndPoint).Address.ToString() + ":连接成功");    

                Thread thread = new Thread(Receive);//开线程接收消息
                thread.IsBackground = true;
                thread.Start(socketCommunication);
                
            }
         
        }

        void Receive(object obj)//创建接收消息方法
        {
            Socket socketCommunication = obj as Socket;
            byte[] buffer = new byte[1024 * 1024];
            
            while (true)
            {
               
                //r表示实际接收到的字节数
                int r = socketCommunication.Receive(buffer);
                if(r==0)//判断对方下线停止发送消息
                {
                    //break;
                    ip = null;
                    ShowMsg(((IPEndPoint)socketCommunication.RemoteEndPoint).Address.ToString() + " " + DateTime.Now.ToString() + " 下线");
                    socketCommunication.Shutdown(SocketShutdown.Both);
                    socketCommunication.Close();
                    return;
                }
                string str = Encoding.UTF8.GetString(buffer, 0, r);
                //显示消息格式：客户端ip 端口：消息
                ShowMsg(DateTime.Now.ToString("yyyyMMdd") + " " + DateTime.Now.ToString("t") + " "+ ((IPEndPoint)socketCommunication.RemoteEndPoint).Address.ToString() + ":" + str);
                ipaddress = ((IPEndPoint)socketCommunication.RemoteEndPoint).Address.ToString();


                //追加数据库表rec_DB,通过接收到的ip地址判断是否做过登记，如果登记过的ip自动加上wdname和qyname，否则加上未登记
                
                SqlDataReader ott = dcon.getread("select * from sb_fb where ip_address = '" + ipaddress + "'"); 
                
                if (ott.Read())
                {
                   
                    //找到ip，通过ip唯一性找wdid,获得wdid再找wdname
                    ott = dcon.getread("select * from qy_wd where wdID = '" + ott[4] + "'");
                    if (ott.Read())
                    {
                        wdname=ott[1].ToString().Trim();//wdname

                        //找到wdname，获得本记录的qyid
                        ott = dcon.getread("select * from d_qy where qyID = '" + ott[3] + "'");
                        if (ott.Read())
                        {
                            qyname=ott[1].ToString().Trim();//qyname
                            SqlCommand sqlcmd = new SqlCommand("rec_InsertEInfo", dcon.getcon());
                            sqlcmd.CommandType = CommandType.StoredProcedure; //使用sqlserver存储过程
                            sqlcmd.Parameters.Add("@dtNow", SqlDbType.Int).Value = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                            sqlcmd.Parameters.Add("@timeNow", SqlDbType.Char, 10).Value = DateTime.Now.ToString("t");
                            sqlcmd.Parameters.Add("@recData", SqlDbType.Char, 100).Value = str.Trim();
                            sqlcmd.Parameters.Add("@ipAddress", SqlDbType.Char, 20).Value = ((IPEndPoint)socketCommunication.RemoteEndPoint).Address.ToString();
                            sqlcmd.Parameters.Add("@wdName", SqlDbType.Char, 30).Value = wdname.Trim();
                            sqlcmd.Parameters.Add("@qyName", SqlDbType.Char, 10).Value = qyname.Trim();
                            sqlcmd.ExecuteNonQuery();
                            //sqlcon.Close();
                            dcon.getcon().Close();
                            dcon.getcon().Dispose();


                           string r_str = "{\"区域\":\"" + qyname + "\",\"网点\":\"" + wdname + "\",\"报警内容\":\"" + str + "\"}";
                                                       
                            //string json = JsonConvert.SerializeObject(r_str);
                           buffer = Encoding.UTF8.GetBytes(r_str);
                            
                            if (ip=="" || ip==null)
                            {
                                //socketCommunication.Send(buffer);
                                ShowMsg("未设置发送目标");
                                
                            }
                            else
                            {
                                dicSocket[ip].Send(buffer); //接收一条向监控窗口发一条
                            }

                        }
                           
                         else
                            MessageBox.Show("qyname不会没找到");//不会找不到
                    }
                    else
                        MessageBox.Show("wdname不会找不到");//不会找不到

                }
                else
                { 
                //这是未登记ip的
                /*
                SqlCommand sqlcmd = new SqlCommand("rec_InsertEInfo", dcon.getcon());
                sqlcmd.CommandType = CommandType.StoredProcedure; //使用sqlserver存储过程
                sqlcmd.Parameters.Add("@dtNow", SqlDbType.Int).Value = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                sqlcmd.Parameters.Add("@timeNow", SqlDbType.Char, 10).Value = DateTime.Now.ToString("t");
                sqlcmd.Parameters.Add("@recData", SqlDbType.Char, 100).Value = str.Trim();
                sqlcmd.Parameters.Add("@ipAddress", SqlDbType.Char, 20).Value = ((IPEndPoint)socketCommunication.RemoteEndPoint).Address.ToString();
                sqlcmd.Parameters.Add("@wdName", SqlDbType.Char, 30).Value= "未登记";
                sqlcmd.Parameters.Add("@qyName", SqlDbType.Char, 10).Value = "未登记";  
                sqlcmd.ExecuteNonQuery();
                */
                    dcon.getcon().Close();
                    dcon.getcon().Dispose();
                    ShowMsg(DateTime.Now.ToString("yyyyMMdd") + " " + DateTime.Now.ToString("t") + " " + "未登记IP:" + ((IPEndPoint)socketCommunication.RemoteEndPoint).Address.ToString() + "正在发送数据:" + str);
                }

                
            }
        }

        private void bt2_Click(object sender, EventArgs e)
        {

            dcon.getcon().Close();
            dcon.getcon().Dispose();
            Application.Exit();               
            
        }
    }
}
