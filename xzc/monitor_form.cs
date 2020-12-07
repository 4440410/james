using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace xzc
{
    public partial class monitor_form : Form
    {
        TcpClient tcpClient = new TcpClient();
        NetworkStream ns = null;
        Thread t;
        //string jobj;
        public monitor_form()
        {
            InitializeComponent();
        }


        void ShowMsg(string str)
        {
            if (txtLog1.InvokeRequired)//判断是否跨线程访问：true就是跨线程
            {
                txtLog1.Invoke(new Action<string>(ss =>
                {
                    txtLog1.AppendText("\r\n" + ss + "\r\n");
                }), str);
            }
            else
            {
                    txtLog1.AppendText(str + "\r\n");
            }
        }

        private void btConn_Click(object sender, EventArgs e)
        {
            tcpClient.Connect(IPAddress.Parse(tbIP.Text), int.Parse(tbPort.Text));

            //byte[] bytes = BigEndianUIntHelper.ToBytes(85768);
            ns = tcpClient.GetStream();
            btConn.Enabled = !tcpClient.Connected;
            button2.Enabled = tcpClient.Connected;
            //btSend.Enabled = tcpClient.Connected;
            //btclr.Enabled = tcpClient.Connected;
            t = new Thread(new ThreadStart(Listen));
            t.IsBackground = true;
            t.Start();
            ShowMsg(DateTime.Now.ToString("yyyyMMdd") + " " + DateTime.Now.ToString("t") + " " + ":连接成功");

        }

        

        public void Listen()
        { 
            byte[] byteReceive = new byte[1024 * 1024];
            while (ns != null)
            {
                try
                {
                    if (ns.DataAvailable)
                    {
                        
                        int len = ns.Read(byteReceive, 0, byteReceive.Length);
                        if(len==0)
                        {
                            break;
                        }
                        string strReceive = Encoding.UTF8.GetString(byteReceive);

                        // jobj = (JObject)JsonConvert.DeserializeObject(strReceive);
                        //jobj = JsonConvert.SerializeObject(strReceive);
                        //jobj = strReceive;
                        strReceive = strReceive.Replace("\"","");
                        strReceive = strReceive.Replace("{", "");
                        strReceive = strReceive.Replace("}", "");
                        strReceive = strReceive.Replace(",", "   ");

                        ShowMsg(DateTime.Now.ToString("yyyyMMdd") + " " + DateTime.Now.ToString("t") + ":" + strReceive );
                        
                        // ShowMsg("test");
                         
                       /*  JObject boyb = JObject.Parse(strReceive);
                           JObject js = boyb as JObject;

                           JToken wdmod = js["wdname"];
                           JToken qymod = js["qyname"];
                           JToken recmod = js["recdata"]; 
                          ShowMsg(DateTime.Now.ToString("yyyyMMdd") + " " + DateTime.Now.ToString("t") + ":" + qymod.ToString() + "---" + wdmod.ToString() + "---" + recmod.ToString());*/
                        //Console.WriteLine("receive: " + strReceive);




                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error: " + ex.Message);
                    break;
                }
                finally
                {
                    Thread.Sleep(100);
                }

            }
        }

        private void monitor_form_Load(object sender, EventArgs e)
        {
            
            /*
            string wdname = "枫泾支行";
            string qyname = "金山";
            string r_str = "{\"wdname\":\"" + wdname + "\",\"qyname\":\"" + qyname + "\"}";

            JObject boyb = JObject.Parse(r_str);
            JObject js = boyb as JObject;

            JToken model = js["qyname"];
            txtLog.Text = r_str;//model.ToString();
            */

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowMsg("test");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            tcpClient.Close();          
            tcpClient.Dispose();
            t.Abort();
            btConn.Enabled = !tcpClient.Connected;
            button2.Enabled = tcpClient.Connected;

            ShowMsg(DateTime.Now.ToString("yyyyMMdd") + " " + DateTime.Now.ToString("t") + " " + ":已断开连接");

           
            this.Dispose();
            //this.Controls.Clear(); 
            //InitializeComponent();
            //this.monitor_form_Load(null,null);
            // tcpClient = null;

        }
    }
}
