using BLL;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Seven_Sistema
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
            //
            using (FrmLogin Login = new FrmLogin())
            {
                if (Login.ShowDialog() == DialogResult.OK)
                {
                    if (bllLayoutPDV.Sel_Layout_PDV_Todos(bllConexao._Codigo_Conexao) != null)
                    {
                        DataRow dr = bllLayoutPDV.Sel_Layout_PDV_Todos(bllConexao._Codigo_Conexao).Rows[0];
                        //
                        if (Convert.ToByte(dr["layout_tipo"]) == 0)
                        {
                            Application.Run(new FrmSistema());
                        }
                        else
                        {
                            Application.Run(new FrmSistemaBigPicture());
                        }
                    }
                    else
                    {
                        using (FrmLayoutPDV Lay = new FrmLayoutPDV(0))
                        {
                            if (Lay.ShowDialog() == DialogResult.OK)
                            {
                                DataRow dr = bllLayoutPDV.Sel_Layout_PDV_Todos(bllConexao._Codigo_Conexao).Rows[0];
                                //
                                if (Convert.ToByte(dr["layout_tipo"]) == 0)
                                {
                                    Application.Run(new FrmSistema());
                                }
                                else
                                {
                                    Application.Run(new FrmSistemaBigPicture());
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
