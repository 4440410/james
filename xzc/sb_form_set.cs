using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;

namespace xzc
{
    public partial class sb_form_set : Form
    {
        xzc.DataCon datacon = new xzc.DataCon();
        public int test_j,fbID;
        public sb_form_set()
        {
            InitializeComponent();

        }


       

        private void sb_form_set_Load(object sender, EventArgs e)
        {
            treeView1.ShowLines = true;          //树视图获取区域、地点信息
            treeView1.HideSelection = false;
            

            SqlDataReader p_read = datacon.getread("select * from d_qy");



            while (p_read.Read())

            {
                TreeNode newNode1 = treeView1.Nodes.Add(p_read[1].ToString());
                SqlDataReader p2_read = datacon.getread("select * from qy_wd where qyID = '" + p_read[0] + "' ");

                while (p2_read.Read())

                {
                    TreeNode newNode12 = new TreeNode(p2_read[1].ToString());//二级节点 
                    //newNode12.Nodes.Add(p2_read[1].ToString()).Tag = qy_wd["wdId"];
                    newNode1.Nodes.Add(newNode12);


                }

            }

                       
            datacon.closedb();
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;

        }


        


        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            if (e.Node.Parent != null)
            {
                SqlDataReader p3_read = datacon.getread("select * from qy_wd where wdName = '" + e.Node.Text + "' ");//用网点名字获取网点id
                if (p3_read.Read())
                {
                    
                    test_j = Convert.ToInt32(p3_read[0].ToString());

                    //MessageBox.Show(e.Node.Text);
                    DataSet myds = datacon.getds("select fbId as 编号,csName as 厂商名,fbType as 设备类型,ip_address as IP地址 from sb_fb where wdID = '" + test_j + "' ", "sb_fb");

                    dataGridView1.DataSource = myds.Tables[0];
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button5.Enabled = true;
                    textBox1.Text = "";
                    textBox3.Text = "";
                    fbID = 0;
                    label7.Text = "fbID:" + fbID.ToString();

                    


                   // MessageBox.Show(e.Node.IsSelected.ToString());

                    /**if (e.Node.Checked)
                    {
                        e.Node.ForeColor = System.Drawing.Color.Green;
                    }**/



                }
                

                label5.Text = "wdID:"+test_j.ToString();
            }
            
                
                
            

        }

       

            private void button1_Click(object sender, EventArgs e)
        {
            //if (!treeView1.SelectedNode.IsExpanded)  //判断树视图节点是否打开

            treeView1.ExpandAll();




        }

        private void button2_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }



        //选中数据表事件
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

            //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());


            if (e.RowIndex >= 0)//判断是否超出索引
            {
                DataSet myds = datacon.SelectEInfo("工号", Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));
                textBox1.Text = myds.Tables[0].Rows[0][1].ToString();
                comboBox1.Text = myds.Tables[0].Rows[0][2].ToString();
                textBox3.Text = myds.Tables[0].Rows[0][3].ToString();
                

                fbID = Convert.ToInt32(myds.Tables[0].Rows[0][0].ToString());//Rows[0][0]是数据表字段第一行第一列
                label7.Text = "fbID:" + fbID.ToString();
            }
        }

        //添加按钮
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" && textBox3.Text.Trim() != "")
            {
                SqlConnection sqlcon = datacon.getcon();

                SqlCommand sqlcmd = new SqlCommand("proc_InsertEInfo", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure; //使用sqlserver存储过程

                sqlcmd.Parameters.Add("@CsName", SqlDbType.Char, 10).Value = textBox1.Text.Trim();
                sqlcmd.Parameters.Add("@fbType", SqlDbType.Char, 10).Value = comboBox1.Text.Trim();
                sqlcmd.Parameters.Add("@ip_address", SqlDbType.Char, 20).Value = textBox3.Text.Trim();
                sqlcmd.Parameters.Add("@wdID", SqlDbType.Int).Value = test_j;

                SqlParameter returnValue = sqlcmd.Parameters.Add("@returnValue", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.ReturnValue;
                sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
                int int_returnValue = (int)returnValue.Value;
                if (int_returnValue == 0)
                    MessageBox.Show("已经存在该IP地址！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("设备信息——添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataSet myds = datacon.getds("select fbId as 编号,CsName as 厂商名,fbType as 设备类型,ip_address as IP地址 from sb_fb where wdID = '" + test_j + "' ", "sb_fb");

                dataGridView1.DataSource = myds.Tables[0];
            }
            else
            {
                MessageBox.Show("设备型号或ip地址不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox3.Text = "";
        }

        //删除按钮
        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定要删除网点" + fbID, "删除确定", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

            if (dr == DialogResult.OK && fbID != 0)
            {
                SqlConnection sqlcon = datacon.getcon();
                SqlCommand sqlcmd = new SqlCommand("proc_DeleteEInfo", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;//使用sqlserver存储过程

                sqlcmd.Parameters.Add("@fbID", SqlDbType.Int).Value = fbID;

                SqlParameter returnValue = sqlcmd.Parameters.Add("@returnValue", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.ReturnValue;

                sqlcmd.ExecuteNonQuery();
                sqlcon.Close();

                int int_returnValue = (int)returnValue.Value;
                if (int_returnValue == 1)
                    MessageBox.Show(fbID.ToString() + "号设备——删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("fbID是空值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataSet myds = datacon.getds("select fbId as 编号,CsName as 厂商名,fbType as 设备类型,ip_address as IP地址 from sb_fb where wdID = '" + test_j + "' ", "sb_fb");
                dataGridView1.DataSource = myds.Tables[0];

                fbID = 0;
                label7.Text = "fbID:" + fbID.ToString();
            }
                
        }



        //修改按钮
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" && textBox3.Text.Trim() != "")
            {
                SqlConnection sqlcon = datacon.getcon();

                SqlCommand sqlcmd = new SqlCommand("proc_UpdateEInfo", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure; //使用sqlserver存储过程

                sqlcmd.Parameters.Add("@fbID", SqlDbType.Int).Value = fbID;
                sqlcmd.Parameters.Add("@CsName", SqlDbType.Char, 10).Value = textBox1.Text.Trim();
                sqlcmd.Parameters.Add("@fbType", SqlDbType.Char, 10).Value = comboBox1.Text.Trim();
                sqlcmd.Parameters.Add("@ip_address", SqlDbType.Char, 20).Value = textBox3.Text.Trim();
                sqlcmd.Parameters.Add("@wdID", SqlDbType.Int).Value = test_j;

                SqlParameter returnValue = sqlcmd.Parameters.Add("@returnValue", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.ReturnValue;
                sqlcmd.ExecuteNonQuery();
                sqlcon.Close();




                



                //判断同一个wdID中的ip_address是否存在
                int int_returnValue = (int)returnValue.Value;
                if (int_returnValue == 0)
                    MessageBox.Show("已经存在该IP地址！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (int_returnValue == 1)
                    MessageBox.Show(fbID.ToString() + "号设备信息——修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (int_returnValue == 2)
                    MessageBox.Show("fbID是空值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataSet myds = datacon.getds("select fbId as 编号,CsName as 厂商名,fbType as 设备类型,ip_address as IP地址 from sb_fb where wdID = '" + test_j + "' ", "sb_fb");
                dataGridView1.DataSource = myds.Tables[0];

                fbID = 0;
                label7.Text = "fbID:" + fbID.ToString();
            }
            else
                MessageBox.Show("设备型号或ip地址不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
