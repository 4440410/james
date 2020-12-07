using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xzc
{
    public partial class bj_form : Form
    {
        public bj_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Navigate(textBox1.Text.Trim());
        }

        private void Navigate(String address)                                                    //实现页面导航

        {

            if (String.IsNullOrEmpty(address)) return;                                             //判断是否输入地址

            if (address.Equals("about:blank")) return;                                               //判断是否是空白页面

            if (!address.StartsWith("http://")) address = "http://" + address;                //设置标准的地址格式

            try

            {

                webBrowser1.Navigate(new Uri(address));                                     //转到指定的网站

            }

            catch (System.UriFormatException)                                                      //如果发生异常

            {

                return;                                                                    //返回

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!webBrowser1.Url.Equals("about:blank"))

            {

                webBrowser1.Refresh();                                                        //使用控件重新加载页

            }


        }
    }
}
