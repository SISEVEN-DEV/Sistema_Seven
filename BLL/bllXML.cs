using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class bllXML
    {
        public static void Salvar(string cod_dfe, string texto_xml, bool saida)
        {
            using (Con7BD con = new Con7BD())
            {
                using (XML Xml = new XML()) 
                {
                    Xml.Cod_DFe = Convert.ToInt32(cod_dfe);
                    //
                    Xml.Texto_XML = texto_xml.Replace("'", "");
                    //
                    if (saida == true)
                    {
                        Xml.Saida = 1;
                    }
                    else
                    {
                        Xml.Saida = 0;
                    }
                    //
                    con.Salvar_XML(Xml);
                }
            }
        }

        public static void Excluir(string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (XML Xml = new XML())
                {
                    Xml.Cod_DFe = Convert.ToInt32(cod_dfe);
                    //
                    con.Excluir_XML(Xml);
                }
            }
        }

        public static DataTable Sel_Dados_XML(string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (XML Xml = new XML())
                {
                    Xml.Cod_DFe = Convert.ToInt32(cod_dfe);
                    //
                    return con.Sel_Dados_XML(Xml);
                }
            }
        }







    }
}
