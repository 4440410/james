using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;


namespace xzc
{
    public partial class rec_form : Form
    {
        xzc.DataCon datacon = new xzc.DataCon();
        public int test_k, recID;
        int dtnow = int.Parse(DateTime.Now.ToString("yyyyMMdd"));



        public rec_form()
        {
            //设置窗体的双缓冲
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            InitializeComponent();

            //利用反射设置DataGridView的双缓冲
            Type dgvType = this.dataGridView1.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(this.dataGridView1, true, null);

        }

        private void rec_form_Load(object sender, EventArgs e)
        {
            //comboBox1.Items.Insert(0, "-------请选择-------");
            SqlDataReader qy_read = datacon.getread("select * from d_qy ");//获取区域
            while (qy_read.Read())
            {
                comboBox1.Items.Add(qy_read[1]);
            }
            qy_read.Close();
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataReader qy_read = datacon.getread("select * from d_qy where qyName = '" + comboBox1.Text.Trim() + "'");//通过区域名找qyid
            if (qy_read.Read())
            {
                SqlDataReader wd_read = datacon.getread("select * from qy_wd where qyID = '" + qy_read[0] + "'");//通过qyid找网点名
                
                    comboBox2.Enabled = true;
                    comboBox2.Items.Clear();

                    while (wd_read.Read())//添加网点下拉选项
                    {
                        comboBox2.Items.Add(wd_read[1]);
                    }
                    wd_read.Close();                    
                
                    
            }
            qy_read.Close();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet myds = datacon.getds("select dtNow as 日期,timeNow as 时间,qy as 区域,wd as 网点,recData as 内容,ipAddress as IP地址 from rec_db  where wd = '" + comboBox2.Text.Trim() + "' order by recID desc", "rec_db");

            dataGridView1.DataSource = myds.Tables[0];

            datacon.closedb();
        }

        

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            groupBox3.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            if (groupBox3.Enabled != false)
                groupBox3.Enabled = false;
            datasch(7);//一周


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (groupBox3.Enabled != false)
                groupBox3.Enabled = false;
            datasch(30);//一月
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (groupBox3.Enabled != false)
                groupBox3.Enabled = false;
            datasch(180);//半年
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
            {
                label6.Text = "请填写日期，不能空着";
            }
            else
            {
                if (int.Parse(textBox1.Text.Trim()) < int.Parse(textBox2.Text.Trim()))
                {
                    label6.Text = "首日期不能小于截止日期";
                }
                else
                {
                    DataSet myds = datacon.getds("select dtNow as 日期,timeNow as 时间,qy as 区域,wd as 网点,recData as 内容,ipAddress as IP地址 from rec_db where dtNow <= '" + int.Parse(textBox1.Text.Trim()) + "' and dtNow >= '" + int.Parse(textBox2.Text.Trim()) + "' order by recID desc", "rec_db");

                    dataGridView1.DataSource = myds.Tables[0];
                    datacon.closedb();
                }
            } 
            
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            datasch(0);//全部
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            textBox1.Text = dtnow.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            while (dataGridView1.Rows.Count != 0)
            {
                dataGridView1.Rows.RemoveAt(0);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)                                              //判断是否有数据

                return;                                                             //返回

            //创建Excel对象

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            excel.Application.Workbooks.Add(true);                                                //在Excel中添加一个工作簿

            excel.Visible = true;                                                        //设置Excel显示

            //生成字段名称

            for (int i = 0; i < dataGridView1.ColumnCount; i++)

            {

                excel.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;                         //将数据表格控件中的列表头填充到Excel中

            }

            //填充数据

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)                                       //遍历数据表格控件的所有行

            {

                for (int j = 0; j < dataGridView1.ColumnCount; j++)                                //遍历数据表格控件的所有列

                {

                    if (dataGridView1[j, i].ValueType == typeof(string))                                //判断遍历到的数据是否是字符串类型

                    {

                        excel.Cells[i + 2, j + 1] = "'" + dataGridView1[j, i].Value.ToString();          //填充Excel表格

                    }

                    else

                    {

                        excel.Cells[i + 2, j + 1] = dataGridView1[j, i].Value.ToString();          //填充Excel表格

                    }

                }

            }


        }

        void datasch(int dtsum)
        {
            

            if (dtsum == 0)
            {
                DataSet myds = datacon.getds("select dtNow as 日期,timeNow as 时间,qy as 区域,wd as 网点,recData as 内容,ipAddress as IP地址 from rec_db order by recID desc", "rec_db");

                dataGridView1.DataSource = myds.Tables[0];
                datacon.closedb();
            }
            else
            {
                int dtweek = dtnow - dtsum;
                DataSet myds = datacon.getds("select dtNow as 日期,timeNow as 时间,qy as 区域,wd as 网点,recData as 内容,ipAddress as IP地址 from rec_db where dtNow <= '" + dtnow + "' and dtNow > '" + dtweek + "' order by recID desc", "rec_db");

                dataGridView1.DataSource = myds.Tables[0];
                datacon.closedb();
            }
            
        }
    }
}
