using DAL;

namespace BLL
{
    public class bllConexaoStatus
    {
        public static bool _FrmConexaoStatus_Ativo;

        public void RegistrarComputador(string _nome_computador, string _ip_computador)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ConexaoStatus Conexao = new ConexaoStatus())
                {
                    Conexao.Nome_Computador = _nome_computador.Insert(_nome_computador.Length, "'").Insert(0, "'");
                    Conexao.IP_Computador = _ip_computador.Insert(_ip_computador.Length, "'").Insert(0, "'");
                    Conexao.Servidor = 1;
                }
            }
        }
    }
}
