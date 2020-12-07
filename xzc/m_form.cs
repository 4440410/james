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
    
    public partial class M_form : Form
    {

        public M_form()
        {
            InitializeComponent();
        }

        private void M_form_Load(object sender, EventArgs e)
        {
            
        }

        private bool HaveOpened(Form _monthForm, string _childrenFormName)
        {
            //查看窗口是否已经被打开
            bool bReturn = false;
            for (int i = 0; i < _monthForm.MdiChildren.Length; i++)
            {
                if (_monthForm.MdiChildren[i].Name == _childrenFormName)
                {
                    _monthForm.MdiChildren[i].BringToFront();//将控件带到 Z 顺序的前面。
                    bReturn = true;
                    break;
                }
            }
            return bReturn;
        }
        private void toolStripMenu_sb_Click(object sender, EventArgs e)
        {

            sb_form_set sbset = new sb_form_set();
            if (!HaveOpened(this,"sb_form_set"))
            {
                
                sbset.MdiParent = this;
                sbset.Show();
            }
            else
            {
                MessageBox.Show(sbset.Text+"已经打开");

            }
        }

        private void toolStripMenu_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenu_monitor_Click(object sender, EventArgs e)
        {
            monitor_form sbset = new monitor_form();
            if (!HaveOpened(this, "monitor_form"))
            {

                sbset.MdiParent = this;
                sbset.Show();
            }
            else
            {
                MessageBox.Show(sbset.Text + "已经打开");

            }


        }

        private void toolStripMenu_reco_Click(object sender, EventArgs e)
        {
            rec_form sbset = new rec_form();
            if (!HaveOpened(this, "rec_form"))
            {

                sbset.MdiParent = this;
                sbset.Show();
            }
            else
            {
                MessageBox.Show(sbset.Text + "已经打开");

            }
        }

        private void toolStripMenu_wd_Click(object sender, EventArgs e)
        {
            wd_form sbset = new wd_form();
            if (!HaveOpened(this, "wd_form"))
            {

                sbset.MdiParent = this;
                sbset.Show();
            }
            else
            {
                MessageBox.Show(sbset.Text + "已经打开");

            }
        }

        private void toolStripMenu_qy_Click(object sender, EventArgs e)
        {
            qy_form sbset = new qy_form();
            if (!HaveOpened(this, "qy_form"))
            {

                sbset.MdiParent = this;
                sbset.Show();
            }
            else
            {
                MessageBox.Show(sbset.Text + "已经打开");

            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cprt sbset = new cprt();
            if (!HaveOpened(this, "cprt"))
            {

                sbset.MdiParent = this;
                sbset.Show();
            }
            else
            {
                MessageBox.Show(sbset.Text + "已经打开");

            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bj_form sbset = new bj_form();
            if (!HaveOpened(this, "bj_form"))
            {

                sbset.MdiParent = this;
                sbset.Show();
            }
            else
            {
                MessageBox.Show(sbset.Text + "已经打开");

            }
        }
    }
}
