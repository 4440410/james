using System;
using System.Data;
using System.Windows.Forms;



namespace xzc
{
    public partial class s_form : Form
    {
        xzc.DataCon datacon = new xzc.DataCon();
        public s_form()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }





        private void button1_Click(object sender, EventArgs e)
        {


            DataSet myds =  datacon.getds("select NumbID as 工号编号,UserName as 用户名称 from d_base", "d_base");

            dataGridView1.DataSource = myds.Tables[0];

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLook_Click(object sender, EventArgs e)
        {

            //dataGridView1.DataSource = datacon.SelectEInfo(cboxLCondition.Text, txtLKWord.Text).Tables[0];

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataSet myds = datacon.SelectEInfo("工号", Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));
            label1.Text = myds.Tables[0].Rows[0][0].ToString();
            label2.Text = myds.Tables[0].Rows[0][1].ToString();
            
        }
    }
}
