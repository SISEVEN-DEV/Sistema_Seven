using System;
using System.Windows.Forms;

namespace _7_Sistema_Config
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
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
                    Application.Run(new FrmConfiguracao());
                }
            }
        }
    }
}
