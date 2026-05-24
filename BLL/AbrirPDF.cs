using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AbrirPDF
    {
        public static void Pdf(string caminho)
        {
            string pdfOriginal = caminho;
            //
            string guid = Guid.NewGuid().ToString("N");
            //
            string pastaTemp = @"C:\Windows\Temp\Sistema SEVEN\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", "");
            Directory.CreateDirectory(pastaTemp);
            //
            string pdfTemp = Path.Combine(pastaTemp, guid + ".pdf");
            //
            File.Copy(caminho, pdfTemp, true);
            //
            string url = new Uri(pdfTemp).AbsoluteUri;
            //
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
    }
}
