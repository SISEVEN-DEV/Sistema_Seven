using CG.Web.MegaApiClient;
using DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class bllBackup
    {
        private static string _Email = "7sistema.suporte@gmail.com";
        private static string _Senha = "7sissuporte10";

        public static void RealizarBackupLocal(string caminho, bool backupdirseven, IWin32Window owner) 
        {
            string arqmes;
            if (DateTime.Now.Month < 10)
            {
                arqmes = "0" + DateTime.Now.Month;
            }
            else
            {
                arqmes = DateTime.Now.Month.ToString();
            }
            //
            Directory.CreateDirectory(caminho + @"\Backup_" + DateTime.Now.Day + "_" + arqmes + "_" + DateTime.Now.Year);
            //
            string caminhoArquivo = "\"" + caminho + @"\Backup_" + DateTime.Now.Day + "_" + arqmes + "_" + DateTime.Now.Year + @"\backup_" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", "") + "_" + DateTime.Now.ToString("HH_mm_ss") + ".fbk" + "\"";
            //
            Process Proc = new Process();
            ProcessStartInfo Start = new ProcessStartInfo();
            Start.FileName = @"C:\Windows\system32\cmd.exe";
            Start.Verb = "runas";
            if (Environment.Is64BitOperatingSystem == true)
            {
                Start.Arguments = @"/C (CD C:\Sistema SEVEN\firebird64\bin)&(gbak -b -v -user sysdba -password 7sysgod " + "\"" + bllConexao._Descricao_Conexao_Atual + "\"" + @" " + caminhoArquivo + ")";
            }
            else
            {
                Start.Arguments = @"/C (CD C:\Sistema SEVEN\firebird32\bin)&(gbak -b -v -user sysdba -password 7sysgod " + "\"" + bllConexao._Descricao_Conexao_Atual + "\"" + @" " + caminhoArquivo + ")";
            }
            //MessageBox.Show(@"/C (CD C:\Firebird Zip\bin)&(gbak -b -v -user sysdba -password 7sysgod " + "\"" + bllConexao._Descricao_Conexao_Atual + "\"" + @" " + _Caminho.Substring(0, 2) + @"\Backup_" + DateTime.Now.Day + "_" + arqmes + "_" + DateTime.Now.Year + @"\backup.fbk)");
            //MessageBox.Show(@"/K (CD C:\Program Files\Firebird\Firebird_2_5\bin)&(gbak -b -v -user sysdba -password 7sysgod " + "\"" + bllConexao._Descricao_Conexao_Atual + "\"" + @" " + cbbCaminho.Text.Substring(0, 3) + @"\Backup_" + DateTime.Now.Day + "_" + arqmes + "_" + DateTime.Now.Year + @"\backup.fbk)");
            Start.UseShellExecute = false;
            Start.CreateNoWindow = true;
            Proc.StartInfo = Start;
            Proc.Start();
            Proc.WaitForExit(5000);
            //
            if (backupdirseven == true)
            {
                var diretorios = Directory.GetDirectories(@"C:\Sistema SEVEN", "*", SearchOption.AllDirectories);
                //
                foreach (string diretorio in diretorios)
                {
                    string diretorioAcriar = diretorio.Replace(@"C:\Sistema SEVEN", caminho + @"\Backup_" + DateTime.Now.Day + "_" + arqmes + "_" + DateTime.Now.Year + @"\Sistema SEVEN");
                    //
                    Directory.CreateDirectory(diretorioAcriar);
                }
                //
                var todosArquivos = Directory.GetFiles(@"C:\Sistema SEVEN", "*", SearchOption.AllDirectories);
                //
                foreach (string arquivo in todosArquivos)
                {
                    File.Copy(arquivo, arquivo.Replace(@"C:\", caminho + @"\Backup_" + DateTime.Now.Day + "_" + arqmes + "_" + DateTime.Now.Year + @"\"), true);
                }
            }
            //
            string pastaDestino = "bkp_" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", "") + "_" + DateTime.Now.ToString("HH_mm_ss"); // nome da pasta no MEGA
            //
            var client = new MegaApiClient();
            //
            client.Login(_Email, _Senha);
            //
            int tentativas = 0;
            bool sucesso = false;
            //
            while (!sucesso && tentativas < 3)
            {
                try
                {
                    tentativas++;

                    var nodes = client.GetNodes();

                    var pastaNode = nodes.FirstOrDefault(n => n.Type == NodeType.Directory && n.Name == pastaDestino);

                    // Se a pasta não existir, cria ela na raiz
                    if (pastaNode == null)
                    {
                        var root = nodes.Single(n => n.Type == NodeType.Root);
                        pastaNode = client.CreateFolder(pastaDestino, root);
                    }

                    string file = caminhoArquivo.Replace("\"", "");

                    using (var stream = new FileStream(file, FileMode.Open))
                    {
                        client.Upload(stream, Path.GetFileName(file), pastaNode);
                    }

                    sucesso = true;

                    bllConfiguracaoSistema.Alterar_Data_Ult_Backup();
                }
                catch (Exception ex) when (tentativas < 3)
                {
                    MessageBox.Show(owner, "Erro.\n" + ex.Message + "\n\nTentando novamente... Tentativa " + tentativas + " de 3.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Thread.Sleep(2000);
                }
            }
            //
            client.Logout();
        }

        public static void RealizarBackupFbkRede(IWin32Window owner)
        {
            string caminho = @"C:\Windows\Temp\Sistema SEVEN\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", "");
            //
            string arqmes;
            if (DateTime.Now.Month < 10)
            {
                arqmes = "0" + DateTime.Now.Month;
            }
            else
            {
                arqmes = DateTime.Now.Month.ToString();
            }
            //
            Directory.CreateDirectory(caminho + @"\Backup_" + DateTime.Now.Day + "_" + arqmes + "_" + DateTime.Now.Year);
            //
            string caminhoArquivo = "\"" + caminho + @"\Backup_" + DateTime.Now.Day + "_" + arqmes + "_" + DateTime.Now.Year + @"\backup.fbk" + "\"";
            //
            Process Proc = new Process();
            ProcessStartInfo Start = new ProcessStartInfo();
            Start.FileName = @"C:\Windows\system32\cmd.exe";
            Start.Verb = "runas";
            if (Environment.Is64BitOperatingSystem == true)
            {
                Start.Arguments = @"/C (CD C:\Sistema SEVEN\firebird64\bin)&(gbak -b -v -user sysdba -password 7sysgod " + "\"" + bllConexao._Descricao_Conexao_Atual + "\"" + @" " + caminhoArquivo + ")";
            }
            else
            {
                Start.Arguments = @"/C (CD C:\Sistema SEVEN\firebird32\bin)&(gbak -b -v -user sysdba -password 7sysgod " + "\"" + bllConexao._Descricao_Conexao_Atual + "\"" + @" " + caminhoArquivo + ")";
            }
            //MessageBox.Show(@"/C (CD C:\Firebird Zip\bin)&(gbak -b -v -user sysdba -password 7sysgod " + "\"" + bllConexao._Descricao_Conexao_Atual + "\"" + @" " + _Caminho.Substring(0, 2) + @"\Backup_" + DateTime.Now.Day + "_" + arqmes + "_" + DateTime.Now.Year + @"\backup.fbk)");
            //MessageBox.Show(@"/K (CD C:\Program Files\Firebird\Firebird_2_5\bin)&(gbak -b -v -user sysdba -password 7sysgod " + "\"" + bllConexao._Descricao_Conexao_Atual + "\"" + @" " + cbbCaminho.Text.Substring(0, 3) + @"\Backup_" + DateTime.Now.Day + "_" + arqmes + "_" + DateTime.Now.Year + @"\backup.fbk)");
            Start.UseShellExecute = false;
            Start.CreateNoWindow = true;
            Proc.StartInfo = Start;
            Proc.Start();
            Proc.WaitForExit(5000);
            //
            string pastaDestino = "bkp_" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", "") + "_" + DateTime.Now.ToString("HH_mm_ss"); // nome da pasta no MEGA
            //
            var client = new MegaApiClient();
            //
            client.Login(_Email, _Senha);
            //
            int tentativas = 0;
            bool sucesso = false;
            //
            while (!sucesso && tentativas < 3)
            {
                try
                {
                    tentativas++;

                    var nodes = client.GetNodes();

                    var pastaNode = nodes.FirstOrDefault(n => n.Type == NodeType.Directory && n.Name == pastaDestino);

                    // Se a pasta não existir, cria ela na raiz
                    if (pastaNode == null)
                    {
                        var root = nodes.Single(n => n.Type == NodeType.Root);
                        pastaNode = client.CreateFolder(pastaDestino, root);
                    }

                    string file = caminhoArquivo.Replace("\"", "");

                    using (var stream = new FileStream(file, FileMode.Open))
                    {
                        client.Upload(stream, Path.GetFileName(file), pastaNode);
                    }

                    sucesso = true;

                    bllConfiguracaoSistema.Alterar_Data_Ult_Backup();
                }
                catch (Exception ex) when (tentativas < 3)
                {
                    MessageBox.Show(owner , "Erro.\n" + ex.Message + "\n\nTentando novamente... Tentativa " + tentativas + " de 3.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Thread.Sleep(2000); 
                }
            }
            //
            client.Logout();
        }

        public static string Sel_Data_Ult_Backup()
        {
            using (Con7BD con = new Con7BD())
            {
                using (Servico Serv = new Servico())
                {
                    return con.Sel_Data_Ult_Backup();
                }
            }
        }
    }
}
