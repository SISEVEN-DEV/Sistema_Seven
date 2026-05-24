using DAL;
using Newtonsoft.Json;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace BLL
{
    public class bllVersao
    {
        private static string host = "72.62.97.174";
        private static string username = "root";
        private static string password = "7sissuporte10@Deusestanobarco";

        public static bool VerificarAtualizacoesIBPT()
        {
            using (var client = new SshClient(host, username, password))
            {
                using (Con7BD con = new Con7BD())
                {
                    using (Versao Ver = new Versao())
                    {
                        client.Connect();
                        //
                        bool retorno;
                        string nome_servidor;
                        string nome_local;
                        //
                        if (con.Sel_Versao_Todos() != null)
                        {
                            DataRow dr = con.Sel_Versao_Todos().Rows[0];
                            //
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/02_ibpt/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            nome_local = dr["ibpt"].ToString();
                            //
                            if (nome_servidor == "")
                            {
                                retorno = false;
                            }
                            else
                            {
                                if (nome_local != nome_servidor)
                                {
                                    retorno = true;
                                }
                                else
                                {
                                    retorno = false;
                                }
                            }
                        }
                        else
                        {
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/02_ibpt/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            if (nome_servidor == "")
                            {
                                retorno = false;
                            }
                            else
                            {
                                retorno = true;
                            }
                        }
                        //
                        client.Disconnect();
                        //
                        return retorno;
                    }
                }
            }
        }
        
        public static bool VerificarAtualizacoesACBR_Lib()
        {
            using (var client = new SshClient(host, username, password))
            {
                using (ConOperationBD con = new ConOperationBD())
                {
                    using (Versao Ver = new Versao())
                    {
                        client.Connect();
                        //
                        bool retorno;
                        string nome_servidor;
                        string nome_local;
                        //
                        if (con.Sel_Versao_Todos() != null)
                        {
                            DataRow dr = con.Sel_Versao_Todos().Rows[0];
                            //
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/11_acbr_lib/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            nome_local = dr["acbr_lib"].ToString();
                            //
                            if (nome_servidor == "")
                            {
                                retorno = false;
                            }
                            else
                            {
                                if (nome_local != nome_servidor)
                                {
                                    retorno = true;
                                }
                                else
                                {
                                    retorno = false;
                                }
                            }
                        }
                        else
                        {
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/11_acbr_lib/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            if (nome_servidor == "")
                            {
                                retorno = false;
                            }
                            else
                            {
                                retorno = true;
                            }
                        }
                        //
                        client.Disconnect();
                        //
                        return retorno;
                    }
                }
            }
        }

        public static bool VerificarAtualizacoesConfig()
        {
            using (var client = new SshClient(host, username, password))
            {
                using (ConOperationBD con = new ConOperationBD())
                {
                    using (Versao Ver = new Versao())
                    {
                        client.Connect();
                        //
                        bool retorno;
                        string nome_servidor;
                        string nome_local;
                        //
                        if (con.Sel_Versao_Todos() != null)
                        {
                            DataRow dr = con.Sel_Versao_Todos().Rows[0];
                            //
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/12_config/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            nome_local = dr["config"].ToString();
                            //
                            if (nome_servidor == "")
                            {
                                retorno = false;
                            }
                            else
                            {
                                if (nome_local != nome_servidor)
                                {
                                    retorno = true;
                                }
                                else
                                {
                                    retorno = false;
                                }
                            }
                        }
                        else
                        {
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/12_config/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            if (nome_servidor == "")
                            {
                                retorno = false;
                            }
                            else
                            {
                                retorno = true;
                            }
                        }
                        //
                        client.Disconnect();
                        //
                        return retorno;
                    }
                }
            }
        }

        public static bool VerificarAtualizacoesSistemaSeven()
        {
            using (var client = new SshClient(host, username, password))
            {
                using (ConOperationBD con = new ConOperationBD())
                {
                    using (Versao Ver = new Versao())
                    {
                        client.Connect();
                        //
                        bool retorno;
                        string nome_servidor;
                        string nome_local;
                        //
                        if (con.Sel_Versao_Todos() != null)
                        {
                            DataRow dr = con.Sel_Versao_Todos().Rows[0];
                            //
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/13_sistema_seven/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            nome_local = dr["sistema_seven"].ToString();
                            //
                            if (nome_servidor == "")
                            {
                                retorno = false;
                            }
                            else
                            {
                                if (nome_local != nome_servidor)
                                {
                                    retorno = true;
                                }
                                else
                                {
                                    retorno = false;
                                }
                            }
                        }
                        else
                        {
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/13_sistema_seven/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            if (nome_servidor == "")
                            {
                                retorno = false;
                            }
                            else
                            {
                                retorno = true;
                            }
                        }
                        //
                        client.Disconnect();
                        //
                        return retorno;
                    }
                }
            }
        }

        public static bool VerificarAtualizacoesSeven_Adm()
        {
            using (var client = new SshClient(host, username, password))
            {
                using (ConOperationBD con = new ConOperationBD())
                {
                    using (Versao Ver = new Versao())
                    {
                        client.Connect();
                        //
                        bool retorno;
                        string nome_servidor;
                        string nome_local;
                        //
                        if (con.Sel_Versao_Todos() != null)
                        {
                            DataRow dr = con.Sel_Versao_Todos().Rows[0];
                            //
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/04_seven_adm/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            nome_local = dr["seven_adm"].ToString();
                            //
                            if (nome_servidor == "")
                            {
                                retorno = false;
                            }
                            else
                            {
                                if (nome_local != nome_servidor)
                                {
                                    retorno = true;
                                }
                                else
                                {
                                    retorno = false;
                                }
                            }
                        }
                        else
                        {
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/04_seven_adm/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            if (nome_servidor == "")
                            {
                                retorno = false;
                            }
                            else
                            {
                                retorno = true;
                            }
                        }
                        //
                        client.Disconnect();
                        //
                        return retorno;
                    }
                }
            }
        }

        public static bool VerificarAtualizacoesSeven_Pdv()
        {
            using (var client = new SshClient(host, username, password))
            {
                using (ConOperationBD con = new ConOperationBD())
                {
                    using (Versao Ver = new Versao())
                    {
                        client.Connect();
                        //
                        bool retorno;
                        string nome_servidor;
                        string nome_local;
                        //
                        if (con.Sel_Versao_Todos() != null)
                        {
                            DataRow dr = con.Sel_Versao_Todos().Rows[0];
                            //
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/05_seven_pdv/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            nome_local = dr["seven_pdv"].ToString();
                            //
                            if (nome_servidor == "")
                            {
                                retorno = false;
                            }
                            else
                            {
                                if (nome_local != nome_servidor)
                                {
                                    retorno = true;
                                }
                                else
                                {
                                    retorno = false;
                                }
                            }
                        }
                        else
                        {
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/05_seven_pdv/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            if (nome_servidor == "")
                            {
                                retorno = false;
                            }
                            else
                            {
                                retorno = true;
                            }
                        }
                        //
                        client.Disconnect();
                        //
                        return retorno;
                    }
                }
            }
        }

        public static bool VerificarAtualizacoesBLL()
        {
            using (var client = new SshClient(host, username, password))
            {
                using (ConOperationBD con = new ConOperationBD())
                {
                    using (Versao Ver = new Versao())
                    {
                        client.Connect();
                        //
                        bool retorno;
                        string nome_servidor;
                        string nome_local;
                        //
                        if (con.Sel_Versao_Todos() != null)
                        {
                            DataRow dr = con.Sel_Versao_Todos().Rows[0];
                            //
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/06_bll/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            nome_local = dr["bll"].ToString();
                            //
                            if (nome_servidor == "")
                            {
                                retorno = false;
                            }
                            else
                            {
                                if (nome_local != nome_servidor)
                                {
                                    retorno = true;
                                }
                                else
                                {
                                    retorno = false;
                                }
                            }
                        }
                        else
                        {
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/06_bll/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            if (nome_servidor == "")
                            {
                                retorno = false;
                            }
                            else
                            {
                                retorno = true;
                            }
                        }
                        //
                        client.Disconnect();
                        //
                        return retorno;
                    }
                }
            }
        }

        public static bool VerificarAtualizacoesDAL()
        {
            using (var client = new SshClient(host, username, password))
            {
                using (ConOperationBD con = new ConOperationBD())
                {
                    using (Versao Ver = new Versao())
                    {
                        client.Connect();
                        //
                        bool retorno;
                        string nome_servidor;
                        string nome_local;
                        //
                        if (con.Sel_Versao_Todos() != null)
                        {
                            DataRow dr = con.Sel_Versao_Todos().Rows[0];
                            //
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/07_dal/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            nome_local = dr["dal"].ToString();
                            //
                            if (nome_servidor == "")
                            {
                                retorno = false;
                            }
                            else
                            {
                                if (nome_local != nome_servidor)
                                {
                                    retorno = true;
                                }
                                else
                                {
                                    retorno = false;
                                }
                            }
                        }
                        else
                        {
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/07_dal/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            if (nome_servidor == "")
                            {
                                retorno = false;
                            }
                            else
                            {
                                retorno = true;
                            }
                        }
                        //
                        client.Disconnect();
                        //
                        return retorno;
                    }
                }
            }
        }

        public static bool VerificarAtualizacoesSeven_Config()
        {
            using (var client = new SshClient(host, username, password))
            {
                using (ConOperationBD con = new ConOperationBD())
                {
                    using (Versao Ver = new Versao())
                    {
                        client.Connect();
                        //
                        bool retorno;
                        string nome_servidor;
                        string nome_local;
                        //
                        if (con.Sel_Versao_Todos() != null)
                        {
                            DataRow dr = con.Sel_Versao_Todos().Rows[0];
                            //
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/08_seven_config/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            nome_local = dr["seven_config"].ToString();
                            //
                            if (nome_servidor == "")
                            {
                                retorno = false;
                            }
                            else
                            {
                                if (nome_local != nome_servidor)
                                {
                                    retorno = true;
                                }
                                else
                                {
                                    retorno = false;
                                }
                            }
                        }
                        else
                        {
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/08_seven_config/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            if (nome_servidor == "")
                            {
                                retorno = false;
                            }
                            else
                            {
                                retorno = true;
                            }
                        }
                        //
                        client.Disconnect();
                        //
                        return retorno;
                    }
                }
            }
        }

        public static bool VerificarAtualizacoesSQLSeven()
        {
            using (var client = new SshClient(host, username, password))
            {
                using (Con7BD con = new Con7BD())
                {
                    using (Versao Ver = new Versao())
                    {
                        client.Connect();
                        //
                        bool retorno = false;
                        string nome_servidor;
                        string nome_local;
                        //
                        if (con.Sel_Versao_Todos() != null)
                        {
                            DataRow dr = con.Sel_Versao_Todos().Rows[0];
                            //
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/03_sql/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            nome_local = dr["sql"].ToString();
                            //
                            if (nome_servidor == "")
                            {
                                retorno = false;
                            }
                            else
                            {
                                if (nome_local != "")
                                {
                                    if (nome_local != nome_servidor)
                                    {
                                        retorno = true;
                                    }
                                    else
                                    {
                                        retorno = false;
                                    }
                                }
                                else
                                {
                                    retorno = true;
                                }
                            }
                        }
                        else
                        {
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/03_sql/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            if (nome_servidor == "")
                            {
                                retorno = false;
                            }
                            else
                            {
                                retorno = true;
                            }
                        }
                        //
                        client.Disconnect();
                        //
                        return retorno;
                    }
                }
            }
        }

        public static bool VerificarAtualizacoesSQLOperation()
        {
            using (var client = new SshClient(host, username, password))
            {
                using (ConOperationBD con = new ConOperationBD())
                {
                    using (Versao Ver = new Versao())
                    {
                        client.Connect();
                        //
                        bool retorno = false;
                        string nome_servidor;
                        string nome_local;
                        //
                        if (con.Sel_Versao_Todos() != null)
                        {
                            DataRow dr = con.Sel_Versao_Todos().Rows[0];
                            //
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/09_sql_operation/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", ""); ;
                            //
                            nome_local = dr["sql"].ToString();
                            //
                            if (nome_servidor == "")
                            {
                                retorno = false;
                            }
                            else
                            {
                                if (nome_local != "")
                                {
                                    if (nome_local != nome_servidor)
                                    {
                                        retorno = true;
                                    }
                                    else
                                    {
                                        retorno = false;
                                    }
                                }
                                else
                                {
                                    retorno = true;
                                }
                            }
                        }
                        else
                        {
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/09_sql_operation/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            if (nome_servidor == "")
                            {
                                retorno = false;
                            }
                            else
                            {
                                retorno = true;
                            }
                        }
                        //
                        client.Disconnect();
                        //
                        return retorno;
                    }
                }
            }
        }

        public static bool VerificarAtualizacoesSQL_CPF_CNPJ()
        {
            using (var client = new SshClient(host, username, password))
            {
                using (Con7BD con = new Con7BD())
                {
                    using (Versao Ver = new Versao())
                    {
                        client.Connect();
                        //
                        bool retorno = false;
                        string nome_servidor;
                        string nome_local;
                        //
                        if (bllMinhaEmpresa.Sel_Empresa_CPFCNPJ() != null)
                        {
                            if (con.Sel_Versao_Todos() != null)
                            {
                                DataRow dr = con.Sel_Versao_Todos().Rows[0];
                                //
                                var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/10_sql_cpf_cnpj/" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", ""));
                                //
                                nome_servidor = cmd.Result.Replace("\n", ""); ;
                                //
                                nome_local = dr["sql_cpf_cnpj"].ToString();
                                //
                                if (nome_servidor == "")
                                {
                                    retorno = false;
                                }
                                else
                                {
                                    if (nome_local != "")
                                    {
                                        if (nome_local != nome_servidor)
                                        {
                                            retorno = true;
                                        }
                                        else
                                        {
                                            retorno = false;
                                        }
                                    }
                                    else
                                    {
                                        retorno = true;
                                    }
                                }
                            }
                            else
                            {
                                var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/10_sql_cpf_cnpj/");
                                //
                                nome_servidor = cmd.Result.Replace("\n", "");
                                //
                                if (nome_servidor == "")
                                {
                                    retorno = false;
                                }
                                else
                                {
                                    retorno = true;
                                }
                            }
                        }
                        else
                        {
                            retorno = false;
                        }
                        //
                        client.Disconnect();
                        //
                        return retorno;
                    }
                }
            }
        }

        public static void BaixarDetalheAtualizacao()
        {
            using (var client = new ScpClient(host, username, password))
            {
                client.Connect();
                //
                if (client.IsConnected)
                {
                    using (var filestream = System.IO.File.Create(@"C:\Sistema SEVEN\Config\detalhe_atualizacao.txt"))
                    {
                        client.Download("/sistema_seven/atualizacao/01_detalhe/detalhe.txt", filestream);
                    }
                }
                //
                client.Disconnect();
            }
        }

        public static void BaixarAtualizacoesIBPT()
        {
            using (var client = new SshClient(host, username, password))
            {
                using (var scpclient = new ScpClient(host, username, password))
                {
                    using (Con7BD con = new Con7BD())
                    {
                        using (Versao Ver = new Versao())
                        {
                            client.Connect();
                            //
                            string nome_servidor;
                            string nome_local;
                            string diretorio = @"C:\Sistema SEVEN\Config\Recebidos\ibpt";
                            //
                            if (!Directory.Exists(diretorio))
                            {
                                Directory.CreateDirectory(diretorio);
                            }
                            //
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/02_ibpt/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            if (con.Sel_Versao_Todos() != null)
                            {
                                DataRow dr = con.Sel_Versao_Todos().Rows[0];
                                //
                                nome_local = dr["ibpt"].ToString();
                                //
                                if (nome_local != nome_servidor)
                                {
                                    scpclient.Connect();
                                    //
                                    if (scpclient.IsConnected)
                                    {
                                        if (File.Exists(diretorio + @"\" + nome_servidor))
                                        {
                                            File.Delete(diretorio + @"\" + nome_servidor);
                                        }
                                        //
                                        using (var filestream = System.IO.File.Create(diretorio + @"\" + nome_servidor))
                                        {
                                            scpclient.Download("/sistema_seven/atualizacao/02_ibpt/" + nome_servidor, filestream);
                                        }
                                    }
                                    //
                                    scpclient.Disconnect();
                                    //
                                    con.Limpar_Tabela_IBPT_Versao();
                                    //
                                    Executar_Tabela_IBPT(diretorio + @"\" + nome_servidor);
                                    //
                                    Ver.IBPT = nome_servidor;
                                    con.Alterar_Versao_IBPT(Ver);
                                }
                            }
                            else
                            {
                                scpclient.Connect();
                                //
                                if (scpclient.IsConnected)
                                {
                                    if (File.Exists(diretorio + @"\" + nome_servidor))
                                    {
                                        File.Delete(diretorio + @"\" + nome_servidor);
                                    }
                                    //
                                    using (var filestream = System.IO.File.Create(diretorio + @"\" + nome_servidor))
                                    {
                                        scpclient.Download("/sistema_seven/atualizacao/02_ibpt/" + nome_servidor, filestream);
                                    }
                                }
                                //
                                scpclient.Disconnect();
                                //
                                con.Limpar_Tabela_IBPT_Versao();
                                //
                                Executar_Tabela_IBPT(diretorio + @"\" + nome_servidor);
                                //
                                Ver.IBPT = nome_servidor;
                                con.Salvar_Versao_IBPT(Ver);
                            }
                            //
                            client.Disconnect();
                        }
                    }
                }
            }
        }

        public static void BaixarAtualizacoesSeven_Adm()
        {
            using (var client = new SshClient(host, username, password))
            {
                using (var scpclient = new ScpClient(host, username, password))
                {
                    using (ConOperationBD con = new ConOperationBD())
                    {
                        using (Versao Ver = new Versao())
                        {
                            client.Connect();
                            //
                            string nome_servidor;
                            string nome_local;
                            string diretorio = @"C:\Sistema SEVEN\Config\Recebidos\seven_adm";
                            //
                            if (!Directory.Exists(diretorio))
                            {
                                Directory.CreateDirectory(diretorio);
                            }
                            //
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/04_seven_adm/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            if (con.Sel_Versao_Todos() != null)
                            {
                                DataRow dr = con.Sel_Versao_Todos().Rows[0];
                                //
                                nome_local = dr["seven_adm"].ToString();
                                //
                                if (nome_local != nome_servidor)
                                {
                                    scpclient.Connect();
                                    //
                                    if (scpclient.IsConnected)
                                    {
                                        if (File.Exists(diretorio + @"\" + nome_servidor))
                                        {
                                            File.Delete(diretorio + @"\" + nome_servidor);
                                        }
                                        //
                                        using (var filestream = System.IO.File.Create(diretorio + @"\" + nome_servidor))
                                        {
                                            scpclient.Download("/sistema_seven/atualizacao/04_seven_adm/" + nome_servidor, filestream);
                                        }
                                    }
                                    //
                                    scpclient.Disconnect();
                                    //
                                    SubstituirSeven_Adm(nome_servidor);
                                    //
                                    Ver.Seven_ADM = nome_servidor;
                                    con.Alterar_Versao_Seven_ADM(Ver);
                                }
                            }
                            else
                            {
                                scpclient.Connect();
                                //
                                if (scpclient.IsConnected)
                                {
                                    if (File.Exists(diretorio + @"\" + nome_servidor))
                                    {
                                        File.Delete(diretorio + @"\" + nome_servidor);
                                    }
                                    //
                                    using (var filestream = System.IO.File.Create(diretorio + @"\" + nome_servidor))
                                    {
                                        scpclient.Download("/sistema_seven/atualizacao/04_seven_adm/" + nome_servidor, filestream);
                                    }
                                }
                                //
                                scpclient.Disconnect();
                                //
                                SubstituirSeven_Adm(nome_servidor);
                                //
                                Ver.Seven_ADM = nome_servidor;
                                con.Salvar_Versao_Seven_ADM(Ver);
                            }
                            //
                            client.Disconnect();
                        }
                    }
                }
            }
        }

        public static void BaixarAtualizacoesSeven_Config()
        {
            using (var client = new SshClient(host, username, password))
            {
                using (var scpclient = new ScpClient(host, username, password))
                {
                    using (ConOperationBD con = new ConOperationBD())
                    {
                        using (Versao Ver = new Versao())
                        {
                            client.Connect();
                            //
                            string nome_servidor;
                            string nome_local;
                            string diretorio = @"C:\Sistema SEVEN\Config\Recebidos\seven_config";
                            //
                            if (!Directory.Exists(diretorio))
                            {
                                Directory.CreateDirectory(diretorio);
                            }
                            //
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/08_seven_config/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            if (con.Sel_Versao_Todos() != null)
                            {
                                DataRow dr = con.Sel_Versao_Todos().Rows[0];
                                //
                                nome_local = dr["seven_config"].ToString();
                                //
                                if (nome_local != nome_servidor)
                                {
                                    scpclient.Connect();
                                    //
                                    if (scpclient.IsConnected)
                                    {
                                        if (File.Exists(diretorio + @"\" + nome_servidor))
                                        {
                                            File.Delete(diretorio + @"\" + nome_servidor);
                                        }
                                        //
                                        using (var filestream = System.IO.File.Create(diretorio + @"\" + nome_servidor))
                                        {
                                            scpclient.Download("/sistema_seven/atualizacao/08_seven_config/" + nome_servidor, filestream);
                                        }
                                    }
                                    //
                                    scpclient.Disconnect();
                                    //
                                    SubstituirSeven_Config(nome_servidor);
                                    //
                                    Ver.Seven_Config = nome_servidor;
                                    con.Alterar_Versao_Seven_Config(Ver);
                                }
                            }
                            else
                            {
                                scpclient.Connect();
                                //
                                if (scpclient.IsConnected)
                                {
                                    if (File.Exists(diretorio + @"\" + nome_servidor))
                                    {
                                        File.Delete(diretorio + @"\" + nome_servidor);
                                    }
                                    //
                                    using (var filestream = System.IO.File.Create(diretorio + @"\" + nome_servidor))
                                    {
                                        scpclient.Download("/sistema_seven/atualizacao/08_seven_config/" + nome_servidor, filestream);
                                    }
                                }
                                //
                                scpclient.Disconnect();
                                //
                                SubstituirSeven_Config(nome_servidor);
                                //
                                Ver.Seven_Config = nome_servidor;
                                con.Salvar_Versao_Seven_Config(Ver);
                            }
                            //
                            client.Disconnect();
                        }
                    }
                }
            }
        }

        public static void BaixarAtualizacoes_ACBR_Lib()
        {
            using (var client = new SshClient(host, username, password))
            {
                using (var sftpclient = new SftpClient(host, username, password))
                {
                    using (ConOperationBD con = new ConOperationBD())
                    {
                        using (Versao Ver = new Versao())
                        {
                            client.Connect();
                            //
                            string nome_servidor;
                            string nome_local;
                            string diretorio = @"C:\Sistema SEVEN\Config\Recebidos\acbr_lib";
                            //
                            if (!Directory.Exists(diretorio))
                            {
                                Directory.CreateDirectory(diretorio);
                            }
                            else
                            {
                                Directory.Delete(diretorio, true);
                            }
                            //
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/11_acbr_lib/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            if (con.Sel_Versao_Todos() != null)
                            {
                                DataRow dr = con.Sel_Versao_Todos().Rows[0];
                                //
                                nome_local = dr["acbr_lib"].ToString();
                                //
                                if (nome_local != nome_servidor)
                                {
                                    sftpclient.Connect();
                                    //
                                    BaixarDiretorio(sftpclient, @"/sistema_seven/atualizacao/11_acbr_lib/", diretorio);
                                    //
                                    sftpclient.Disconnect();
                                    //
                                    Substituir_ACBR_LIB(diretorio + @"\" + nome_servidor);
                                    //
                                    Ver.ACBR_LIB = nome_servidor;
                                    con.Alterar_Versao_ACBR_lib(Ver);
                                }
                            }
                            else
                            {
                                sftpclient.Connect();
                                //
                                BaixarDiretorio(sftpclient, @"/sistema_seven/atualizacao/11_acbr_lib/", diretorio);
                                //
                                sftpclient.Disconnect();
                                //
                                Substituir_ACBR_LIB(diretorio + @"\" + nome_servidor);
                                //
                                Ver.ACBR_LIB = nome_servidor;
                                con.Salvar_Versao_ACBR_Lib(Ver);
                            }
                            //
                            client.Disconnect();
                        }
                    }
                }
            }
        }

        public static void BaixarAtualizacoes_Sistema_Seven()
        {
            using (var client = new SshClient(host, username, password))
            {
                using (var sftpclient = new SftpClient(host, username, password))
                {
                    using (ConOperationBD con = new ConOperationBD())
                    {
                        using (Versao Ver = new Versao())
                        {
                            client.Connect();
                            //
                            string nome_servidor;
                            string nome_local;
                            string diretorio = @"C:\Sistema SEVEN\Config\Recebidos\sistema_seven";
                            //
                            if (!Directory.Exists(diretorio))
                            {
                                Directory.CreateDirectory(diretorio);
                            }
                            else
                            {
                                Directory.Delete(diretorio, true);
                            }
                            //
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/13_sistema_seven/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            if (con.Sel_Versao_Todos() != null)
                            {
                                DataRow dr = con.Sel_Versao_Todos().Rows[0];
                                //
                                nome_local = dr["sistema_seven"].ToString();
                                //
                                if (nome_local != nome_servidor)
                                {
                                    sftpclient.Connect();
                                    //
                                    BaixarDiretorio(sftpclient, @"/sistema_seven/atualizacao/13_sistema_seven/", diretorio);
                                    //
                                    sftpclient.Disconnect();
                                    //
                                    Substituir_Sistema_Seven(diretorio + @"\" + nome_servidor);
                                    //
                                    Ver.Sistema_Seven = nome_servidor;
                                    con.Alterar_Versao_Sistema_Seven(Ver);
                                }
                            }
                            else
                            {
                                sftpclient.Connect();
                                //
                                BaixarDiretorio(sftpclient, @"/sistema_seven/atualizacao/13_sistema_seven/", diretorio);
                                //
                                sftpclient.Disconnect();
                                //
                                Substituir_Sistema_Seven(diretorio + @"\" + nome_servidor);
                                //
                                Ver.Sistema_Seven = nome_servidor;
                                con.Salvar_Versao_Sistema_Seven(Ver);
                            }
                            //
                            client.Disconnect();
                        }
                    }
                }
            }
        }

        public static void BaixarAtualizacoes_Config()
        {
            using (var client = new SshClient(host, username, password))
            {
                using (var sftpclient = new SftpClient(host, username, password))
                {
                    using (ConOperationBD con = new ConOperationBD())
                    {
                        using (Versao Ver = new Versao())
                        {
                            client.Connect();
                            //
                            string nome_servidor;
                            string nome_local;
                            string diretorio = @"C:\Sistema SEVEN\Config\Recebidos\config";
                            //
                            if (!Directory.Exists(diretorio))
                            {
                                Directory.CreateDirectory(diretorio);
                            }
                            else
                            {
                                Directory.Delete(diretorio, true);
                            }
                            //
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/12_config/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            if (con.Sel_Versao_Todos() != null)
                            {
                                DataRow dr = con.Sel_Versao_Todos().Rows[0];
                                //
                                nome_local = dr["config"].ToString();
                                //
                                if (nome_local != nome_servidor)
                                {
                                    sftpclient.Connect();
                                    //
                                    BaixarDiretorio(sftpclient, @"/sistema_seven/atualizacao/12_config/", diretorio);
                                    //
                                    sftpclient.Disconnect();
                                    //
                                    Substituir_Config(diretorio + @"\" + nome_servidor);
                                    //
                                    Ver.Config = nome_servidor;
                                    con.Alterar_Versao_Config(Ver);
                                }
                            }
                            else
                            {
                                sftpclient.Connect();
                                //
                                BaixarDiretorio(sftpclient, @"/sistema_seven/atualizacao/12_config/", diretorio);
                                //
                                sftpclient.Disconnect();
                                //
                                Substituir_Config(diretorio + @"\" + nome_servidor);
                                //
                                Ver.Config = nome_servidor;
                                con.Salvar_Versao_Config(Ver);
                            }
                            //
                            client.Disconnect();
                        }
                    }
                }
            }
        }

        static void BaixarDiretorio(SftpClient client, string pastaservidor, string destino)
        {
            Directory.CreateDirectory(destino);

            var files = client.ListDirectory(pastaservidor);
            foreach (var file in files)
            {
                if (file.Name == "." || file.Name == "..")
                    continue;

                string nomelocaldiretorio = Path.Combine(destino, file.Name);
                string nomeservidordiretorio = file.FullName;

                if (file.IsDirectory)
                {
                    BaixarDiretorio(client, nomeservidordiretorio, nomelocaldiretorio);
                }
                else
                {
                    using (var fs = File.OpenWrite(nomelocaldiretorio))
                    {
                        client.DownloadFile(nomeservidordiretorio, fs);
                    }
                }
            }
        }

        public static void BaixarAtualizacoesDAL()
        {
            using (var client = new SshClient(host, username, password))
            {
                using (var scpclient = new ScpClient(host, username, password))
                {
                    using (ConOperationBD con = new ConOperationBD())
                    {
                        using (Versao Ver = new Versao())
                        {
                            client.Connect();
                            //
                            string nome_servidor;
                            string nome_local;
                            string diretorio = @"C:\Sistema SEVEN\Config\Recebidos\dal";
                            //
                            if (!Directory.Exists(diretorio))
                            {
                                Directory.CreateDirectory(diretorio);
                            }
                            //
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/07_dal/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            if (con.Sel_Versao_Todos() != null)
                            {
                                DataRow dr = con.Sel_Versao_Todos().Rows[0];
                                //
                                nome_local = dr["dal"].ToString();
                                //
                                if (nome_local != nome_servidor)
                                {
                                    scpclient.Connect();
                                    //
                                    if (scpclient.IsConnected)
                                    {
                                        if (File.Exists(diretorio + @"\" + nome_servidor))
                                        {
                                            File.Delete(diretorio + @"\" + nome_servidor);
                                        }
                                        //
                                        using (var filestream = System.IO.File.Create(diretorio + @"\" + nome_servidor))
                                        {
                                            scpclient.Download("/sistema_seven/atualizacao/07_dal/" + nome_servidor, filestream);
                                        }
                                    }
                                    //
                                    scpclient.Disconnect();
                                    //
                                    SubstituirDAL(nome_servidor);
                                    //
                                    Ver.DAL = nome_servidor;
                                    con.Alterar_Versao_DAL(Ver);
                                }
                            }
                            else
                            {
                                scpclient.Connect();
                                //
                                if (scpclient.IsConnected)
                                {
                                    if (File.Exists(diretorio + @"\" + nome_servidor))
                                    {
                                        File.Delete(diretorio + @"\" + nome_servidor);
                                    }
                                    //
                                    using (var filestream = System.IO.File.Create(diretorio + @"\" + nome_servidor))
                                    {
                                        scpclient.Download("/sistema_seven/atualizacao/07_dal/" + nome_servidor, filestream);
                                    }
                                }
                                //
                                scpclient.Disconnect();
                                //
                                SubstituirDAL(nome_servidor);
                                //
                                Ver.DAL = nome_servidor;
                                con.Salvar_Versao_DAL(Ver);
                            }
                            //
                            client.Disconnect();
                        }
                    }
                }
            }
        }

        public static void BaixarAtualizacoesBLL()
        {
            using (var client = new SshClient(host, username, password))
            {
                using (var scpclient = new ScpClient(host, username, password))
                {
                    using (ConOperationBD con = new ConOperationBD())
                    {
                        using (Versao Ver = new Versao())
                        {
                            client.Connect();
                            //
                            string nome_servidor;
                            string nome_local;
                            string diretorio = @"C:\Sistema SEVEN\Config\Recebidos\bll";
                            //
                            if (!Directory.Exists(diretorio))
                            {
                                Directory.CreateDirectory(diretorio);
                            }
                            //
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/06_bll/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            if (con.Sel_Versao_Todos() != null)
                            {
                                DataRow dr = con.Sel_Versao_Todos().Rows[0];
                                //
                                nome_local = dr["bll"].ToString();
                                //
                                if (nome_local != nome_servidor)
                                {
                                    scpclient.Connect();
                                    //
                                    if (scpclient.IsConnected)
                                    {
                                        if (File.Exists(diretorio + @"\" + nome_servidor))
                                        {
                                            File.Delete(diretorio + @"\" + nome_servidor);
                                        }
                                        //
                                        using (var filestream = System.IO.File.Create(diretorio + @"\" + nome_servidor))
                                        {
                                            scpclient.Download("/sistema_seven/atualizacao/06_bll/" + nome_servidor, filestream);
                                        }
                                    }
                                    //
                                    scpclient.Disconnect();
                                    //
                                    SubstituirBLL(nome_servidor);
                                    //
                                    Ver.BLL = nome_servidor;
                                    con.Alterar_Versao_BLL(Ver);
                                }
                            }
                            else
                            {
                                scpclient.Connect();
                                //
                                if (scpclient.IsConnected)
                                {
                                    if (File.Exists(diretorio + @"\" + nome_servidor))
                                    {
                                        File.Delete(diretorio + @"\" + nome_servidor);
                                    }
                                    //
                                    using (var filestream = System.IO.File.Create(diretorio + @"\" + nome_servidor))
                                    {
                                        scpclient.Download("/sistema_seven/atualizacao/06_bll/" + nome_servidor, filestream);
                                    }
                                }
                                //
                                scpclient.Disconnect();
                                //
                                SubstituirBLL(nome_servidor);
                                //
                                Ver.BLL = nome_servidor;
                                con.Salvar_Versao_BLL(Ver);
                            }
                            //
                            client.Disconnect();
                        }
                    }
                }
            }
        }
     
        public static void BaixarAtualizacoesSeven_Pdv()
        {
            using (var client = new SshClient(host, username, password))
            {
                using (var scpclient = new ScpClient(host, username, password))
                {
                    using (ConOperationBD con = new ConOperationBD())
                    {
                        using (Versao Ver = new Versao())
                        {
                            client.Connect();
                            //
                            string nome_servidor;
                            string nome_local;
                            string diretorio = @"C:\Sistema SEVEN\Config\Recebidos\seven_pdv";
                            //
                            if (!Directory.Exists(diretorio))
                            {
                                Directory.CreateDirectory(diretorio);
                            }
                            //
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/05_seven_pdv/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            if (con.Sel_Versao_Todos() != null)
                            {
                                DataRow dr = con.Sel_Versao_Todos().Rows[0];
                                //
                                nome_local = dr["seven_pdv"].ToString();
                                //
                                if (nome_local != nome_servidor)
                                {
                                    scpclient.Connect();
                                    //
                                    if (scpclient.IsConnected)
                                    {
                                        if (File.Exists(diretorio + @"\" + nome_servidor))
                                        {
                                            File.Delete(diretorio + @"\" + nome_servidor);
                                        }
                                        //
                                        using (var filestream = System.IO.File.Create(diretorio + @"\" + nome_servidor))
                                        {
                                            scpclient.Download("/sistema_seven/atualizacao/05_seven_pdv/" + nome_servidor, filestream);
                                        }
                                    }
                                    //
                                    scpclient.Disconnect();
                                    //
                                    SubstituirSeven_Pdv(nome_servidor);
                                    //
                                    Ver.Seven_PDV = nome_servidor;
                                    con.Alterar_Versao_Seven_PDV(Ver);
                                }
                            }
                            else
                            {
                                scpclient.Connect();
                                //
                                if (scpclient.IsConnected)
                                {
                                    if (File.Exists(diretorio + @"\" + nome_servidor))
                                    {
                                        File.Delete(diretorio + @"\" + nome_servidor);
                                    }
                                    //
                                    using (var filestream = System.IO.File.Create(diretorio + @"\" + nome_servidor))
                                    {
                                        scpclient.Download("/sistema_seven/atualizacao/05_seven_pdv/" + nome_servidor, filestream);
                                    }
                                }
                                //
                                scpclient.Disconnect();
                                //
                                SubstituirSeven_Pdv(nome_servidor);
                                //
                                Ver.Seven_PDV = nome_servidor;
                                con.Salvar_Versao_Seven_PDV(Ver);
                            }
                            //
                            client.Disconnect();
                        }
                    }
                }
            }
        }

      

        public static void BaixarAtualizacoesSQLSeven()
        {
            using (var client = new SshClient(host, username, password))
            {
                using (var scpclient = new ScpClient(host, username, password))
                {
                    using (Con7BD con = new Con7BD())
                    {
                        using (Versao Ver = new Versao())
                        {
                            client.Connect();
                            //
                            string nome_servidor;
                            string nome_local;
                            string diretorio = @"C:\Sistema SEVEN\Config\Recebidos\sql";
                            //
                            if (!Directory.Exists(diretorio))
                            {
                                Directory.CreateDirectory(diretorio);
                            }
                            //
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/03_sql/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            if (nome_servidor != "")
                            {
                                if (con.Sel_Versao_Todos() != null)
                                {
                                    DataRow dr = con.Sel_Versao_Todos().Rows[0];
                                    //
                                    nome_local = dr["sql"].ToString();
                                    //
                                    scpclient.Connect();
                                    //
                                    if (scpclient.IsConnected)
                                    {
                                        if (File.Exists(diretorio + @"\" + nome_servidor) == true)
                                        {
                                            File.Delete(diretorio + @"\" + nome_servidor);
                                        }
                                        //
                                        using (var filestream = System.IO.File.Create(diretorio + @"\" + nome_servidor))
                                        {
                                            scpclient.Download("/sistema_seven/atualizacao/03_sql/" + nome_servidor, filestream);
                                        }
                                    }
                                    //
                                    Executar_Arquivo_SQLSeven(diretorio + @"\" + nome_servidor);
                                    //
                                    Ver.SQL_Seven = nome_servidor;
                                    //
                                    con.Alterar_Versao_SQL(Ver);
                                    //
                                    scpclient.Disconnect();
                                }
                                else
                                {
                                    scpclient.Connect();
                                    //
                                    if (scpclient.IsConnected)
                                    {
                                        if (File.Exists(diretorio + @"\" + nome_servidor) == true)
                                        {
                                            File.Delete(diretorio + @"\" + nome_servidor);
                                        }
                                        //
                                        using (var filestream = System.IO.File.Create(diretorio + @"\" + nome_servidor))
                                        {
                                            scpclient.Download("/sistema_seven/atualizacao/03_sql/" + nome_servidor, filestream);
                                        }
                                    }
                                    //
                                    Executar_Arquivo_SQLSeven(diretorio + @"\" + nome_servidor);
                                    //
                                    Ver.SQL_Seven = nome_servidor;
                                    con.Salvar_Versao_SQL(Ver);
                                    //
                                    scpclient.Disconnect();
                                }
                                //
                                client.Disconnect();
                            }
                        }
                    }
                }
            }
        }

        public static void BaixarAtualizacoesSQL_CPF_CNPJ()
        {
            using (var client = new SshClient(host, username, password))
            {
                using (var scpclient = new ScpClient(host, username, password))
                {
                    using (Con7BD con = new Con7BD())
                    {
                        using (Versao Ver = new Versao())
                        {
                            client.Connect();
                            //
                            string nome_servidor;
                            string nome_local;
                            string diretorio = @"C:\Sistema SEVEN\Config\Recebidos\sql_cpf_cnpj";
                            //
                            if (!Directory.Exists(diretorio))
                            {
                                Directory.CreateDirectory(diretorio);
                            }
                            //
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/10_sql_cpf_cnpj/" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", ""));
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            if (nome_servidor != "")
                            {
                                if (con.Sel_Versao_Todos() != null)
                                {
                                    DataRow dr = con.Sel_Versao_Todos().Rows[0];
                                    //
                                    nome_local = dr["sql_cpf_cnpj"].ToString();
                                    //
                                    scpclient.Connect();
                                    //
                                    if (scpclient.IsConnected)
                                    {
                                        if (File.Exists(diretorio + @"\" + nome_servidor) == true)
                                        {
                                            File.Delete(diretorio + @"\" + nome_servidor);
                                        }
                                        //
                                        using (var filestream = System.IO.File.Create(diretorio + @"\" + nome_servidor))
                                        {
                                            scpclient.Download("/sistema_seven/atualizacao/10_sql_cpf_cnpj/" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", "") + @"/" + nome_servidor, filestream);
                                        }
                                    }
                                    //
                                    Executar_Arquivo_SQL_CPF_CNPJ(diretorio + @"\" + nome_servidor);
                                    //
                                    Ver.SQL_CPF_CNPJ = nome_servidor;
                                    //
                                    con.Alterar_Versao_SQL_CPF_CNPJ(Ver);
                                    //
                                    scpclient.Disconnect();
                                }
                                else
                                {
                                    scpclient.Connect();
                                    //
                                    if (scpclient.IsConnected)
                                    {
                                        if (File.Exists(diretorio + @"\" + nome_servidor) == true)
                                        {
                                            File.Delete(diretorio + @"\" + nome_servidor);
                                        }
                                        //
                                        using (var filestream = System.IO.File.Create(diretorio + @"\" + nome_servidor))
                                        {
                                            scpclient.Download("/sistema_seven/atualizacao/10_sql_cpf_cnpj/" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", "") + @"/" + nome_servidor, filestream);
                                        }
                                    }
                                    //
                                    Executar_Arquivo_SQL_CPF_CNPJ(diretorio + @"\" + nome_servidor);
                                    //
                                    Ver.SQL_CPF_CNPJ = nome_servidor;
                                    con.Salvar_Versao_SQL_CPF_CNPJ(Ver);
                                    //
                                    scpclient.Disconnect();
                                }
                            }
                            //
                            client.Disconnect();
                        }
                    }
                }
            }
        }

        public static void BaixarAtualizacoesSQLOperation()
        {
            using (var client = new SshClient(host, username, password))
            {
                using (var scpclient = new ScpClient(host, username, password))
                {
                    using (ConOperationBD con = new ConOperationBD())
                    {
                        using (Versao Ver = new Versao())
                        {
                            client.Connect();
                            //
                            string nome_servidor;
                            string nome_local;
                            string diretorio = @"C:\Sistema SEVEN\Config\Recebidos\sql_operation";
                            //
                            if (!Directory.Exists(diretorio))
                            {
                                Directory.CreateDirectory(diretorio);
                            }
                            //
                            var cmd = client.RunCommand($"ls -1 /sistema_seven/atualizacao/09_sql_operation/");
                            //
                            nome_servidor = cmd.Result.Replace("\n", "");
                            //
                            if (nome_servidor != "")
                            {
                                if (con.Sel_Versao_Todos() != null)
                                {
                                    DataRow dr = con.Sel_Versao_Todos().Rows[0];
                                    //
                                    nome_local = dr["sql"].ToString();
                                    //
                                    scpclient.Connect();
                                    //
                                    if (scpclient.IsConnected)
                                    {
                                        if (File.Exists(diretorio + @"\" + nome_servidor) == true)
                                        {
                                            File.Delete(diretorio + @"\" + nome_servidor);
                                        }
                                        //
                                        using (var filestream = System.IO.File.Create(diretorio + @"\" + nome_servidor))
                                        {
                                            scpclient.Download("/sistema_seven/atualizacao/09_sql_operation/" + nome_servidor, filestream);
                                        }
                                    }
                                    //
                                    Executar_Arquivo_SQL_Operation(diretorio + @"\" + nome_servidor);
                                    //
                                    Ver.SQL_Operation = nome_servidor;
                                    //
                                    con.Alterar_Versao_SQL(Ver);
                                    //
                                    scpclient.Disconnect();
                                }
                                else
                                {
                                    scpclient.Connect();
                                    //
                                    if (scpclient.IsConnected)
                                    {
                                        if (File.Exists(diretorio + @"\" + nome_servidor) == true)
                                        {
                                            File.Delete(diretorio + @"\" + nome_servidor);
                                        }
                                        //
                                        using (var filestream = System.IO.File.Create(diretorio + @"\" + nome_servidor))
                                        {
                                            scpclient.Download("/sistema_seven/atualizacao/09_sql_operation/" + nome_servidor, filestream);
                                        }
                                    }
                                    //
                                    Executar_Arquivo_SQL_Operation(diretorio + @"\" + nome_servidor);
                                    //
                                    Ver.SQL_Operation = nome_servidor;
                                    con.Salvar_Versao_SQL(Ver);
                                    //
                                    scpclient.Disconnect();
                                }
                                //
                                client.Disconnect();
                            }
                        }
                    }
                }
            }
        }

        public static void Executar_Tabela_IBPT(string nomearquivo)
        {
            using (Con7BD con = new Con7BD())
            {
                if (File.Exists(nomearquivo))
                {
                    string[] linhas = File.ReadAllLines(nomearquivo, Encoding.UTF8);
                    //
                    for (int a = 0; a < linhas.Length; a++)
                    {
                        con.Executar_Tabela_IBPT(linhas[a]);
                    }
                }
            }
        }

        public static void Executar_Arquivo_SQLSeven(string nomearquivo)
        {
            using (Con7BD con = new Con7BD())
            {
                if (File.Exists(nomearquivo))
                {
                    string[] linhas = File.ReadAllLines(nomearquivo, Encoding.UTF7);
                    //
                    List<string> blocoSQL = new List<string>();
                    StringBuilder blocoAtual = new StringBuilder();
                    bool capturando = false;
                    //
                    foreach (string linha in linhas) 
                    {
                        string linhaAtual = linha.Trim();
                        //
                        if (!capturando && (linhaAtual.IndexOf("INSERT", StringComparison.OrdinalIgnoreCase) >= 0 || linhaAtual.IndexOf("CREATE", StringComparison.OrdinalIgnoreCase) >= 0 || linhaAtual.IndexOf("ALTER", StringComparison.OrdinalIgnoreCase) >= 0 || linhaAtual.IndexOf("DELETE", StringComparison.OrdinalIgnoreCase) >= 0 || linhaAtual.IndexOf("UPDATE", StringComparison.OrdinalIgnoreCase) >= 0 || linhaAtual.IndexOf("DROP", StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            capturando = true;
                        }
                        //
                        if (capturando == true)
                        {
                            blocoAtual.AppendLine(linha);

                            if (linhaAtual == ";" || linhaAtual.EndsWith(";"))
                            {
                                string resultado = Regex.Replace(blocoAtual.ToString(), @"\r\n|\r|\n", " ");

                                blocoSQL.Add(resultado.ToString().Trim());
                                blocoAtual.Clear();
                                capturando = false;
                            }
                        }
                    }
                    //
                    for (int i = 0; i < blocoSQL.Count; i++)
                    {
                        try
                        {
                            con.Executar_Arquivo_SQL(blocoSQL[i].Replace("\n", "").Replace("\r", ""));
                        }
                        catch (Exception ex) 
                        {
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Método Executar_Arquivo_SQLSeven.");
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Método Executar_Arquivo_SQLSeven.");
                            }
                        }
                    }
                }
            }
        }

        public static void Executar_Arquivo_SQL_CPF_CNPJ(string nomearquivo)
        {
            using (Con7BD con = new Con7BD())
            {
                if (File.Exists(nomearquivo))
                {
                    string[] linhas = File.ReadAllLines(nomearquivo, Encoding.UTF7);
                    //
                    List<string> blocoSQL = new List<string>();
                    StringBuilder blocoAtual = new StringBuilder();
                    bool capturando = false;
                    //
                    foreach (string linha in linhas)
                    {
                        string linhaAtual = linha.Trim();

                        if (!capturando && (linhaAtual.IndexOf("INSERT", StringComparison.OrdinalIgnoreCase) >= 0 || linhaAtual.IndexOf("CREATE", StringComparison.OrdinalIgnoreCase) >= 0 || linhaAtual.IndexOf("ALTER", StringComparison.OrdinalIgnoreCase) >= 0 || linhaAtual.IndexOf("DELETE", StringComparison.OrdinalIgnoreCase) >= 0 || linhaAtual.IndexOf("UPDATE", StringComparison.OrdinalIgnoreCase) >= 0 || linhaAtual.IndexOf("DROP", StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            capturando = true;
                        }

                        if (capturando == true)
                        {
                            blocoAtual.AppendLine(linha);

                            if (linhaAtual == ";" || linhaAtual.EndsWith(";"))
                            {
                                string resultado = Regex.Replace(blocoAtual.ToString(), @"\r\n|\r|\n", " ");

                                blocoSQL.Add(resultado.ToString().Trim());
                                blocoAtual.Clear();
                                capturando = false;
                            }
                        }
                    }
                    //
                    for (int i = 0; i < blocoSQL.Count; i++)
                    {
                        try
                        {
                            con.Executar_Arquivo_SQL(blocoSQL[i].Replace("\n", "").Replace("\r", ""));
                        }
                        catch (Exception ex)
                        {
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Método Executar_Arquivo_SQL_CPF_CNPJ.");
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Método Executar_Arquivo_SQL_CPF_CNPJ.");
                            }
                        }
                    }
                }
            }
        }

        public static void Executar_Arquivo_SQL_Operation(string nomearquivo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                if (File.Exists(nomearquivo))
                {
                    string[] linhas = File.ReadAllLines(nomearquivo, Encoding.UTF7);
                    //
                    List<string> blocoSQL = new List<string>();
                    StringBuilder blocoAtual = new StringBuilder();
                    bool capturando = false;
                    //
                    foreach (string linha in linhas)
                    {
                        string linhaAtual = linha.Trim();

                        if (!capturando && (linhaAtual.IndexOf("INSERT", StringComparison.OrdinalIgnoreCase) >= 0 || linhaAtual.IndexOf("CREATE", StringComparison.OrdinalIgnoreCase) >= 0 || linhaAtual.IndexOf("ALTER", StringComparison.OrdinalIgnoreCase) >= 0 || linhaAtual.IndexOf("DELETE", StringComparison.OrdinalIgnoreCase) >= 0 || linhaAtual.IndexOf("UPDATE", StringComparison.OrdinalIgnoreCase) >= 0 || linhaAtual.IndexOf("DROP", StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            capturando = true;
                        }

                        if (capturando == true)
                        {
                            blocoAtual.AppendLine(linha);

                            if (linhaAtual == ";" || linhaAtual.EndsWith(";"))
                            {
                                string resultado = Regex.Replace(blocoAtual.ToString(), @"\r\n|\r|\n", " ");

                                blocoSQL.Add(resultado.ToString().Trim());
                                blocoAtual.Clear();
                                capturando = false;
                            }
                        }
                    }
                    //
                    for (int i = 0; i < blocoSQL.Count; i++)
                    {
                        try
                        {
                            con.Executar_Arquivo_SQL(blocoSQL[i].Replace("\n", "").Replace("\r", ""));
                        }
                        catch (Exception ex)
                        {
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Método Executar_Arquivo_SQLSeven.");
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Método Executar_Arquivo_SQLSeven.");
                            }
                        }
                    }
                }
            }
        }

        public static void SubstituirSeven_Adm(string nome_servidor)
        {
            string diretorio = @"C:\Sistema SEVEN\";
            string nomeAntigo = "Seven_Adm.exe";
            string nomeNovo = "ADM_" + DateTime.Now.Day + DateTime.Now.ToString("HH:mm:ss").Replace(":", "") + ".old";
            //
            string caminhoAntigo = Path.Combine(diretorio, nomeAntigo);
            string caminhoNovo = Path.Combine(diretorio, nomeNovo);
            //
            if (File.Exists(caminhoAntigo))
            {
                File.Move(caminhoAntigo, caminhoNovo);
            }
            //
            string dirRecebido = @"C:\Sistema SEVEN\Config\Recebidos\seven_adm\";
            //
            File.Copy(Path.Combine(dirRecebido, nome_servidor), Path.Combine(diretorio, "Seven_ADM.exe"));
        }

        public static void SubstituirSeven_Pdv(string nome_servidor)
        {
            string diretorio = @"C:\Sistema SEVEN\";
            string nomeAntigo = "Seven_PDV.exe";
            string nomeNovo = "PDV_" + DateTime.Now.Day + DateTime.Now.ToString("HH:mm:ss").Replace(":", "") + ".old";
            //
            string caminhoAntigo = Path.Combine(diretorio, nomeAntigo);
            string caminhoNovo = Path.Combine(diretorio, nomeNovo);
            //
            if (File.Exists(caminhoAntigo))
            {
                File.Move(caminhoAntigo, caminhoNovo);
            }
            //
            string dirRecebido = @"C:\Sistema SEVEN\Config\Recebidos\seven_pdv\";
            //
            File.Copy(Path.Combine(dirRecebido, nome_servidor), Path.Combine(diretorio, "Seven_PDV.exe"));
        }

        public static void SubstituirBLL(string nome_servidor)
        {
            string diretorio = @"C:\Sistema SEVEN\";
            string nomeAntigo = "BLL.dll";
            string nomeNovo = "BLL_" + DateTime.Now.Day + DateTime.Now.ToString("HH:mm:ss").Replace(":", "") + ".old";
            //
            string caminhoAntigo = Path.Combine(diretorio, nomeAntigo);
            string caminhoNovo = Path.Combine(diretorio, nomeNovo);
            //
            if (File.Exists(caminhoAntigo))
            {
                File.Move(caminhoAntigo, caminhoNovo);
            }
            //
            string dirRecebido = @"C:\Sistema SEVEN\Config\Recebidos\bll\";
            //
            File.Copy(Path.Combine(dirRecebido, nome_servidor), Path.Combine(diretorio, "BLL.dll"));
        }
       
        public static void SubstituirDAL(string nome_servidor)
        {
            string diretorio = @"C:\Sistema SEVEN\";
            string nomeAntigo = "DAL.dll";
            string nomeNovo = "DAL_" + DateTime.Now.Day + DateTime.Now.ToString("HH:mm:ss").Replace(":", "") + ".old";
            //
            string caminhoAntigo = Path.Combine(diretorio, nomeAntigo);
            string caminhoNovo = Path.Combine(diretorio, nomeNovo);
            //
            if (File.Exists(caminhoAntigo))
            {
                File.Move(caminhoAntigo, caminhoNovo);
            }
            //
            string dirRecebido = @"C:\Sistema SEVEN\Config\Recebidos\dal\";
            //
            File.Copy(Path.Combine(dirRecebido, nome_servidor), Path.Combine(diretorio, "DAL.dll"));
        }

        public static void Substituir_Config(string caminho)
        {
            string origem = caminho + @"\Config";
            string destino = @"C:\Sistema SEVEN\Config";

            foreach (string arquivoOrigem in Directory.GetFiles(origem, "*", SearchOption.AllDirectories))
            {
                string caminhoRelativo = arquivoOrigem.Substring(origem.Length + 1);
                string arquivoDestino = Path.Combine(destino, caminhoRelativo);

                Directory.CreateDirectory(Path.GetDirectoryName(arquivoDestino));

                // Substitui se já existir
                if (File.Exists(arquivoDestino))
                    File.Delete(arquivoDestino);

                File.Move(arquivoOrigem, arquivoDestino);
            }
        }

        public static void Substituir_Sistema_Seven(string caminho)
        {
            string origem = caminho + @"\Sistema SEVEN";
            string destino = @"C:\Sistema SEVEN";

            foreach (string arquivoOrigem in Directory.GetFiles(origem, "*", SearchOption.AllDirectories))
            {
                string caminhoRelativo = arquivoOrigem.Substring(origem.Length + 1);
                string arquivoDestino = Path.Combine(destino, caminhoRelativo);
                //
                Directory.CreateDirectory(Path.GetDirectoryName(arquivoDestino));
                //
                if (File.Exists(arquivoDestino))
                {
                    File.Move(arquivoDestino, arquivoDestino + ".old");
                }
                //
                File.Move(arquivoOrigem, arquivoDestino);
            }
        }

        public static void Substituir_ACBR_LIB(string caminho)
        {
            if (Directory.Exists(@"C:\Sistema SEVEN\ACBrLib"))
            {
                Directory.Move(@"C:\Sistema SEVEN\ACBrLib", @"C:\Sistema SEVEN\ACBrLib.old");
            }
            //
            Directory.Move(caminho + @"\ACBrLib", @"C:\Sistema SEVEN\ACBrLib");
        }

        public static void SubstituirSeven_Config(string nome_servidor)
        {
            string diretorio = @"C:\Sistema SEVEN\";
            string nomeAntigo = "Seven_Config.exe";
            string nomeNovo = "Config_" + DateTime.Now.Day + DateTime.Now.ToString("HH:mm:ss").Replace(":", "") + ".old";
            //
            string caminhoAntigo = Path.Combine(diretorio, nomeAntigo);
            string caminhoNovo = Path.Combine(diretorio, nomeNovo);
            //
            if (File.Exists(caminhoAntigo))
            {
                File.Move(caminhoAntigo, caminhoNovo);
            }
            //
            string dirRecebido = @"C:\Sistema SEVEN\Config\Recebidos\seven_config\";
            //
            File.Copy(Path.Combine(dirRecebido, nome_servidor), Path.Combine(diretorio, "Seven_Config.exe"));
        }

        public static void LimparArquivosOld()
        {
            string diretorio = @"C:\Sistema SEVEN\";
            string extensao = "*.old";

            if (Directory.Exists(diretorio))
            {
                string[] arquivos = Directory.GetFiles(diretorio, extensao);

                for(int i = 0; i < arquivos.Length;i++)
                {
                    File.Delete(arquivos[i]);
                }
            }
            //
            if (Directory.Exists(diretorio))
            {
                string[] diretorios = Directory.GetDirectories(diretorio);
                //
                for (int i = 0; i < diretorios.Length; i++)
                {
                    if (diretorios[i].Contains(".old"))
                    {
                        Directory.Delete(diretorios[i], true);
                    }
                }
            }
        }

        public static void LimparArquivosRecebidos()
        {
            string diretorio = @"C:\Sistema SEVEN\Config\Recebidos";

            if (Directory.Exists(diretorio))
            {
                DirectoryInfo Dir = new DirectoryInfo(diretorio);

                foreach (FileInfo file in Dir.GetFiles())
                {
                    file.Delete();
                }

                foreach (DirectoryInfo direcetory in Dir.GetDirectories())
                {
                    direcetory.Delete(true);
                }
            }
        }

        public static void CriarArquivoLogLoginServ(string modulo, string versao, string tempologado)
        {
            string criartxt = null;
            //
            string diretorio = @"C:\Sistema SEVEN\" + modulo + ".txt";
            //
            string cpfcnpj;
            if (bllMinhaEmpresa.Sel_Empresa_CPFCNPJ() == null)
            {
                cpfcnpj = "_Teste" + "" + DateTime.Now.ToShortDateString().Replace("/", "") + "" + DateTime.Now.ToLongTimeString().Replace(":", "");
            }
            else
            {
                cpfcnpj = "_" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", "") + "_";
            }
            //
            DataRow dr;
            string licenca;
            if (bllLicenca.Verificar_Data_Licenca() == null)
            {
                licenca = "";
            }
            else
            {
                dr = bllLicenca.Verificar_Data_Licenca().Rows[0];
                //
                licenca = "Id: " + dr["id_licenca"].ToString() + " Expira em: " + dr["data_expiracao"].ToString();
            }
            //
            string computador;
            if (bllCadastroComputadores.Sel_Computadores_Ver_Codigo(Environment.MachineName) == null)
            {
                computador = "";
            }
            else
            {
                dr = bllCadastroComputadores.Sel_Computadores_Ver_Codigo(Environment.MachineName).Rows[0];
                //
                computador = dr["id_cadastro_computadores"].ToString();
            }
            criartxt = @"[Info]
Empresa: " + bllMinhaEmpresa.Sel_Nome_Empresa() + @"
CPF/CNPJ: " + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ() + @"
Versao: " + versao + @"
Computador: " + computador + "-" + Environment.MachineName + @"
Data: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + @"
Tempo Logado: " + tempologado + @"
Licença: " + licenca;

            ;
            //
            File.WriteAllText(diretorio, criartxt, Encoding.UTF8);
            //
            using (var scpclient = new ScpClient(host, username, password))
            {
                using (ConOperationBD con = new ConOperationBD())
                {
                    using (Versao Ver = new Versao())
                    {
                        scpclient.Connect();
                        //
                        using (var filestream = new FileStream(diretorio, FileMode.Open))
                        {
                            scpclient.Upload(filestream, "/sistema_seven/logins/" + modulo + "" + cpfcnpj + "" + computador + ".txt");
                        }
                        //
                        scpclient.Disconnect();
                    }
                }
            }
            //
            File.Delete(diretorio);
        }

        public static async Task<bool> VerificarInternet() 
        {
            using (var client = new HttpClient()) 
            {
                try
                {
                    client.Timeout = TimeSpan.FromSeconds(3);
                    var response = await client.GetAsync("http://www.google.com");
                    return response.IsSuccessStatusCode;
                }
                catch (Exception) 
                {
                    return false;
                }
            }


        }
    }
}
