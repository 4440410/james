using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;

namespace xzc
{
    public partial class qy_form : Form
    {
        xzc.DataCon datacon = new xzc.DataCon();
        public int qyid;
        public qy_form()
        {
            InitializeComponent();
        }

        private void qy_form_Load(object sender, EventArgs e)
        {
            DataSet myds = datacon.getds("select qyID as 编号,qyName as 区域名字 from d_qy ", "d_qy");

            dataGridView1.DataSource = myds.Tables[0];
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            
           if (e.RowIndex >= 0)//判断是否超出索引
            {
                DataSet myds = datacon.getds("select * from d_qy where qyID = '" + Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()) + "' ", "d_qy");
                textBox1.Text = myds.Tables[0].Rows[0][1].ToString();
                


                qyid = Convert.ToInt32(myds.Tables[0].Rows[0][0].ToString());//Rows[0][0]是数据表字段第一行第一列
                label1.Text =  qyid.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" )
            {
                SqlCommand sqlcmd = new SqlCommand("qy_InsertEInfo", datacon.getcon());
                sqlcmd.CommandType = CommandType.StoredProcedure; //使用sqlserver存储过程

                sqlcmd.Parameters.Add("@qyname", SqlDbType.Char, 30).Value = textBox1.Text.Trim();
                

                SqlParameter returnValue = sqlcmd.Parameters.Add("@returnValue", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.ReturnValue;
                sqlcmd.ExecuteNonQuery();
                datacon.getcon().Close();
                int int_returnValue = (int)returnValue.Value;
                if (int_returnValue == 0)
                    MessageBox.Show("区域已经存在！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("新区域——添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataSet myds = datacon.getds("select qyID as 编号,qyName as 区域名字 from d_qy ", "d_qy");

                dataGridView1.DataSource = myds.Tables[0];
            }
            else
            {
                MessageBox.Show("区域名不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" && qyid != 0)
            {


                SqlCommand sqlcmd = new SqlCommand("qy_UpdateEInfo", datacon.getcon());
                sqlcmd.CommandType = CommandType.StoredProcedure; //使用sqlserver存储过程

                
                sqlcmd.Parameters.Add("@qyname", SqlDbType.Char, 30).Value = textBox1.Text.Trim();
               
                sqlcmd.Parameters.Add("@qyid", SqlDbType.Int).Value = qyid;

                SqlParameter returnValue = sqlcmd.Parameters.Add("@returnValue", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.ReturnValue;
                sqlcmd.ExecuteNonQuery();
                datacon.getcon().Close();



                //判断网点名是否存在
                int int_returnValue = (int)returnValue.Value;
                if (int_returnValue == 0)
                    MessageBox.Show("区域已经存在！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (int_returnValue == 1)

                {
                    MessageBox.Show(qyid.ToString() + "号区域信息——修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataSet myds = datacon.getds("select qyID as 编号,qyName as 区域名字 from d_qy ", "d_qy");
                dataGridView1.DataSource = myds.Tables[0];

                }
                    


                else if (int_returnValue == 2)
                    MessageBox.Show("qyid是空值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);



                qyid = 0;
                label1.Text = qyid.ToString();
            }
            else
                MessageBox.Show("区域名或qyid不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand sqlcmd = new SqlCommand("qy_DeleteEInfo", datacon.getcon());
            sqlcmd.CommandType = CommandType.StoredProcedure;//使用sqlserver存储过程

            sqlcmd.Parameters.Add("@qyid", SqlDbType.Int).Value = qyid;


            SqlParameter returnValue = sqlcmd.Parameters.Add("@returnValue", SqlDbType.Int);
            returnValue.Direction = ParameterDirection.ReturnValue;

            sqlcmd.ExecuteNonQuery();
            datacon.getcon().Close();

            int int_returnValue = (int)returnValue.Value;
            if (int_returnValue == 1)
            {
                MessageBox.Show(qyid.ToString() + "号区域——删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                qyid = 0;
                label1.Text = qyid.ToString();

                DataSet myds = datacon.getds("select qyID as 编号,qyName as 区域名字 from d_qy ", "d_qy");
                dataGridView1.DataSource = myds.Tables[0];

            }





            else if (int_returnValue == 2)
                MessageBox.Show("qyid是空值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (int_returnValue == 3)
                MessageBox.Show("区域下面有数据，不能删除", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);





        
        }
    }
}
