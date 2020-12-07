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
    public partial class log_in : Form
    {
        M_form m_form = new M_form();
        public log_in()
        {
            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            
           this.DialogResult = DialogResult.OK;
            
        }
    }
}
