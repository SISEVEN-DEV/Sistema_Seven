using System;
using System.Windows.Forms;

namespace Seven_Sistema
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


            using (FrmLogin Login = new FrmLogin())
            {
                if (Login.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new FrmSistema());
                }
            }
        }
    }
}
