using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BLL
{
    public class bllLocalArquivosSistema
    {
        public static void Salvar(string local_comprovante_pagamento_conta_a_pagar)
        {
            
        }

        public static void Alterar(string local_comprovante_pagamento_conta_a_pagar)
        {

        }

        public static DataTable Sel_Tabela_Local_Arquivos_Sistema_Configuracoes()
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                return con.Sel_Tabela_Local_Arquivos_Sistema_Configuracoes();
            }
        }








    }
}
