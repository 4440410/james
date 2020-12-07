using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace xzc
{
    public partial class o_form : Form
    {
        
        string ipaddress;
        
        public o_form()
        {
            InitializeComponent();
        }

        private void o_form_Load(object sender, EventArgs e)
        {

            button5.Enabled = false;

        }


        

        private void button3_Click(object sender, EventArgs e)
        {
            ipaddress = textBox1.Text;
            //MessageBox.Show(comboBox1.SelectedItem.);

            timer1.Interval = int.Parse(comboBox1.SelectedItem.ToString());

            label2.Text= textBox1.Text;
            label3.Text = comboBox1.SelectedItem.ToString();

        }

       

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            button6.Enabled = true;
            button5.Enabled = false;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            button6.Enabled = false;
            button5.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if (netconstat.GetInternetConStatus.PingNetAddress(ipaddress))
            {
                label1.ForeColor = System.Drawing.Color.Green;
                label1.Text = "在线";
            }
            else
            {
                label1.ForeColor = System.Drawing.Color.Red;
                label1.Text = "离线";
            }
        }
    }
}
