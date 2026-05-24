using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class bllLayoutPDV
    {



        public static void Salvar(byte layout_tipo, string cod_conexao_configuracoes )
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (LayoutPDV Lay = new LayoutPDV())
                {
                    Lay.Layout_Tipo = layout_tipo;
                    //
                    Lay.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Salvar_Layout_PDV(Lay);
                }
            }
        }

        public static void Alterar(byte layout_tipo, string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (LayoutPDV Lay = new LayoutPDV())
                {
                    Lay.Layout_Tipo = layout_tipo;
                    //
                    Lay.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Alterar_Layout_PDV(Lay);
                }
            }
        }

        public static DataTable Sel_Layout_PDV_Todos(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (LayoutPDV Lay = new LayoutPDV())
                {
                    Lay.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    return con.Sel_Layout_PDV_Todos(Lay);
                }
            }
        }

    }
}
