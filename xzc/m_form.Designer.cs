namespace xzc
{
    partial class M_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenu_file = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenu_log = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenu_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenu_set = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenu_xinxi = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenu_qy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenu_wd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenu_sb = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenu_reco = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenu_monitor = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenu_file,
            this.toolStripMenu_set,
            this.toolStripMenu_reco,
            this.toolStripMenu_monitor,
            this.toolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1006, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenu_file
            // 
            this.toolStripMenu_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenu_log,
            this.toolStripSeparator1,
            this.toolStripMenu_exit});
            this.toolStripMenu_file.Name = "toolStripMenu_file";
            this.toolStripMenu_file.Size = new System.Drawing.Size(44, 21);
            this.toolStripMenu_file.Text = "文件";
            // 
            // toolStripMenu_log
            // 
            this.toolStripMenu_log.Name = "toolStripMenu_log";
            this.toolStripMenu_log.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenu_log.Text = "系统日志";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // toolStripMenu_exit
            // 
            this.toolStripMenu_exit.Name = "toolStripMenu_exit";
            this.toolStripMenu_exit.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenu_exit.Text = "退出";
            this.toolStripMenu_exit.Click += new System.EventHandler(this.toolStripMenu_exit_Click);
            // 
            // toolStripMenu_set
            // 
            this.toolStripMenu_set.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenu_xinxi,
            this.toolStripSeparator2,
            this.toolStripMenu_sb});
            this.toolStripMenu_set.Name = "toolStripMenu_set";
            this.toolStripMenu_set.Size = new System.Drawing.Size(44, 21);
            this.toolStripMenu_set.Text = "设置";
            // 
            // toolStripMenu_xinxi
            // 
            this.toolStripMenu_xinxi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenu_qy,
            this.toolStripMenu_wd});
            this.toolStripMenu_xinxi.Name = "toolStripMenu_xinxi";
            this.toolStripMenu_xinxi.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenu_xinxi.Text = "信息管理";
            // 
            // toolStripMenu_qy
            // 
            this.toolStripMenu_qy.Name = "toolStripMenu_qy";
            this.toolStripMenu_qy.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenu_qy.Text = "区域";
            this.toolStripMenu_qy.Click += new System.EventHandler(this.toolStripMenu_qy_Click);
            // 
            // toolStripMenu_wd
            // 
            this.toolStripMenu_wd.Name = "toolStripMenu_wd";
            this.toolStripMenu_wd.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenu_wd.Text = "网点";
            this.toolStripMenu_wd.Click += new System.EventHandler(this.toolStripMenu_wd_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(121, 6);
            // 
            // toolStripMenu_sb
            // 
            this.toolStripMenu_sb.Name = "toolStripMenu_sb";
            this.toolStripMenu_sb.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenu_sb.Text = "设备信息";
            this.toolStripMenu_sb.Click += new System.EventHandler(this.toolStripMenu_sb_Click);
            // 
            // toolStripMenu_reco
            // 
            this.toolStripMenu_reco.Name = "toolStripMenu_reco";
            this.toolStripMenu_reco.Size = new System.Drawing.Size(68, 21);
            this.toolStripMenu_reco.Text = "记录查询";
            this.toolStripMenu_reco.Click += new System.EventHandler(this.toolStripMenu_reco_Click);
            // 
            // toolStripMenu_monitor
            // 
            this.toolStripMenu_monitor.Name = "toolStripMenu_monitor";
            this.toolStripMenu_monitor.Size = new System.Drawing.Size(68, 21);
            this.toolStripMenu_monitor.Text = "设备监控";
            this.toolStripMenu_monitor.Click += new System.EventHandler(this.toolStripMenu_monitor_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(55, 21);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(92, 21);
            this.toolStripMenuItem1.Text = "网络终端报警";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // M_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 705);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "M_form";
            this.Text = "智能机具管理平台";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.M_form_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu_file;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu_exit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu_set;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu_xinxi;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu_qy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu_wd;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu_log;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu_reco;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu_monitor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu_sb;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}