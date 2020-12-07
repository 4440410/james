using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace xzc
{
    
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            log_in log = new log_in();
            log.ShowDialog();
            if (log.DialogResult==DialogResult.OK)
            {
                Application.Run(new M_form());
            }
            
        }
    }
}
