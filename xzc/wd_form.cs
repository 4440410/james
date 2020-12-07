using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;

namespace xzc
{
    public partial class wd_form : Form
    {
        xzc.DataCon datacon = new xzc.DataCon();
        public int wdid,qyid;
        public wd_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null)//子节点
            {
                SqlDataReader p3_read = datacon.getread("select * from qy_wd where wdName = '" + e.Node.Text + "' ");//用网点名字获取网点id
                if (p3_read.Read())
                {

                    wdid = Convert.ToInt32(p3_read[0].ToString());
                    qyid = Convert.ToInt32(p3_read[3].ToString());
                    //MessageBox.Show(e.Node.Text);
                    label7.Text = qyid.ToString();
                    textBox1.Text = p3_read[1].ToString();
                    textBox3.Text = p3_read[2].ToString();


                }
                label5.Text = wdid.ToString();

            }
            else//父节点
            {
                SqlDataReader p3_read = datacon.getread("select * from d_qy where qyName = '" + e.Node.Text + "' ");//用区域名字获取区域id
                if (p3_read.Read())
                {
                    qyid = Convert.ToInt32(p3_read[0].ToString());
                    wdid = 0;
                    label7.Text = qyid.ToString();
                    label5.Text = wdid.ToString();
                    textBox1.Text = "";
                    textBox3.Text = "";
                }
                
            } 
        }

        private void button3_Click(object sender, EventArgs e) //添加
        {
            if (textBox1.Text.Trim() != "" && qyid != 0 )
            {
                

                SqlCommand sqlcmd = new SqlCommand("wd_InsertEInfo", datacon.getcon());
                sqlcmd.CommandType = CommandType.StoredProcedure; //使用sqlserver存储过程

                sqlcmd.Parameters.Add("@wdname", SqlDbType.Char, 50).Value = textBox1.Text.Trim();
                
                sqlcmd.Parameters.Add("@wd_address", SqlDbType.Char, 50).Value = textBox3.Text.Trim();
                
                sqlcmd.Parameters.Add("@qyid", SqlDbType.Int).Value = qyid;

                SqlParameter returnValue = sqlcmd.Parameters.Add("@returnValue", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.ReturnValue;
                sqlcmd.ExecuteNonQuery();
                datacon.getcon().Close();
                int int_returnValue = (int)returnValue.Value;
                if (int_returnValue == 0)
                    MessageBox.Show("已经存在该网点！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    MessageBox.Show("网点信息——添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    //重载treeview
                    treeView1.Nodes.Clear();
                    reloadtree();
                    treeView1.ExpandAll();
                    
                }
                    



            }
            else
            {
                MessageBox.Show("网点不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void button4_Click(object sender, EventArgs e)//修改
        {
            if (textBox1.Text.Trim() != "" && wdid !=0 )
            {
                

                SqlCommand sqlcmd = new SqlCommand("wd_UpdateEInfo", datacon.getcon());
                sqlcmd.CommandType = CommandType.StoredProcedure; //使用sqlserver存储过程

                sqlcmd.Parameters.Add("@wdid", SqlDbType.Int).Value = wdid;
                sqlcmd.Parameters.Add("@wdname", SqlDbType.Char, 50).Value = textBox1.Text.Trim();
                sqlcmd.Parameters.Add("@wd_address", SqlDbType.Char, 50).Value = textBox3.Text.Trim();
                //sqlcmd.Parameters.Add("@qyid", SqlDbType.Int).Value = qyid;

                SqlParameter returnValue = sqlcmd.Parameters.Add("@returnValue", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.ReturnValue;
                sqlcmd.ExecuteNonQuery();
                datacon.getcon().Close();








                //判断网点名是否存在
                int int_returnValue = (int)returnValue.Value;
                if (int_returnValue == 0)
                    MessageBox.Show("网点名已经存在！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (int_returnValue == 1)
                {
                    MessageBox.Show(wdid.ToString() + "号网点信息——修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //重载treeview
                    treeView1.Nodes.Clear();
                    reloadtree();
                    treeView1.ExpandAll();
                }
                    

                else if (int_returnValue == 2)
                    MessageBox.Show("wdid是空值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                

                wdid = 0;
                label5.Text = wdid.ToString();
            }
            else
                MessageBox.Show("网点名或wdid不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)//删除
        {
           
            DialogResult dr = MessageBox.Show("确定要删除网点"+wdid, "删除确定", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            
            if (dr == DialogResult.OK && wdid != 0)
            {
                
                SqlCommand sqlcmd = new SqlCommand("wd_DeleteEInfo", datacon.getcon());
                sqlcmd.CommandType = CommandType.StoredProcedure;//使用sqlserver存储过程

                sqlcmd.Parameters.Add("@wdid", SqlDbType.Int).Value = wdid;
                

                SqlParameter returnValue = sqlcmd.Parameters.Add("@returnValue", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.ReturnValue;

                sqlcmd.ExecuteNonQuery();
                datacon.getcon().Close();

                int int_returnValue = (int)returnValue.Value;
                if (int_returnValue == 1)
                {
                    MessageBox.Show(wdid.ToString() + "号网点——删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    wdid = 0;
                    label5.Text = wdid.ToString();


                    //重载treeview
                    treeView1.Nodes.Clear();
                    reloadtree();
                    treeView1.ExpandAll();
                }
                    
                    



                else if(int_returnValue == 2)
                    MessageBox.Show("wdid是空值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (int_returnValue == 3)
                    MessageBox.Show("网点下面有数据，不能删除", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);



                

            }
            else
                MessageBox.Show("wdid是空值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void wd_form_Load(object sender, EventArgs e)
        {

            reloadtree();

        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("ok");
        }

        void reloadtree()
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
        }


        }
}
